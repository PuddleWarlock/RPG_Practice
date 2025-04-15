using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.MainMenu
{
    public class SettingsView : View
    {
        [SerializeField] private Slider _enemiesPower;
        [SerializeField] private Button _goBackButton;
        public void SetSliderValue(float value)
        {
            _enemiesPower.value = value;
        }
        
        public void SetSliderListener(Action<float> callback)
        {
            _enemiesPower.onValueChanged.AddListener(callback.Invoke);
        }

        public void SetBackButtonListener(Action callback)
        {
            _goBackButton.onClick.AddListener(callback.Invoke);
        }
    }
}