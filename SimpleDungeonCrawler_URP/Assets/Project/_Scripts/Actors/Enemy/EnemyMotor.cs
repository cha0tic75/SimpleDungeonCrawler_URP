// ######################################################################
// EnemyMotor - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Actors.Enemies
{
	public class EnemyMotor : MonoBehaviour, IMovementInputProvider
	{
		#region Delegate(s):
        public event Action<Vector2> OnMovementInputEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[SerializeField] private Transform m_enemyTransform;
		[SerializeField] private MinMaxFloat m_moveSpeedRange = new MinMaxFloat(1.8f, 2.2f);
		[SerializeField] private MinMaxFloat m_idleTimeRange;
		[SerializeField] private List<Transform> m_waypoints = new List<Transform>();
		#endregion

		#region Internal State Field(s):
		private int m_currentWaypointIndex = 0;
		private Coroutine m_moveCoroutine = null;
        #endregion

        #region MonoBehaviour Callback Method(s):
        private void OnEnable() => 
			m_moveCoroutine = StartCoroutine(MoveCoroutine());
		private void OnDisable() => 
			HelperMethods.StopCoroutineIfRunning(ref m_moveCoroutine, this);
		#endregion

		#region Coroutine(s):
		private IEnumerator MoveCoroutine()
		{
			while (true)
			{
				yield return MoveToWaypoint();
				m_currentWaypointIndex = (m_currentWaypointIndex + 1) % m_waypoints.Count;
				OnMovementInputEvent?.Invoke(Vector2.zero);
				yield return HelperMethods.CustomWFS(m_idleTimeRange.GetRandomValueInRange());
			}
		}

		private IEnumerator MoveToWaypoint()
		{
			Transform targetTransform = m_waypoints[m_currentWaypointIndex];
			OnMovementInputEvent?.Invoke(Vector2.one.normalized);
			float rndMoveSpeed = m_moveSpeedRange.GetRandomValueInRange();
			while((m_enemyTransform.position - targetTransform.position).sqrMagnitude > 0f)
			{
				m_enemyTransform.position = Vector3.MoveTowards(m_enemyTransform.position, targetTransform.position, Time.deltaTime * rndMoveSpeed);
				yield return null;
			}
		}
		#endregion
	}
}
