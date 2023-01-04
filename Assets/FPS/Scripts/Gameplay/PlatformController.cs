using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{    
    public class PlatformController : MonoBehaviour {
        
        [SerializeField] float DisappearDistance = 15.0f;
        Transform m_PlayerTransform;

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
        }

        void Update() {
             if(DisappearDistance<Mathf.Abs(transform.position.y - m_PlayerTransform.position.y)){
                Destroy(gameObject);
             }
        }       
    }
}