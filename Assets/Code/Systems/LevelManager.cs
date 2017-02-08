using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Data;

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
    
        protected void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            playerUnits = GetComponentInChildren<PlayerUnits>();
            enemyUnits = GetComponentInChildren<EnemyUnits>();

            enemyUnits.Init();

            PlayerData pd = new PlayerData()
            {
                playerId = PlayerData.PlayerId.Player1,
                unitType = PlayerUnit.UnitType.Heavy,
                lives = 3
            };

            playerUnits.Init(pd);
        }
    }
}