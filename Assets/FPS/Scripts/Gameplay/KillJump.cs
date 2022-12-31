using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.Gameplay
{
    public class KillJump : MonoBehaviour
    {
        PlayerCharacterController m_PlayerCharacterController;

        void Start()
        {
            EventManager.AddListener<EnemyKillEvent>(OnEnemyKilled);
            m_PlayerCharacterController = GetComponent<PlayerCharacterController>();
        }

        void OnEnemyKilled(EnemyKillEvent evt)
        {
            JumpPlayer();
        }

        void JumpPlayer()
        {
            m_PlayerCharacterController.JumpWithKill();
        }
    }
}
