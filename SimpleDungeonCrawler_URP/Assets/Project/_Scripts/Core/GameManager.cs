// ######################################################################
// GameManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using System.Linq;
using Project.Stats;
using Project.Utility;
using UnityEngine;

namespace Project
{
	public enum GameState
	{
		MainMenu, 
		StartGame, 
		GamePlay, 
		Pause, 
		Death,
	}
	public class GameManager : SingletonMonoBehaviour<GameManager>
	{
		#region Delegate(s):
		public event Action<GameState> OnGameStateChangedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[field: SerializeField] public AudioSource AudioSource { get; private set; }
		[field: SerializeField] public Stats.StatComponent PlayerHealth { get; private set; }
		[field: SerializeField] public CameraSystem.CameraTools CameraTools { get; private set; }
		[field: SerializeField] public ParticleAdmitter ParticleAdmitter { get; private set; }
		[field: SerializeField] public UI.FadePanelUI FadePanelUI { get; private set; }
		[field: SerializeField] public UI.MainMenuUI MainMenuUI { get; private set; }
		[field: SerializeField] public GameObject PausePanelOverlay { get; private set; }
		[field: SerializeField] public GameObject DeathPanelOverlay { get; private set; }
		#endregion

		#region Properties:
		public GameState CurrentState { get; private set; }
		#endregion

		#region MonoBehaviour Callback Method(s):
		private void OnEnable()
		{
			PlayerHealth.OnValueChangedEvent += PlayerHealth_OnValueChangedCallback;
		}

        private void Start()
		{
			if (AudioSource == null) { AudioSource = gameObject.AddComponent<AudioSource>(); }
			ChangeState(GameState.MainMenu);
		}
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
					
				case GameState.StartGame:
					StartGameState();
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
			MainMenuUI.SetMenuVisibility(true);
			FadePanelUI.FadeIn();
		}

		private void StartGameState()
		{
			ResetAll();
			ChangeState(GameState.GamePlay);
		}

		private void GamePlayState()
		{
			FadePanelUI.FadeOut();
			HideOverlayPanels();
			MainMenuUI.SetMenuVisibility(false);
			FadePanelUI.FadeIn();
		}

		private void PauseState()
		{
			PausePanelOverlay.SetActive(true);
		}

		private void DeathState()
		{
			FadePanelUI.FadeOut();
			DeathPanelOverlay.SetActive(true);
			MainMenuUI.SetMenuVisibility(true);
			FadePanelUI.FadeIn();
		}

		private void ResetAll()
		{
			var resetables = FindObjectsOfType<MonoBehaviour>().OfType<IResetable>();
			foreach(var resetable in resetables)
			{
				resetable.Reset();
			}
		}

		private void HideOverlayPanels()
		{
			PausePanelOverlay.SetActive(false);
			DeathPanelOverlay.SetActive(false);
		}
		#endregion

		#region Callback(s):
        private void PlayerHealth_OnValueChangedCallback(float _value, StatComponent _statComponent)
        {
            if (_statComponent.CurrentValue > 0f) { return; }

			ChangeState(GameState.Death);
        }
		#endregion
	}
}