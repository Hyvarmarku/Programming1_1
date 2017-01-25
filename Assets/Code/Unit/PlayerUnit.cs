using System;
using UnityEngine;

namespace TAMKShooter
{
    public class PlayerUnit : UnitBase
    {
        public override int projectileLayer
        {
            get
            {
                return LayerMask.NameToLayer("PlayerProjectile");
            }
        }

        protected override void Die()
        {
            // TODO: Handle dying properly.
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
