// ######################################################################
// ArenaTimer - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Interaction
{
	[RequireComponent(typeof(Collider2D))]
	public class ArenaTimer : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_timeLimit = 10f;
		[SerializeField] private SpawnPrefabAtEffect_SO m_keySpawnEffect;
		[SerializeField] private List<BaseEffect_SO> m_onTriggerEffects;
		[SerializeField] private List<Transform> m_dropPoints;
		#endregion

		#region Internal State Field(s):
		private Coroutine m_spawnKeyAfterTimeCoroutine;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => GetComponent<Collider2D>().isTrigger = true;
		private void OnDisable() => HelperMethods.StopCoroutineIfRunning(ref m_spawnKeyAfterTimeCoroutine, this);
		private void OnTriggerEnter2D(Collider2D other)
		{
			m_spawnKeyAfterTimeCoroutine = StartCoroutine(SpawnKeyAfterTimeCoroutine());
			m_onTriggerEffects.ForEach(e => e.PerformEffect(gameObject));
			GetComponent<Collider2D>().enabled = false;
		}
		#endregion

		#region Coroutine(s):
		private IEnumerator SpawnKeyAfterTimeCoroutine()
		{
			yield return HelperMethods.CustomWFS(m_timeLimit);

			Transform rndSpawnpoint = m_dropPoints[UnityEngine.Random.Range(0, m_dropPoints.Count)];

			m_keySpawnEffect.PerformEffect(rndSpawnpoint.gameObject);
		}
		#endregion
	}
}