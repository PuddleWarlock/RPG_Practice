using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Views;

namespace Controllers.UI
{
    public class ViewManager : MonoBehaviour
    {
        [SerializeField] private List<View> _views = new();
        
        public T GetView<T>()
        {
            foreach (var view in _views)
            {
                if (view is T t)
                {
                    return t;
                }
            }

            Debug.LogError($"View of type {typeof(T)} not found");
            return default;
        }

        public void SwitchViews<T,T1>(T from, T1 to) where T : View where T1 : View
        {
            from.Hide();
            to.Show();
        }
        
        
        
        
    }
}