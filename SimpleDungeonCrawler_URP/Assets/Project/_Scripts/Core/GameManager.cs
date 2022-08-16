// ######################################################################
// GameManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Project.Utility;
using System.Collections;

namespace Project
{
    public class GameManager : PersistentSinglonMonoBehaviour<GameManager>
	{
		#region Delegate(s):
		public event Action<GameState> OnGameStateChangedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[field: SerializeField] public AudioSource AudioSource { get; private set; }
		[field: SerializeField] public CameraSystem.CameraTools CameraTools { get; private set; }
		[field: SerializeField] public ParticleAdmitter ParticleAdmitter { get; private set; }
		[field: SerializeField] public UI.FadePanelUI FadePanelUI { get; private set; }
		[field: SerializeField] public GameObject PausePanelOverlay { get; private set; }
		[field: SerializeField] public GameObject DeathPanelOverlay { get; private set; }
		#endregion

		#region Properties:
		public GameState CurrentState { get; private set; } = GameState.Unset;
		#endregion

		#region MonoBehaviour Callback Method(s):
        private void Start() => ChangeState(GameState.MainMenu);
		#endregion

		#region Public API:
		public void ChangeState(GameState _newGameState)
		{
			if (_newGameState == CurrentState) { return; }
			CurrentState = _newGameState;

			OnGameStateChangedEvent?.Invoke(CurrentState);

			switch(CurrentState)
			{
				case GameState.MainMenu:
					MainMenuState();
					break;

				case GameState.GamePlay:
					GamePlayState();
					break;

				case GameState.Pause:
					PauseState();
					break;

				case GameState.Death:
					DeathState();
					break;
			}
		}
		#endregion

		#region Internally Used Method(s):
		private void MainMenuState()
		{
			FadePanelUI.AlphaOverride(1f);
			HideOverlayPanels();
			
			LoadScene(SceneName.MenuScene);
			FadePanelUI.FadeIn();
		}

		private void GamePlayState()
		{
			FadePanelUI.FadeOut();
			HideOverlayPanels();

			LoadScene(SceneName.GamePlayScene);
			FadePanelUI.FadeIn();
		}

		private void PauseState()
		{
			PausePanelOverlay.SetActive(true);
		}

		private void DeathState()
		{
			DeathPanelOverlay.SetActive(true);
			FadePanelUI.FadeOut();
			
			StartCoroutine(LoadSceneAfterTime(SceneName.MenuScene, 2f));
			FadePanelUI.FadeIn();
		}

		private void HideOverlayPanels()
		{
			PausePanelOverlay.SetActive(false);
			DeathPanelOverlay.SetActive(false);
		}

		private void LoadScene(SceneName _sceneName) => SceneManager.LoadScene((int)_sceneName);
		#endregion

		#region Coroutine(s):
		private IEnumerator LoadSceneAfterTime(SceneName _sceneName, float _waitTime)
		{
			yield return HelperMethods.CustomWFS(_waitTime);
			LoadScene(_sceneName);
		}
		#endregion
	}
}