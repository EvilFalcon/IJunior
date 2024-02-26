using UnityEngine;
using UnityEngine.Serialization;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [FormerlySerializedAs("_enemyGenerator")] [SerializeField] private Generator _generator;
    
    [SerializeField] private Form _startForm;
    [SerializeField] private Form _gameOverForm;

    private void OnEnable()
    {
        _startForm.ButtonClick += OnPlayButtonClick;
        _gameOverForm.ButtonClick += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startForm.ButtonClick -= OnPlayButtonClick;
        _gameOverForm.ButtonClick -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
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

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverForm.Open();
        _generator.Disable();
    }
}
