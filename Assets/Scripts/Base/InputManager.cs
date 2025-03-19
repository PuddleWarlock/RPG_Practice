using Fight;
using Move;
using StateMachines;
using UnityEngine;

namespace Base
{
    public class InputManager : MonoBehaviour
    {
        private InputSystem_Actions _inputSystem;
        
        public Vector2 MoveInput {get; private set;}
        public bool JumpInput {get; private set;}
        public bool SprintInput {get; private set;}
        public bool MeleeInput {get; private set;}
        public bool SpellInput { get; private set; }

       
        
        private void Awake()
        {
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