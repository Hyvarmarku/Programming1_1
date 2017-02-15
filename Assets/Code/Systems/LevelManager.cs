using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Data;
using System;

namespace TAMKShooter.Systems
{
    public class LevelManager : SceneManager
    {
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

            playerUnits.Init(pd1,pd2);
        }
    }
}