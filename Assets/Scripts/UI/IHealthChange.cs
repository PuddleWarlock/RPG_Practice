using UnityEngine.Events;

namespace UI
{
    public interface IHealthChange
    {
        public UnityEvent<float, float> onHealthChanged {get;}
    }
}