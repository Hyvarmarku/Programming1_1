using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Systems.States;

namespace TAMKShooter.Systems
{
    public enum GameStateType
    {
        Error = -1,
        MenuState,
        InGameState,
        GameOverState
    }

    public enum GameStateTransitionType
    {
        Error = -1,
        MenuToInGame,
        InGameToMenu,
        InGameToGameOver,
        GameOverToMenu,
        InGameToInGame
    }

    public class GameManager : MonoBehaviour
    {
        private readonly List<GameStateBase> _states = new List<GameStateBase>();

        public event System.Action<GameStateType> GameStateChanging;
        public event System.Action<GameStateType> GameStateChanged;

        public SceneManager currentSceneManager { get; private set; }
        public GameStateBase currentState { get; private set; }
        public GameStateType currentStateType { get { return currentState.stateType; } }

        public void Init()
        {
            MenuState startingState = new MenuState();

            AddState(startingState);
            AddState(new GameState());

            currentState = startingState;
        }

        public bool AddState(GameStateBase state)
        {
            bool exists = false;

            foreach (var s in _states)
            {
                if (s.stateType == state.stateType)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _states.Add(state);
            }

            return !exists;
        }

        public bool RemoveState(GameStateType stateType)
        {
            GameStateBase state = null;

            foreach (var s in _states)
            {
                if (s.stateType == stateType)
                {
                    state = s;
                }
            }

            return state != null && _states.Remove(state);
        }

        public bool PerformTransition(GameStateTransitionType transition)
        {
            GameStateType targetStateType = currentState.GetTargetStateType(transition);

            if (targetStateType == GameStateType.Error)
            {
                return false;
            }

            foreach (var state in _states)
            {
                if (state.stateType == targetStateType)
                {
                    currentState.StateDeactivating();
                    currentState = state;
                    currentState.StateActivated();

                    return true;
                }
            }

            return false;
        }

        public void RaiseGameStateChangingEvent(GameStateType stateType)
        {
            if (GameStateChanging != null)
            {
                GameStateChanging(stateType);
            }
        }

        public void RaiseGameStateChangedEvent(GameStateType stateType)
        {
            if (GameStateChanged != null)
            {
                GameStateChanged(stateType);
            }
        }

        public GameStateBase GetStateByStateType(GameStateType stateType)
        {
            foreach (var s in _states)
            {
                if (s.stateType == stateType)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
