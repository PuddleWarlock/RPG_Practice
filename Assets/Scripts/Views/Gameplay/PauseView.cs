using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Gameplay
{
    public class PauseView : View
    {
        [SerializeField] private Button saveButton;

        public void SetSaveButtonListener(Action callback)
        {
            saveButton.onClick.AddListener(callback.Invoke);
        }
    }
}