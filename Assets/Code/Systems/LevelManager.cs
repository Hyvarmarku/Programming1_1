using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TAMKShooter.Data;
using System;
using TAMKShooter.Level;
using TAMKShooter.Systems.States;

namespace TAMKShooter.Systems
{
    public class LevelManager : SceneManager
    {
        private ConditionBase[] _conditions;
        private EnemySpawner[] _enemySpawners;

        public PlayerUnits playerUnits
        {
            get; private set;
        }

        public EnemyUnits enemyUnits
        {
            get; private set;
        }

        public override GameStateType stateType
        {
            get
            {
               return GameStateType.InGameState;
            }
        }

        protected void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            playerUnits = GetComponentInChildren<PlayerUnits>();
            enemyUnits = GetComponentInChildren<EnemyUnits>();
            enemyUnits.Init();

            _enemySpawners = GetComponentsInChildren<EnemySpawner>();
            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.Init(enemyUnits);
            }

            playerUnits.Init(Global.Instance.CurrentGameData.PlayerDatas.ToArray());

            _conditions = GetComponentsInChildren<ConditionBase>();
            foreach (var condition in _conditions)
            {
                condition.Init(this);
            }
        }

        public void ConditionMet(ConditionBase condition)
        {
            bool areConditionsMet = true;
            // LINQ test
            var conditionMet = _conditions.FirstOrDefault(b => b.isActiveAndEnabled == false);

            foreach (ConditionBase c in _conditions)
            {
                if (!c.isConditionMet)
                {
                    areConditionsMet = false;
                    break;
                }
            }

            if (areConditionsMet)
            {
                (associatedState as GameState).LevelCompleted();
            }
        }
    }
}