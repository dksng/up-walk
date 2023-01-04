using UnityEngine;
using UnityEngine.UI;
using Unity.FPS.Game;

namespace Unity.FPS.UI
{
    public class HighScoreView : MonoBehaviour
    {
        Text m_ScoreText;

        void Start()
        {
            m_ScoreText = GetComponent<Text> ();
            float? nowHighScore = PlayerPrefs.GetFloat(GameConstants.k_HighestScoreKey);
            if(nowHighScore == null) nowHighScore = 0.0f;
            m_ScoreText.text = nowHighScore.ToString();
        }
    }
}