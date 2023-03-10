using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.AI
{
    [RequireComponent(typeof(EnemyController))]
    public class BasicTarget : MonoBehaviour
    {

        public Animator Animator;

        [Tooltip("Target move speed")]
        public float MoveSpeed = 0.01f;

        [Tooltip("Rotate distance")]
        public float RotateDistance = 1.0f;
        
        [Tooltip("Affect jump power for player")]
        public float AddingJumpPower = 15.0f;

        [Tooltip("Fraction of the enemy's attack range at which it will stop moving towards target while attacking")]
        [Range(0f, 1f)]
        public float AttackStopDistanceRatio = 0.5f;

        [Tooltip("The random hit damage effects")]
        public ParticleSystem[] RandomHitSparks;

        [Header("Sound")] public AudioClip MovementSound;
        public MinMaxFloat PitchDistortionMovementSpeed;

        EnemyController m_EnemyController;
        AudioSource m_AudioSource;
        
        Transform m_PlayerTransform;

        float m_RotateProgress = 0.5f;
        float m_progressSpeed;

        const string k_AnimMoveSpeedParameter = "MoveSpeed";
        const string k_AnimAttackParameter = "Attack";
        const string k_AnimAlertedParameter = "Alerted";
        const string k_AnimOnDamagedParameter = "OnDamaged";
        
        void Awake(){
            m_progressSpeed = MoveSpeed/RotateDistance;
        }

        void Start()
        {
            ActorsManager actorsManager = FindObjectOfType<ActorsManager>();
            if (actorsManager != null)
                m_PlayerTransform = actorsManager.Player.transform;
            else
            {
                enabled = false;
                return;
            }

            m_EnemyController = GetComponent<EnemyController>();
            DebugUtility.HandleErrorIfNullGetComponent<EnemyController, BasicTarget>(m_EnemyController, this,
                gameObject);

            m_EnemyController.SetPathDestinationToClosestNode();
            m_EnemyController.onDamaged += OnDamaged;

            // adding a audio source to play the movement sound on it
            m_AudioSource = GetComponent<AudioSource>();
            DebugUtility.HandleErrorIfNullGetComponent<AudioSource, BasicTarget>(m_AudioSource, this, gameObject);
            m_AudioSource.clip = MovementSound;
            m_AudioSource.Play();
        }

        void Update()
        {
            if(Mathf.Abs(transform.position.y-m_PlayerTransform.position.y)> 30){
                m_EnemyController.Remove();
                return;
            }
            
            m_RotateProgress += m_progressSpeed; 
            
            // rotate  to forward (and backward) direction
            transform.position +=  transform.forward * MoveSpeed * Mathf.Sign(m_RotateProgress-0.5f);
            
            if(m_RotateProgress > 1.00f){
                m_RotateProgress = 0.0f;
            }
        }


        void OnAttack()
        {
            Animator.SetTrigger(k_AnimAttackParameter);
        }

        void OnDamaged()
        {
            if (RandomHitSparks.Length > 0)
            {
                int n = Random.Range(0, RandomHitSparks.Length - 1);
                RandomHitSparks[n].Play();
            }

            Animator.SetTrigger(k_AnimOnDamagedParameter);
        }
    }
}