using UnityEngine;
using UnityEngine.Events;

namespace Views
{
    public abstract class View : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
            onShow.Invoke();
        }

        public UnityEvent onShow = new();
        public void Hide() => gameObject.SetActive(false);
        
    }
}