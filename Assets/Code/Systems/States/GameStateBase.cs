using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement;

namespace TAMKShooter.Systems.States
{
    public abstract class GameStateBase
    {
        public abstract string sceneName { get; }
        public GameStateType stateType { get; protected set; }
        protected Dictionary<GameStateTransitionType, GameStateType> transitions { get; set; }


        protected GameStateBase()
        {
            transitions = new Dictionary<GameStateTransitionType, GameStateType>();
        }

        public bool AddTransition(GameStateTransitionType transition, GameStateType targetState)
        {
            if (transition == GameStateTransitionType.Error || targetState == GameStateType.Error
                || transitions.ContainsKey(transition))
            {
                return false;
            }

            transitions.Add(transition, targetState);
            return true;
        }

        public bool RemoveTransition(GameStateTransitionType transition)
        {
            return transitions.Remove(transition);
        }

        public GameStateType GetTargetStateType(GameStateTransitionType transition)
        {
            if(transitions.ContainsKey(transition))
            {
                return transitions[transition];
            }

            return GameStateType.Error;
        }

        public virtual void StateActivated()
        {
            if (UnitySceneManager.SceneManager.GetActiveScene().name != sceneName)
            {
                UnitySceneManager.SceneManager.sceneLoaded += HandleSceneLoaded;
                Global.Instance.StartCoroutine(LoadScene());
            }
        }

        public virtual void StateDeactivating()
        {
            Global.Instance.gameManager.RaiseGameStateChangingEvent(stateType);
        }

        private void HandleSceneLoaded(UnitySceneManager.Scene scene, UnitySceneManager.LoadSceneMode loadMode)
        {
            if (scene == UnitySceneManager.SceneManager.GetSceneByName(sceneName))
            {
                UnitySceneManager.SceneManager.sceneLoaded -= HandleSceneLoaded;
                Global.Instance.gameManager.RaiseGameStateChangedEvent(stateType);
            }
        }

        private IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(5);

            UnitySceneManager.SceneManager.LoadScene(sceneName);
        }
    }
}
