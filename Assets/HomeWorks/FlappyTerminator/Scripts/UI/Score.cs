using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace HomeWorks.FlappyTerminator.Scripts.UI
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Bird.Bird _bird;

        [SerializeField] private TMP_Text _view;

        private int _score;

        private void OnEnable()
        {
            _bird.ScoreChanged += OnScoreChanged;
            _bird.Reset += OnScoreChanged;
        }

        private void OnDisable()
        {
            _bird.ScoreChanged -= OnScoreChanged;
            _bird.Reset -= OnScoreChanged;
        }

        private void OnScoreChanged() =>
            _score++;

        private void OnResetScore() =>
            _score = 0;

        private void UpdateView() =>
            _view.text = _score.ToString();
    }
}