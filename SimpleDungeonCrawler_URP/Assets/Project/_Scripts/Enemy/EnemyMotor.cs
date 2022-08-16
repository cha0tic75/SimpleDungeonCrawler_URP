// ######################################################################
// EnemyMotor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class EnemyMotor : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Transform m_enemyTransform;
		[SerializeField] private float m_lerpDuration;
		[SerializeField] private float m_idleTime;
		[SerializeField] private List<Transform> m_waypoints = new List<Transform>();
		#endregion

		#region Internal State Field(s):
		private Coroutine m_moveCoroutine = null;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			GameManager.Instance.OnGameStateChangedEvent += GameManager_OnGameStateChangedCallback;
		}

		private void OnDisable()
		{
			if (GameManager.Instance != null)
			{
				GameManager.Instance.OnGameStateChangedEvent -= GameManager_OnGameStateChangedCallback;
			}
		}
		#endregion

		#region Callback(s):
        private void GameManager_OnGameStateChangedCallback(GameState _gameState)
        {
            if (_gameState == GameState.GamePlay)
			{
				m_moveCoroutine = StartCoroutine(MoveCoroutine());
			}
			else
			{
				HelperMethods.StopCoroutineIfRunning(ref m_moveCoroutine, this);
			}
        }
		#endregion

		#region Coroutine(s):
		private IEnumerator MoveCoroutine()
		{
			while (true)
			{
				for (int i = 0; i < m_waypoints.Count; i++ )
				{
					yield return MoveToPoint(m_enemyTransform.position, m_waypoints[i].position);
					yield return HelperMethods.CustomWFS(m_idleTime);
				}
			}
		}

		private IEnumerator MoveToPoint(Vector3 _startPoint, Vector3 _endPoint)
		{
			float elapsedTime = 0f;
			while (elapsedTime < m_lerpDuration)
			{
				m_enemyTransform.position = Vector3.Lerp(_startPoint, _endPoint, elapsedTime / m_lerpDuration);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			m_enemyTransform.position = _endPoint;
		}
		#endregion
	}
}
