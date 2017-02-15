using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Systems.States;

namespace TAMKShooter.Systems
{
    public abstract class SceneManager : MonoBehaviour
    {
        private GameStateBase _associatedState;

        public abstract GameStateType stateType { get; }
        public virtual GameStateBase associatedState
        {
            get
            {
                if (_associatedState == null)
                {
                    _associatedState = Global.Instance.gameManager.GetStateByStateType(stateType);
                }
                return _associatedState;
            }
        }
    }
}