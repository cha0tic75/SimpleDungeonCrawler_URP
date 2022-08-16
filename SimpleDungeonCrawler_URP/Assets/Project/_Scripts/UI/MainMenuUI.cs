// ######################################################################
// MainMenuUI - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project.UI
{
	public class MainMenuUI : MonoBehaviour
	{
		#region Inspector Assigned Field(s):
		[SerializeField] private GameObject m_mainPanel;
		[SerializeField] private GameObject m_titlePanel;
		[SerializeField] private GameObject m_infoPanel;
		#endregion

		#region Public API:
		public void SetMenuVisibility(bool _state)
		{
			m_mainPanel.SetActive(_state);

			if (_state)
			{
				SetInfoPanelVisibility(false);
			}
		}
		public void OnPlayButtonClicked() => GameManager.Instance.ChangeState(GameState.StartGame);
		public void OnInfoButtonClicked() => SetInfoPanelVisibility(true);
		public void OnBackButtonClicked() => SetInfoPanelVisibility(false);
		public void OnExitButtonClicked()
		{
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
		}
		#endregion

		#region Internally Used Method(s):
		private void SetInfoPanelVisibility(bool _state)
		{
			m_infoPanel.SetActive(_state);
			m_titlePanel.SetActive(!_state);
		}
		#endregion
	}
}