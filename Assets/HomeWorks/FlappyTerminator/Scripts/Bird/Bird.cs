using System;
using UnityEngine;

namespace HomeWorks.FlappyTerminator.Scripts.Bird
{
    [RequireComponent(typeof(BirdMover))]
    public class Bird : MonoBehaviour
    {
        private BirdMover _mover;
        private int _score;

        public event Action Died;
        public event Action ScoreChanged;
        public event Action Reset;

        private void Start()
        {
            _mover = GetComponent<BirdMover>();
        }

        public void IncreaseScore()
        {
            _score++;
            ScoreChanged?.Invoke();
        }
    
        public void ResetPlayer()
        {
            _score = 0;
            ScoreChanged?.Invoke();
            _mover.ResetBird();
        }

        public void Die()
        {
            Died?.Invoke();
            Reset?.Invoke();
        }
    }
}
