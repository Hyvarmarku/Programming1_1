﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMKShooter.Utility;

namespace TAMKShooter
{
    public abstract class UnitBase : MonoBehaviour
    {
        #region Properties
        public IHealth health { get; protected set; }
        public IMover mover { get; protected set; }
        #endregion

        #region Unity messages
        protected virtual void Awake()
        {
            health = gameObject.GetOrAddComponent<Health>();
            mover = gameObject.GetOrAddComponent<Mover>();
        }
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

        #region Abstracts
        protected abstract void Die();
        public abstract int projectileLayer { get; }
        #endregion
    }
}