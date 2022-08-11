// ######################################################################
// DamageWallEffects - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Project.Damage
{
	[RequireComponent(typeof(Tilemap))]
	public class DamageWallEffects : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private Color m_colorA;
		[SerializeField] private Color m_colorB;
		[SerializeField] private MinMaxFloat m_passRange;
		[SerializeField] private Tilemap m_renderer;
		#endregion

		#region Internal State Field(s):
		private Coroutine m_effectsCoroutine = null;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake()
		{
			if (m_renderer == null)
			{
				m_renderer = GetComponent<Tilemap>();
			}

			m_renderer.color = m_colorA;	
		}

		private void OnEnable() => m_effectsCoroutine = StartCoroutine(EffectsCoroutine());
		private void OnDisable() => StopCoroutine(m_effectsCoroutine);
		#endregion

		#region Coroutine(s):
		private IEnumerator EffectsCoroutine()
		{
			while(true)
			{
				float passDuration = m_passRange.GetRandomValueInRange();
				yield return LerpToColor(m_colorB, passDuration * 0.5f);
				yield return LerpToColor(m_colorA, passDuration * 0.5f);
			}
		}

		private IEnumerator LerpToColor(Color _endColor, float _duration)
		{
			float time = 0;
			Color startColor = m_renderer.color;
			
			while (time < _duration)
			{
				m_renderer.color = Color.Lerp(startColor, _endColor, time / _duration);
				time += Time.deltaTime;
				yield return null;
			}
			
			m_renderer.color = _endColor;
		}
		#endregion
	}
}
