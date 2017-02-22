using System.Collections;
using System.Collections.Generic;
using TAMKShooter.Systems;
using UnityEngine;

namespace TAMKShooter.Level
{
    public abstract class ConditionBase : MonoBehaviour
    {
        public LevelManager levelManager { get; private set; }
        public bool isConditionMet { get; protected set; }

        public void Init(LevelManager levelManager)
        {
            this.levelManager = levelManager;
            Initialize();
        }

        protected abstract void Initialize();
    }
}
