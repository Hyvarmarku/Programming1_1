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
        }

        public void StartGame()
        {
            Global.Instance.CurrentGameData = new GameData()
            {
                Level = 1,
                PlayerDatas = new List<PlayerData>()
                {
                    new PlayerData()
                    {
                        controllerType = PlayerData.ControllerType.WASD,
                        lives = 3,
                        playerId = PlayerData.PlayerId.Player1,
                        unitType = PlayerUnit.UnitType.Heavy
                    },
                    new PlayerData()
                    {
                        controllerType = PlayerData.ControllerType.Arrow,
                        lives = 3,
                        playerId = PlayerData.PlayerId.Player2,
                        unitType = PlayerUnit.UnitType.Balanced
                    }
                }
            };

            Global.Instance.gameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
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
