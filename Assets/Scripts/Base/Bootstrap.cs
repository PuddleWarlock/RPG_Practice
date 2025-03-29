using System;
using UnityEngine;

namespace Base
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 10, Color.red);
        }
    }
}