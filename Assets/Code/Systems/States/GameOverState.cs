using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter.Systems.States
{
    public class GameOverState : GameStateBase
    {
        public override string sceneName
        {
            get
            {
                return Configs.Config.GameOverSceneName;
            }
        }

        public GameOverState()
        {
            stateType = GameStateType.GameOverState;
            AddTransition(GameStateTransitionType.GameOverToMenu, GameStateType.MenuState);
        }
    }
}
