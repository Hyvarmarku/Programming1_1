using System;
using System.Collections.Generic;
using UnityEngine;

namespace TAMKShooter
{
    public class EnemyUnit : UnitBase
    {
        public EnemyUnits enemyUnits{ get; private set;}

        public override int projectileLayer
        {
            get
            {
                return LayerMask.NameToLayer("EnemyProjectile");
            }
        }

        public void Init(EnemyUnits enemyUnits)
        {
            this.enemyUnits = enemyUnits;
        }

        protected override void Die()
        {
            // Sounds, explosions
            gameObject.SetActive(false);
            enemyUnits.EnemyDied(this);
        }
    }
}
