using System;

namespace TAMKShooter
{
    public class HealthChangedEventArgs : EventArgs
    {
        public int currentHealth { get; private set; }

        public HealthChangedEventArgs(int currentHealth)
        {
            this.currentHealth = currentHealth;
        }
    }

    public delegate void HealthChangedDelegate(object sender, HealthChangedEventArgs args);

    public interface IHealth
    {
        int currentHealth { get; set; }

        /// <summary>
        /// Reduces health when called
        /// </summary>
        /// <param name="damage"> Amount of health reduced</param>
        /// <returns>True, if health reaches 0, false otherwise</returns>
        bool TakeDamage(int damage);

        event HealthChangedDelegate HealthChanged;
    }
}
