using System;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Codebase.Healths.Model
{
    public class Health
    {
        public Health(int max)
        {
            Max = max;
            Current = max;
        }

        public float Current { get; private set; }
        public float Max { get; private set; }
        
        public event Action OnHealthChanged;

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
                return;

            ChangeHealth(-damage);
        }

        public void RestoreHealth(float heal)
        {
            if (heal <= 0)
                return;

            ChangeHealth(heal);
        }

        private void ChangeHealth(float amount)
        {
            Current = Mathf.Clamp(Current + amount, 0, Max);
            OnHealthChanged?.Invoke();
        }
    }
}
