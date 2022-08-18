// ######################################################################
// GameManager - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using System;
using UnityEngine;
using Project.Utility;
using System.Collections.Generic;

namespace Project
{
    public class GameManager : PersistentSinglonMonoBehaviour<GameManager>
	{
		#region Delegate(s):
		public event Action<GameState> OnGameStateChangedEvent;
		#endregion

		#region Inspector Assigned Field(s):
		[field: SerializeField] public AudioSource OneShotAudioSource { get; private set; }
		[field: SerializeField] public CameraSystem.CameraTools CameraTools { get; private set; }
		[field: SerializeField] public UI.FadePanelUI FadePanelUI { get; private set; }
		[field: SerializeField] public GameObject PausePanelOverlay { get; private set; }
		[field: SerializeField] public GameObject DeathPanelOverlay { get; private set; }
		[field: SerializeField] public GameObject WinPanelOverlay { get; private set; }
		#endregion

		#region Properties:
		public GameState CurrentState { get; private set; } = GameState.Unset;
		private Dictionary<GameState, GameStateBehaviour> m_gameStateBehaviourDictionary;
        #endregion

        #region MonoBehaviour Callback Method(s):
        protected override void Awake()
        {
            base.Awake();
			CreateGameStateBehaviourDictionary();
        }
        private void Start() => ChangeGameState(GameState.MainMenu);
		#endregion

		#region Public API:
		public void ChangeGameState(GameState _newGameState)
		{
			if (_newGameState == CurrentState || !m_gameStateBehaviourDictionary.ContainsKey(_newGameState)) { return; }
			CurrentState = _newGameState;
			m_gameStateBehaviourDictionary[CurrentState].Perform();
			OnGameStateChangedEvent?.Invoke(_newGameState);
		}
		#endregion

		#region Internally Used Method(s):
		private void CreateGameStateBehaviourDictionary()
		{
			m_gameStateBehaviourDictionary = new Dictionary<GameState, GameStateBehaviour>()
			{
				{ GameState.MainMenu, new BasicLoadSceneGameStateBehaviour(SceneName.MenuScene, HideOverlayPanels) }, 
				{ GameState.GamePlay, new BasicLoadSceneGameStateBehaviour(SceneName.GamePlayScene, HideOverlayPanels) }, 
				{ GameState.Death, new CoroutineLoadSceneGameStateBehaviour(SceneName.MenuScene, DeathPanelOverlay) }, 
				{ GameState.Win, new CoroutineLoadSceneGameStateBehaviour(SceneName.MenuScene, WinPanelOverlay) },
				{ GameState.Pause, new PauseGameStateBehaviour() }, 
			};

			void HideOverlayPanels()
			{
				PausePanelOverlay.SetActive(false);
				DeathPanelOverlay.SetActive(false);
				WinPanelOverlay.SetActive(false);
			}
		}
		#endregion
	}
}