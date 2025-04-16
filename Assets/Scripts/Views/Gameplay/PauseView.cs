using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Gameplay
{
    public class PauseView : View
    {
        [SerializeField] private Button saveButton;
        // [SerializeField] private Button resumeButton;

        public void SetSaveButtonListener(Action callback)
        {
            saveButton.onClick.AddListener(callback.Invoke);
        }
        
        // public void SetResumeButtonListener(Action callback)
        // {
        //     resumeButton.onClick.AddListener(callback.Invoke);
        // }
    }
}