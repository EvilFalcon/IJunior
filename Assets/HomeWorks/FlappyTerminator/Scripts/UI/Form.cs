using System;
using UnityEngine;
using UnityEngine.UI;

namespace HomeWorks.FlappyTerminator.Scripts.UI
{
    public class Form : MonoBehaviour
    {
        [SerializeField] private Button Button;
        [SerializeField] private GameObject Content;

        public event Action ButtonClick;
    
        private void OnEnable()
        {
            Button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            Button.onClick.RemoveListener(OnButtonClick);
        }
    
        public void Open()
        {
            Content.SetActive(true);
            OnEnable();
        }
    
        public void Close()
        {
            Content.SetActive(false);
            OnDisable();
        }

        private void OnButtonClick()
        {
            ButtonClick?.Invoke();
        }
    }
}
