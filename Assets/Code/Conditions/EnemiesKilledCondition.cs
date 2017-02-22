using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TAMKShooter.Level
{
    public class EnemiesKilledCondition : ConditionBase
    {
        [SerializeField]
        private int _enemiesToKill;
        private int _enemiesKilled = 0;

        protected override void Initialize()
        {
            levelManager.enemyUnits.enemyDestroyed += HandleEnemyDestroyed;
        }

        private void HandleEnemyDestroyed(EnemyUnit obj)
        {
            _enemiesKilled += 1;

            if (_enemiesKilled >= _enemiesToKill)
            {
                isConditionMet = true;
                levelManager.ConditionMet(this);
            }
        }
    }
}
