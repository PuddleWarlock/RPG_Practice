using UnityEngine.Events;

namespace Fight
{
    public interface IHittable
    {
        public UnityEvent onHit { get; }
    }
}