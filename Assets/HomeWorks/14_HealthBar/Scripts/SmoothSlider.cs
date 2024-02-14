using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HealthBar
{
    [RequireComponent(typeof(Slider))]
    public class SmoothSlider : MonoBehaviour
    {
        [SerializeField] private float _time = 0.5f;

        private Slider _slider;
        private Coroutine _coroutine;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void Change(float value)
        {
            StopCoroutine();
            _coroutine = StartCoroutine(ChangeValue(value));
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void StopCoroutine()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private IEnumerator ChangeValue(float value)
        {
            while (Mathf.Abs(_slider.value - value) > Mathf.Epsilon)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, value, _time * Time.deltaTime);

                yield return null;
            }
        }
    }
}
