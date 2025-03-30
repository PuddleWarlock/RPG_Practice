using System;
using UnityEngine;
using DG.Tweening;
using Fight;
using UnityEngine.UI;

namespace UI
{
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private Image _hpFront;
        [SerializeField] private Image _hpMiddle;

        public void Init(HealthSystem healthSystem)
        {
            _healthSystem = healthSystem;
            _healthSystem.onHealthChanged.AddListener(ChangeHp);
        }

        private void Start()
        {
            if(_healthSystem) _healthSystem.onHealthChanged.AddListener(ChangeHp);
        }

        private void ChangeHp(float hp, float maxHp)
        {
            float percent = Mathf.Clamp(hp / maxHp, 0f, 1f);
            _hpFront.fillAmount = percent;
            _hpMiddle.DOFillAmount(percent, .9f);
        }
    }
}