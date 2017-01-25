using UnityEngine;
using TAMKShooter.Utility;

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

        private Rigidbody _rigidBody;

        protected virtual void Awake()
        {
            _rigidBody = gameObject.GetOrAddComponent<Rigidbody>();
        }

        protected void OnCollisionEnter(Collision col)
        {
            IHealth damageReceiver = col.gameObject.GetComponentInChildren<IHealth>();

            if (damageReceiver != null)
            {
                damageReceiver.TakeDamage(_damage);

                // TODO: Instantiate effect
                Destroy(gameObject);
            }
        }

        public void Shoot(Vector3 direction)
        {
            _rigidBody.AddForce(direction * _shootingForce, ForceMode.Impulse);
        }
    }
}
