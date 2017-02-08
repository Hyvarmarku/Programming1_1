using System;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter
{
    public class EnemyUnits : MonoBehaviour
    {
        public event Action<EnemyUnit> enemyDestroyed;

        public void EnemyDied(EnemyUnit enemyUnit)
        {
            if (enemyDestroyed != null)
            {
                enemyDestroyed(enemyUnit);
            }
        }
    }
}
