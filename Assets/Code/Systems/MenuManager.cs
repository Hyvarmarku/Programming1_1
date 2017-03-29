using System;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.GUI;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class MenuManager : SceneManager
    {
        private LoadWindow _loadWindow;
        private PlayerSettings _playerSettingsWindow;

        public override GameStateType stateType
        {
            get
            {
                return GameStateType.MenuState;
            }
        }

        private void Awake()
        {
            _loadWindow = GetComponentInChildren<LoadWindow>(true);
            _loadWindow.Init(this);
            _loadWindow.Close();
            _playerSettingsWindow = GetComponentInChildren<PlayerSettings>(true);
            _playerSettingsWindow.Init(this);
            _playerSettingsWindow.Close();
        }

        public void StartGame(List<PlayerData> playerDatas)
        {
            _playerSettingsWindow.Close();
            Global.Instance.CurrentGameData = new GameData()
            {
                Level = 1,
                PlayerDatas = playerDatas
            };

            Global.Instance.gameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }

        public void OpenStartGameWindow()
        {
            _playerSettingsWindow.Open();
        }

        public void OpenLoadWindow()
        {
            _loadWindow.Open();
        }

        public void LoadGame(string saveFileName)
        {
            _loadWindow.Close();

            GameData loadData = Global.Instance.SaveManager.Load(saveFileName);
            Global.Instance.CurrentGameData = loadData;
            Global.Instance.gameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
