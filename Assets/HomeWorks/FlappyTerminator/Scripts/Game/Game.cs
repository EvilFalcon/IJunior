using HomeWorks.FlappyTerminator.Scripts.Enemys;
using HomeWorks.FlappyTerminator.Scripts.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace HomeWorks.FlappyTerminator.Scripts.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Bird.Bird _bird;
        [FormerlySerializedAs("_enemyGenerator")] [SerializeField] private Generator _generator;
    
        [SerializeField] private Form _startForm;
        [SerializeField] private Form _gameOverForm;

        private void OnEnable()
        {
            _startForm.ButtonClick += OnPlayButtonClick;
            _gameOverForm.ButtonClick += OnRestartButtonClick;
            _bird.Died += OnDied;
        }

        private void OnDisable()
        {
            _startForm.ButtonClick -= OnPlayButtonClick;
            _gameOverForm.ButtonClick -= OnRestartButtonClick;
            _bird.Died -= OnDied;
        }

        private void Start()
        {
            _startForm.Close();
            _gameOverForm.Close();
        
            Time.timeScale = 0;
            _startForm.Open();
        }

        private void OnPlayButtonClick()
        {
            _startForm.Close();
            StartGame();
        }

        private void OnRestartButtonClick()
        {
            _gameOverForm.Close();
            _generator.ResetPool();
            StartGame();
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            _bird.ResetPlayer();
            _generator.Enable();
        }

        private void OnDied()
        {
            Time.timeScale = 0;
            _gameOverForm.Open();
            _generator.Disable();
        }
    }
}
