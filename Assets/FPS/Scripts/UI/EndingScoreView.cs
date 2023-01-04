using Unity.FPS.Game;
using UnityEngine;
using TMPro;

namespace Unity.FPS.UI
{
    public class EndingScoreView : MonoBehaviour
    {
        TextMeshProUGUI m_EndingScoreViewText;

        void Start()
        {
            m_EndingScoreViewText = GetComponent<TextMeshProUGUI>();
            float? currentScore = PlayerPrefs.GetFloat(GameConstants.k_CurrentScoreKey);
            if (currentScore == null) currentScore = 0.0f;
            float? highestScore = PlayerPrefs.GetFloat(GameConstants.k_HighestScoreKey);
            if (highestScore == null) highestScore = 0.0f;
            m_EndingScoreViewText.text = $"Now Playing: {currentScore} m\r\nBest: {highestScore}m";
        }
    }
}
