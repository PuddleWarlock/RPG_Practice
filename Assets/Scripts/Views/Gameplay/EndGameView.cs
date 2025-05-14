using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Gameplay
{
    public class EndGameView : View
    {
        [SerializeField] private Button restartButton;
        
        public void AddRestartButtonListener(Action callback)
        {
            restartButton.onClick.AddListener(callback.Invoke);
        }
    }
}