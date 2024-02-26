using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HomeWorks._11_2DPlatformer.Codebase.Healths.Views
{
    public class ContinuousBarView : MonoBehaviour, IHealthView
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _speed = 1f;

        private Coroutine _routine;

        public void SetMaxValue(float maxValue)
        {
            _slider.maxValue = maxValue;
            _slider.value = maxValue;
        }

        public void ChangeValue(float value)
        {
            if(gameObject.activeSelf == false)
                return;
            
            StopCoroutine();

            _routine = StartCoroutine(UpdateValue(value));
        }

        private IEnumerator UpdateValue(float targetValue)
        {
            while (Math.Abs(_slider.value - targetValue) > Mathf.Epsilon)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);

                yield return null;
            }
        }

        private void StopCoroutine()
        {
            if (_routine != null)
            {
                StopCoroutine(_routine);
            }
        }
    }
}
