using UnityEngine;
using TAMKShooter.Configs;
using TAMKShooter.WaypointSystem;

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

        private IPathUser _pathUser;

        public void Init(EnemyUnits enemyUnits, Path path)
        {
            InitRequiredComponents();
            this.enemyUnits = enemyUnits;
            _pathUser = gameObject.AddComponent<PathUser>();
            _pathUser.Init(mover,path);
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
