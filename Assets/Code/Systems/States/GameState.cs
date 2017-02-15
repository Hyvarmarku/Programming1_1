using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Configs;

namespace TAMKShooter.Systems.States
{
    public class GameState : GameStateBase
    {
        public int currentLevelIndex { get; private set; }
        public override string sceneName
        {
            get
            {
                try
                {
                    return Config.levelNames[currentLevelIndex];
                }
                catch (KeyNotFoundException exception)
                {
                    Debug.LogException(exception);
                    return null;
                }
            }
        }
        public GameState(int levelIndex) : base()
        {
            stateType = GameStateType.InGameState;
            currentLevelIndex = levelIndex;

            AddTransition(GameStateTransitionType.InGameToGameOver, GameStateType.GameOverState);
            AddTransition(GameStateTransitionType.InGameToMenu, GameStateType.MenuState);
        }

        public GameState() : this(1) { }
    }
}
