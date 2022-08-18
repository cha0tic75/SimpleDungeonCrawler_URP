// ######################################################################
// PlayerDeathHandler - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections.Generic;
using UnityEngine;

using Project.Stats;

namespace Project.Actors.Player
{
    public class PlayerDeathHandler : TransformMonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private StatComponent m_playerHealth;
		[SerializeField] private List<BaseEffect_SO> m_deathEffects;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			if (m_playerHealth == null)
			{
				Debug.LogWarning("PlayerDeathHandler is missing a reference to playerHealth StatComponent");
				Destroy(this);
				return;
			}

			m_playerHealth.OnTakeDamageEvent += PlayerHealth_OnTakeDamageCallback;
		}

		private void OnDisable()
		{
			if (m_playerHealth == null) { return; }
			m_playerHealth.OnTakeDamageEvent -= PlayerHealth_OnTakeDamageCallback;
		}

        private void PlayerHealth_OnTakeDamageCallback(float _amount, StatComponent _statComponent)
        {
            if (_statComponent.CurrentValue > 0) { return; }

			m_deathEffects.ForEach(de => de.PerformEffect(gameObject));
			Transform.gameObject.SetActive(false);
			GameManager.Instance.ChangeGameState(GameState.Death);
        }
        #endregion
    }
}