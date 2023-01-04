using UnityEngine;
using UnityEngine.UI;
using Unity.FPS.Game;

using TMPro;

namespace Unity.FPS.UI
{
    public class HighScoreView : MonoBehaviour
    {
        TextMeshProUGUI m_ScoreText;

        void Start()
        {
            m_ScoreText = GetComponent<TextMeshProUGUI>();
            float? nowHighScore = PlayerPrefs.GetFloat(GameConstants.k_HighestScoreKey);
            if (nowHighScore == null) nowHighScore = 0.0f;
            m_ScoreText.text = $"HighScore:\r\n{nowHighScore} m";
        }
    }
}