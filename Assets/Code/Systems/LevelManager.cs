﻿using System.Collections;
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

            PlayerData pd1 = new PlayerData()
            {
                playerId = PlayerData.PlayerId.Player1,
                unitType = PlayerUnit.UnitType.Heavy,
                controllerType = PlayerData.ControllerType.WASD,
                lives = 3
            };

            PlayerData pd2 = new PlayerData()
            {
                playerId = PlayerData.PlayerId.Player2,
                unitType = PlayerUnit.UnitType.Balanced,
                controllerType = PlayerData.ControllerType.Arrow,
                lives = 3
            };

            PlayerData pd3 = new PlayerData()
            {
                playerId = PlayerData.PlayerId.Player3,
                unitType = PlayerUnit.UnitType.Balanced,
                controllerType = PlayerData.ControllerType.GamepadOne,
                lives = 3
            };

            PlayerData pd4 = new PlayerData()
            {
                playerId = PlayerData.PlayerId.Player4,
                unitType = PlayerUnit.UnitType.Balanced,
                controllerType = PlayerData.ControllerType.GamepadTwo,
                lives = 3
            };

            playerUnits.Init(pd1,pd2, pd3, pd4);

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