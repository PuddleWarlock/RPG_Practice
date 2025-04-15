using UnityEngine.Events;

namespace Controllers.Entities.HealthController.Interfaces
{
    public interface IHittable
    {
        public UnityEvent onHit { get; }
    }
}