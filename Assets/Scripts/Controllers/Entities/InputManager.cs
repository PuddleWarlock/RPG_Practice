using UnityEngine;

namespace Controllers.Entities
{   
    public class InputManager : MonoBehaviour
    {   
        // private bool _isPaused;
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

        #region PlayerInput

        public Vector2 MoveInput {get; private set;}
                public bool JumpInput {get; private set;}
                public bool SprintInput {get; private set;}
                public bool MeleeInput {get; private set;}
                public bool SpellInput { get; private set; }
                public bool RMBInput { get; private set; }
                public bool IsSheathed { get; private set; }

        #endregion

        #region GameInput

        public bool MenuInput { get; private set; }

        #endregion
        
        // // Метод для установки состояния паузы
        // public void SetPaused(bool isPaused)
        // {
        //     _isPaused = isPaused;
        //     // Сбрасываем игровой ввод при паузе
        //     if (_isPaused)
        //     {
        //         MoveInput = Vector2.zero;
        //         JumpInput = false;
        //         SprintInput = false;
        //         MeleeInput = false;
        //         SpellInput = false;
        //         RMBInput = false;
        //         
        //     }
        // }
        
        // // Метод для явного сброса MenuInput
        // public void ResetMenuInput()
        // {
        //     MenuInput = false;
        // }
        
        private void Awake()
        {
            _inputSystem = new InputSystem_Actions();
            
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                // DontDestroyOnLoad(gameObject);
            }


            PlayerActionsInit();
            GameActionsInit();
        }



        private void PlayerActionsInit()
        {
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
        }
        
        // private void PlayerActionsInit()
        // {
        //     _inputSystem.Player.Move.performed += ctx =>
        //     {
        //         if (!_isPaused) MoveInput = ctx.ReadValue<Vector2>(); };
        //     _inputSystem.Player.Move.canceled += ctx => { if (!_isPaused) MoveInput = Vector2.zero; };
        //     _inputSystem.Player.Jump.performed += ctx => { if (!_isPaused) JumpInput = true; };
        //     _inputSystem.Player.Jump.canceled += ctx => { if (!_isPaused) JumpInput = false; };
        //     _inputSystem.Player.Sprint.performed += ctx => { if (!_isPaused) SprintInput = true; };
        //     _inputSystem.Player.Sprint.canceled += ctx => { if (!_isPaused) SprintInput = false; };
        //     _inputSystem.Player.Attack.performed += ctx => { if (!_isPaused) MeleeInput = true; };
        //     _inputSystem.Player.Attack.canceled += ctx => { if (!_isPaused) MeleeInput = false; };
        //     _inputSystem.Player.Spell.performed += ctx => { if (!_isPaused) SpellInput = true; };
        //     _inputSystem.Player.Spell.canceled += ctx => { if (!_isPaused) SpellInput = false; };
        //     _inputSystem.Player.RMB.performed += ctx =>{ if (!_isPaused)  RMBInput = true; };
        //     _inputSystem.Player.RMB.canceled += ctx => { if (!_isPaused) RMBInput = false; };
        //     _inputSystem.Player.Sheath.performed += ctx => { if (!_isPaused) IsSheathed = !IsSheathed; };
        // }
        
        private void GameActionsInit()
        {
            _inputSystem.Game.Menu.performed += ctx => MenuInput = !MenuInput;
        }
        
        // private void GameActionsInit()
        // {
        //     _inputSystem.Game.Menu.performed += ctx => MenuInput = true;
        //     _inputSystem.Game.Menu.canceled += ctx => MenuInput = false;
        // }

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