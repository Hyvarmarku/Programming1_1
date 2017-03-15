using System;
using System.Collections.Generic;
using TAMKShooter.Data;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class MenuManager : SceneManager
    {
        public override GameStateType stateType
        {
            get
            {
                return GameStateType.MenuState;
            }
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
        public void LoadGame()
        {
            Debug.Log("Load Game");
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
