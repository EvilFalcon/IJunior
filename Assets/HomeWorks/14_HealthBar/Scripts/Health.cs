using System;
using UnityEngine;

namespace HomeWorks._14_HealthBar.Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _max;

        private float _currentValue;
        private float _min = 0;

        public float Max => _max;

        public float CurrentValue
        {
            get => _currentValue;
            private set => _currentValue = Math.Clamp(value, _min, Max);
        }

        public event Action Changed;

        private void Awake()
        {
            _currentValue = Max;
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
                return;

            CurrentValue -= damage;
            Changed?.Invoke();
        }

        public void Heal(float value)
        {
            if (value <= 0)
                return;

            CurrentValue += value;
            Changed?.Invoke();
        }
    }
}