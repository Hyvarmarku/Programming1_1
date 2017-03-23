using System;
using System.Collections;
using UnityEngine;


namespace TAMKShooter
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField]
        private int _maxHealth;
        [SerializeField]
        private float _indestructibleTime;
        [SerializeField]
        private float _blinkingSpeed;

        private int _health;
        private bool indestructible = false;
        private float _startTime;
        private float _prevTimeBlinked;

        public int currentHealth
        {
            get{ return _health; }
            set
            {
                _health = Mathf.Clamp(value, 0, value);
                if (HealthChanged != null)
                {
                    HealthChanged(this, new HealthChangedEventArgs(_health));
                }
            }
        }

        public event HealthChangedDelegate HealthChanged;

        public void ResetHealth(bool indestructible)
        {
            this.indestructible = indestructible;
            _health = _maxHealth;
            _startTime = Time.time;
            _prevTimeBlinked = Time.time;

            StartCoroutine(IndestructibleCoroutine());
        }

        public bool TakeDamage(int damage)
        {
            if (!indestructible)
            {
                currentHealth -= damage;
            }
            return currentHealth == 0;
        }

        IEnumerator IndestructibleCoroutine()
        {
            MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            for (float f = 1; f > 0; f -= 0.1f)
            {
                mr.enabled = !mr.enabled;
                yield return new WaitForSeconds(.1f);
            }
            mr.enabled = true;
            indestructible = false;

            StopCoroutine(IndestructibleCoroutine());
        }
    }
}
