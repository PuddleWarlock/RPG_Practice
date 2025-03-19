using System;
using UnityEngine;
using DG.Tweening;
using Fight;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private Image _hpFront;
        [SerializeField] private Image _hpMiddle;

        private void Start()
        {
            _healthSystem.onHealthChanged.AddListener(ChangeHp);
        }

        private void ChangeHp(float hp, float maxHp)
        {
            float percent = Mathf.Clamp(hp / maxHp, 0f, 1f);
            _hpFront.fillAmount = percent;
            _hpMiddle.DOFillAmount(percent, .9f);
        }
    }
}