using UnityEngine.Events;

namespace Controllers.Entities.HealthController.Interfaces
{
    public interface IHealthChange
    {
        public UnityEvent<float, float> onHealthChanged {get;}
    }
}