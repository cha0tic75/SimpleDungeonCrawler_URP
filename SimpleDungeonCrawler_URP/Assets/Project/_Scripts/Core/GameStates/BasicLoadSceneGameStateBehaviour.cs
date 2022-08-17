// ######################################################################
// BasicLoadSceneGameStateBehaviour - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;

namespace Project
{
    public class BasicLoadSceneGameStateBehaviour : SceneTransitionGameStateBehaviour
    {
        #region Internal State Field(s):
        private readonly Action m_action;
        private readonly SceneName m_sceneName;
        #endregion

        #region Constructor(s):
        public BasicLoadSceneGameStateBehaviour(SceneName _sceneName, Action _action)
        {
            m_sceneName = _sceneName;
            m_action = _action;
        }
        #endregion

        #region Public API:
        public override void Perform()
        {
			GameManager.Instance.FadePanelUI.AlphaOverride(1f);
            m_action?.Invoke();
			
			LoadScene(m_sceneName);
			GameManager.Instance.FadePanelUI.FadeIn();
        }
        #endregion
    }
}