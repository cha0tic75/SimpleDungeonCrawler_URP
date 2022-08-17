// ######################################################################
// CoroutineLoadSceneGameStateBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System.Collections;
using UnityEngine;

namespace Project
{
    public class CoroutineLoadSceneGameStateBehaviour : SceneTransitionGameStateBehaviour
    {
		#region Constant(s):
		private const float DELAY_BEFORE_FADE_TO_MAIN_MENU = 2f;
		#endregion

        #region Internal State Field(s):
        private readonly SceneName m_sceneName;
        private readonly GameObject m_panel;
        #endregion

        #region Constructor(s):
        public CoroutineLoadSceneGameStateBehaviour(SceneName _sceneName, GameObject _panel)
        {
            m_sceneName = _sceneName;
            m_panel = _panel;
        }
        #endregion

        #region Public API:
        public override void Perform() => GameManager.Instance.StartCoroutine(PerformCoroutine());
        #endregion

        #region Coroutine(s):
		private IEnumerator PerformCoroutine()
		{
			m_panel.SetActive(true);
			yield return HelperMethods.CustomWFS(DELAY_BEFORE_FADE_TO_MAIN_MENU);
			
			yield return GameManager.Instance.FadePanelUI.FadeOutCoroutine(2f);
			
			yield return LoadSceneAfterTime(m_sceneName, 1f);
			m_panel.SetActive(false);
			yield return GameManager.Instance.FadePanelUI.FadeInCoroutine(2f);
		}
        #endregion
    }
}