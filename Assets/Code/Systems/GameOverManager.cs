using System;
using System.Collections.Generic;
using TAMKShooter.Data;
using TAMKShooter.GUI;
using UnityEngine;

namespace TAMKShooter.Systems
{
    public class GameOverManager : SceneManager
    {
        private LoadWindow _loadWindow;
        private PlayerSettings _playerSettingsWindow;

        public override GameStateType stateType
        { get { return GameStateType.GameOverState; } }

        public void BackToMenu()
        {
            Global.Instance.gameManager.PerformTransition(GameStateTransitionType.GameOverToMenu);
        }
    }
}
