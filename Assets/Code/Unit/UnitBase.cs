using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Utility;
using System;

namespace TAMKShooter
{
    public abstract class UnitBase : MonoBehaviour
    {
        #region Properties
        public IHealth health { get; protected set; }
        public IMover mover { get; protected set; }
        public WeaponController weapons { get; protected set;}
        public int bodyDamage = 100;
        #endregion

        #region Public interface
        public void TakeDamage(int amount)
        {
            if (health.TakeDamage(amount))
            {
                Die();
            }
        }
        #endregion

        protected virtual void Die()
        {
            health.HealthChanged -= HealthChanged;
        }

        public abstract int projectileLayer { get; }

        protected void InitRequiredComponents()
        {
            health = gameObject.GetOrAddComponent<Health>();
            mover = gameObject.GetOrAddComponent<Mover>();
            weapons = gameObject.GetComponentInChildren<WeaponController>();

            health.HealthChanged += HealthChanged;
        }

        protected void OnCollisionEnter(Collision col)
        {
            GameObject go = col.gameObject;

            if (go.layer == LayerMask.NameToLayer("Enemy") || go.layer == LayerMask.NameToLayer("Player"))
            {
                health.TakeDamage(bodyDamage);
            }
        }

        private void HealthChanged(object sender, HealthChangedEventArgs args)
        {
            if (args.currentHealth <= 0)
            {
                Die();
            }
        }
    }
}