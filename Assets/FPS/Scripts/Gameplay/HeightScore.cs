using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    
    public class HeightScore : MonoBehaviour
    {
        public float HighestScore => m_HighestScore;

        Transform m_PlayerTransform;
        float m_HighestScore = 0.0f;
        
        

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


        void LateUpdate(){
            if(m_HighestScore < m_PlayerTransform.position.y){
                m_HighestScore =  m_PlayerTransform.position.y;
            }
        }
        private void OnDestroy() {
            float? nowHighScore = PlayerPrefs.GetFloat("HighestScore");
            if(nowHighScore == null) nowHighScore = 0.0f;

            if(nowHighScore < m_HighestScore){
                PlayerPrefs.SetFloat ("HighestScore", m_HighestScore);
                PlayerPrefs.Save ();
                return;
            }
        }
        

        void Destroy(){
            
        }
    }
}