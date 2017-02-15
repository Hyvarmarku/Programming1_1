using System;
using System.Collections.Generic;
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
