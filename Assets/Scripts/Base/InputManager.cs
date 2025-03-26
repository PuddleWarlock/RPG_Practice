using UnityEngine;

namespace Base
{
    public class InputManager : MonoBehaviour
    {
        private InputSystem_Actions _inputSystem;
        
        private static InputManager _instance;
        
        public static InputManager Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = FindAnyObjectByType<InputManager>();
                if (_instance != null) return _instance;
                var go = new GameObject("InputManager");
                _instance = go.AddComponent<InputManager>();

                return _instance;
            }
        }
        
        public Vector2 MoveInput {get; private set;}
        public bool JumpInput {get; private set;}
        public bool SprintInput {get; private set;}
        public bool MeleeInput {get; private set;}
        public bool SpellInput { get; private set; }
        public bool RMBInput { get; private set; }
        public bool IsSheathed { get; private set; }
        

       
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            
            
            _inputSystem = new InputSystem_Actions();
            
            
            _inputSystem.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
            _inputSystem.Player.Move.canceled += ctx => MoveInput = Vector2.zero;
            _inputSystem.Player.Jump.performed += ctx => JumpInput = true;
            _inputSystem.Player.Jump.canceled += ctx => JumpInput = false;
            _inputSystem.Player.Sprint.performed += ctx => SprintInput = true;
            _inputSystem.Player.Sprint.canceled += ctx => SprintInput = false;
            _inputSystem.Player.Attack.performed += ctx => MeleeInput = true;
            _inputSystem.Player.Attack.canceled += ctx => MeleeInput = false;
            _inputSystem.Player.Spell.performed += ctx => SpellInput = true;
            _inputSystem.Player.Spell.canceled += ctx => SpellInput = false;
            _inputSystem.Player.RMB.performed += ctx => RMBInput = true;
            _inputSystem.Player.RMB.canceled += ctx => RMBInput = false;
            _inputSystem.Player.Sheath.performed += ctx => IsSheathed = !IsSheathed;
            //_inputSystem.Player.Sheath.canceled += ctx => SheathInput = false;
            
            
            /*_inputSystem.Player.Newaction.performed += ctx => Debug.Log("New action performed");
            _inputSystem.Player.Newaction.canceled += ctx => Debug.Log("New action canceled");*/

        }
        
        private void OnEnable()
        {
            _inputSystem.Enable();
        }
        
        
    
        private void OnDisable()
        {
            _inputSystem.Disable();
        }
    }
}