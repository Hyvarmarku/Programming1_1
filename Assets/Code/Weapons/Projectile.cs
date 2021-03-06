﻿using UnityEngine;
using TAMKShooter.Utility;
using TAMKShooter.Systems;

namespace TAMKShooter
{
    public class Projectile : MonoBehaviour
    {
        public enum ProjectileType
        {
            None = 0,
            Laser = 1,
            Explosive = 2,
            Missile = 3
        }

        [SerializeField]
        private float _shootingForce;
        [SerializeField]
        private int _damage;
        [SerializeField]
        private ProjectileType _projectileType;

        private IShooter _shooter;

        public Rigidbody rigidBody { get; private set;}

        public ProjectileType type { get { return _projectileType; } }

        protected virtual void Awake()
        {
            rigidBody = gameObject.GetOrAddComponent<Rigidbody>();
        }

        protected void OnCollisionEnter(Collision col)
        {
            IHealth damageReceiver = col.gameObject.GetComponentInChildren<IHealth>();

            if (damageReceiver != null)
            {
                damageReceiver.TakeDamage(_damage);
                _shooter.ProjectileHit(this);
            }
        }

        protected void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
            {
                _shooter.ProjectileHit(this);

            }
        }

        public void Shoot(IShooter shooter, Vector3 direction)
        {
            _shooter = shooter;
            rigidBody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }
}
