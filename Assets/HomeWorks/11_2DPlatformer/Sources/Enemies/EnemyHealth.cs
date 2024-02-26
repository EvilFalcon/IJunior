using HomeWorks._11_2DPlatformer.Codebase.Healths.Model;
using HomeWorks._11_2DPlatformer.Codebase.Healths.Presenter;
using HomeWorks._11_2DPlatformer.Codebase.Healths.Views;
using UnityEngine;

namespace HomeWorks._11_2DPlatformer.Sources.Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private GameObject _root;
        [SerializeField] private EnemyAnimation _playerAnimation;

        [field: SerializeField] public ContinuousBarView HealthView { get; private set; }

        private HealthPresenter _healthPresenter;
        
        public float Current => _healthPresenter.Current;

        private void Awake()
        {
            Health health = new Health(_maxHealth);

            _healthPresenter = new HealthPresenter(health, HealthView);
            _healthPresenter.Enable();
        }

        public void TakeDamage(float damage)
        {
            _healthPresenter.TakeDamage(damage);
            
            if (_healthPresenter.Current <= 0)
                _root.SetActive(false);
        }
    }
}
