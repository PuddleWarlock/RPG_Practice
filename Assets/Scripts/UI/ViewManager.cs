using System.Collections.Generic;
using UnityEngine;

namespace UI
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
    }
}