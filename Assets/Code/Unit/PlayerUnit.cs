using System;
using UnityEngine;
using TAMKShooter.Data;
using TAMKShooter.Configs;

namespace TAMKShooter
{
    public class PlayerUnit : UnitBase
    {

        [SerializeField]
        private UnitType _type;
        public UnitType type
        {
            get { return _type; }
        }
        public PlayerData data { get; private set; }

        public override int projectileLayer
        {
            get
            {
                return LayerMask.NameToLayer(Config.PlayerProjectileLayerName);
            }
        }

        public void Init(PlayerData playerData)
        {
            data = playerData;
        }

        protected override void Die()
        {
            // TODO: Handle dying properly.
            base.Die();
            gameObject.SetActive(false);
        }

        protected void Update()
        {
            UpdateInput();
        }

        private void UpdateInput()
        {
            float dirX = Input.GetAxis("Horizontal");
            float dirZ = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(dirX, 0, dirZ);
            mover.MoveToDirection(direction);

            bool shoot = Input.GetButton("Shoot");

            if (shoot)
            {
                weapons.Shoot(projectileLayer);
            }
        }

        public enum UnitType
        {
            None = 0,
            Fast = 1,
            Balanced = 3,
            Heavy = 4
        }
    }
}
