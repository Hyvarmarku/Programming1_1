using System;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Configs;

namespace TAMKShooter
{
    public class EnemyUnit : UnitBase
    {
        public EnemyUnits enemyUnits{ get; private set;}

        public override int projectileLayer
        {
            get
            {
                return LayerMask.NameToLayer(Config.EnemyProjectileLayerName);
            }
        }

        public void Init(EnemyUnits enemyUnits)
        {
            this.enemyUnits = enemyUnits;
        }

        protected override void Die()
        {
            // Sounds, explosions
            base.Die();
            gameObject.SetActive(false);
            enemyUnits.EnemyDied(this);
        }
    }
}
