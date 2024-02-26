using HomeWorks._11_2DPlatformer.Codebase.Healths.Model;
using HomeWorks._11_2DPlatformer.Codebase.Healths.Views;

namespace HomeWorks._11_2DPlatformer.Codebase.Healths.Presenter
{
    public class HealthPresenter
    {
        private readonly Health _health;
        private readonly IHealthView _healthView;

        public HealthPresenter(Health health, IHealthView healthView)
        {
            _health = health;
            _healthView = healthView;
        }
        
        public float Current => _health.Current;

        public void Enable()
        {
            _health.OnHealthChanged += OnHealthChanged;
            _healthView.SetMaxValue(_health.Max);
        }

        public void Disable()
        {
            _health.OnHealthChanged -= OnHealthChanged;
        }
        
        public void RestoreHealth(float heal)
        {
            _health.RestoreHealth(heal);
        }
        
        public void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);
        }

        private void OnHealthChanged()
        {
            _healthView.ChangeValue(_health.Current);
        }
    }
}
