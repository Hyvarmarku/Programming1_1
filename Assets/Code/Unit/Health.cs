using System;
using UnityEngine;


namespace TAMKShooter
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private int health;

        public int currentHealth
        {
            get{ return health; }
            set
            {
                health = Mathf.Clamp(value, 0, value);
                if (HealthChanged != null)
                {
                    HealthChanged(this, new HealthChangedEventArgs(health));
                }
            }
        }

        public event HealthChangedDelegate HealthChanged;

        public bool TakeDamage(int damage)
        {
            currentHealth -= damage;
            return currentHealth == 0;
        }
    }
}
