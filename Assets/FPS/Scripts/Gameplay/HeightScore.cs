using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{

    public class HeightScore : MonoBehaviour
    {

        public float NotificationIntervalScore = 50.0f;
        public float HighestScore => m_HighestScore;

        Transform m_PlayerTransform;
        float m_HighestScore = 0.0f;

        float m_lastNotificationScore = 0.0f;


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

        void Update()
        {
            float ceiledScore = Mathf.Ceil(m_HighestScore);
            if (ceiledScore == m_lastNotificationScore) return;

            if (ceiledScore % NotificationIntervalScore == 0)
            {
                UpdateObjective(ceiledScore);
                m_lastNotificationScore = ceiledScore;
            }
        }

        void UpdateObjective(float score)
        {
            DisplayMessageEvent evt = Events.DisplayMessageEvent;
            evt.Message = $"{score} m !!";
            EventManager.Broadcast(evt);
        }


        void LateUpdate()
        {
            if (m_HighestScore < m_PlayerTransform.position.y)
            {
                m_HighestScore = m_PlayerTransform.position.y;
            }
        }
        private void OnDestroy()
        {
            float? nowHighScore = PlayerPrefs.GetFloat(GameConstants.k_HighestScoreKey);
            if (nowHighScore == null) nowHighScore = 0.0f;

            if (nowHighScore < m_HighestScore)
            {
                PlayerPrefs.SetFloat(GameConstants.k_HighestScoreKey, m_HighestScore);
                PlayerPrefs.Save();
            }
            PlayerPrefs.SetFloat(GameConstants.k_CurrentScoreKey, m_HighestScore);
            PlayerPrefs.Save();
        }


        void Destroy()
        {

        }
    }
}