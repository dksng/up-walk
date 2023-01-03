using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class HeightScoreView : MonoBehaviour
    {
        
        Text m_ScoreText;
        HeightScore m_HeightScore;

        void Start()
        {
            m_ScoreText = GetComponent<Text> ();
            m_HeightScore = FindObjectOfType<HeightScore>();
        }

        void Update()
        {
            m_ScoreText.text =  m_HeightScore.HighestScore.ToString();
        }
    }
}