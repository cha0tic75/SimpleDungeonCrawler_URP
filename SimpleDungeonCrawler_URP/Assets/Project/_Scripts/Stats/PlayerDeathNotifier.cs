// ######################################################################
// PlayerDeathNotifier - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.Stats
{
    public class PlayerDeathNotifier : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private StatComponent m_playerHealth;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			if (m_playerHealth == null)
			{
				Debug.LogWarning("PlayerDeathNotifier is missing a reference to playerHealth StatComponent");
				Destroy(this);
				return;
			}

			m_playerHealth.OnTakeDamageEvent += PlayerHealth_OnTakeDamageCallback;
		}

		private void OnDisable()
		{
			if (m_playerHealth == null) { return; }
			m_playerHealth.OnTakeDamageEvent += PlayerHealth_OnTakeDamageCallback;
		}

        private void PlayerHealth_OnTakeDamageCallback(float _amount, StatComponent _statComponent)
        {
            if (_statComponent.CurrentValue > 0) { return; }

			GameManager.Instance.ChangeState(GameState.Death);
        }
        #endregion
    }
}