using UnityEngine;

namespace HomeWorks._14_HealthBar.Scripts
{
    [RequireComponent(typeof(Health))]
    public class Bar : MonoBehaviour
    {
        [SerializeField] private SmoothSlider _slider;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Start()
        {
            OnHealthChanged();
        }

        private void OnEnable()
        {
            _health.Changed += OnHealthChanged;
            _slider.Show();
        }

        private void OnDisable()
        {
            _slider.Hide();
            _health.Changed -= OnHealthChanged;
        }

        public void OnHealthChanged()
        {
            float value = _health.CurrentValue / _health.Max;
            _slider.Change(value);
        }
    }
}
