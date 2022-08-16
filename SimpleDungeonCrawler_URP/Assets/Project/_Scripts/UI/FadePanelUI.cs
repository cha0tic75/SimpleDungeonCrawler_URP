// ######################################################################
// FadePanelUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class FadePanelUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private float m_defaultDuration = 0.5f;
		[SerializeField] private float m_defaultDelayBetween = 0.25f;
		#endregion

		#region Internal State Field(s):
		private CanvasGroup m_canvasGroup;
		private Coroutine m_currentFadeCoroutine = null;
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void Awake() => m_canvasGroup = GetComponent<CanvasGroup>();
		#endregion
		
		#region Public API:
		public void AlphaOverride(float _alpha) => m_canvasGroup.alpha = _alpha;
		public void FadeOut(float _duration = 0f)
		{
			StopCoroutineIfRunning();

			m_currentFadeCoroutine = StartCoroutine(LerpCanvasGroupToCoroutine(0f, 1f, (_duration > 0f) ? _duration : m_defaultDuration));
		}

		public IEnumerator FadeOutCoroutine(float _duration = 0f)
		{
			StopCoroutineIfRunning();

			yield return StartCoroutine(LerpCanvasGroupToCoroutine(0f, 1f, (_duration > 0f) ? _duration : m_defaultDuration));
		}

		public void FadeIn(float _duration = 0f)
		{
			StopCoroutineIfRunning();

			m_currentFadeCoroutine = StartCoroutine(LerpCanvasGroupToCoroutine(1f, 0f, (_duration > 0f) ? _duration : m_defaultDuration));
		}

		public IEnumerator FadeInCoroutine(float _duration = 0f)
		{
			StopCoroutineIfRunning();

			yield return StartCoroutine(LerpCanvasGroupToCoroutine(1f, 0f, (_duration > 0f) ? _duration : m_defaultDuration));
		}


		public void FadeInOut(float _duration = 0f, float _delayBetween = 0f)
		{
			StopCoroutineIfRunning();

			float duration = (_duration > 0f) ? _duration : m_defaultDuration;
			float delayBetween = (_delayBetween > 0f) ? _delayBetween : m_defaultDelayBetween;

			m_currentFadeCoroutine = StartCoroutine(FadeInOutCoroutine(duration, delayBetween));
		}
		#endregion

		#region Internally Used Method(s):
		private void StopCoroutineIfRunning() => HelperMethods.StopCoroutineIfRunning(ref m_currentFadeCoroutine, this);
		#endregion

		#region Coroutine(s):
		private IEnumerator FadeInOutCoroutine(float _duration, float _delayBetween)
		{
			yield return LerpCanvasGroupToCoroutine(0f, 1f, _duration * 0.5f);

			if (_delayBetween > 0f)
			{
				yield return HelperMethods.CustomWFS(_delayBetween);
			}

			yield return LerpCanvasGroupToCoroutine(1f, 0f, _duration * 0.5f);
		}
		private IEnumerator LerpCanvasGroupToCoroutine(float _startValue, float _endValue, float _duration)
		{
			m_canvasGroup.alpha = _startValue;

			float elapsedTime = 0f;
			while (elapsedTime < _duration)
			{
				m_canvasGroup.alpha = Mathf.Lerp(_startValue, _endValue, elapsedTime / _duration);
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			m_canvasGroup.alpha = _endValue;
		}
		#endregion
	}
}