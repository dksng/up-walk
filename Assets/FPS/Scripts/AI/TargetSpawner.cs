using Unity.FPS.Game;
using UnityEngine;
using Unity.FPS.AI;
using System.Collections;

namespace Unity.FPS.Gameplay
{
    
    public class TargetSpawner : MonoBehaviour {

        [Tooltip("Horizon distance of not spawn")]
        public float ProhibitSpawnHorizontalDistance = 1.0f;
        
        [Tooltip("Up distance of not spawn")]
        public float ProhibitSpawnUpDistance = 1.0f;

        [Tooltip("Down distance of not spawn")]
        public float ProhibitSpawnDownDistance = 1.0f;

        [Tooltip("Horizon limit distance")]
        public float LimitSpawnHorizontalDistance = 10.0f;
        
        [Tooltip("Up limit distance")]
        public float LimitSpawnUpDistance = 10.0f;

        [Tooltip("Down limit distance")]
        public float LimitSpawnDownDistance = 10.0f;

        [Tooltip("Max targets")]
        public int MaxTargets = 100;
        
        [Tooltip("Spawn interval second")]
        public float IntervalSecond = 0.5f;

        [SerializeField] GameObject basicTarget;

        Transform m_PlayerTransform;
        EnemyManager m_EnemyManager;
        
        IEnumerator Start () {
            ActorsManager actorsManager = FindObjectOfType<ActorsManager>();
            m_EnemyManager = FindObjectOfType<EnemyManager>();
            
            if (actorsManager != null)
                m_PlayerTransform = actorsManager.Player.transform;
            else
            {
                enabled = false;
            }

            // initial spawn
            for (int i=0; i<MaxTargets/4; i++){
                SpawnNewTarget();
            }

            while (true) {
                if( MaxTargets > m_EnemyManager.Enemies.Count){
                    SpawnNewTarget();
                }
                yield return new WaitForSeconds(IntervalSecond);
            }
        }

        void SpawnNewTarget(){      
            Vector3 spawnPosition = new Vector3(
                Mathf.Ceil(Random.Range(-1,1)) * Random.Range(ProhibitSpawnHorizontalDistance, LimitSpawnHorizontalDistance),
                Random.Range(ProhibitSpawnUpDistance,LimitSpawnUpDistance),
                Mathf.Ceil(Random.Range(-1,1)) * Random.Range(ProhibitSpawnHorizontalDistance, LimitSpawnHorizontalDistance)                
            );
            Instantiate(basicTarget, spawnPosition + m_PlayerTransform.position, Random.rotation);
        }
    }
}