using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class HeightScoreView : MonoBehaviour
    {
        
        Text m_ScoreText;
        HeightScore m_HeightScore;
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

            m_ScoreText = GetComponent<Text> ();
            m_HeightScore = FindObjectOfType<HeightScore>();
        }

        void Update()
        {
            m_ScoreText.text = $"now:\r\n{m_PlayerTransform.position.y} m\r\nbest:\r\n{m_HeightScore.HighestScore} m";
        }
    }
}