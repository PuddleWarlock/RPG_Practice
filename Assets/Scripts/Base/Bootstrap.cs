using UnityEngine;

namespace Base
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}