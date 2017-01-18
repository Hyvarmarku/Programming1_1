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

        public enum UnitType
        {
            None = 0,
            Fast = 1,
            Balanced = 3,
            Heavy = 4
        }
    }
}
