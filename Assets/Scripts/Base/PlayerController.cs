using Fight;
using Move;
using StateMachines;
using UnityEngine;

namespace Base
{
    public class PlayerController : MonoBehaviour
    {
        private StateMachine _moveStateMachine;
        private StateMachine _fightStateMachine;
        private InputSystem_Actions _inputSystem;
        private CooldownSystem _cooldownSystem;
        private CharacterController _controller;
        [HideInInspector] public PlayerAnimator _playerAnimator;
        
        [SerializeField] private Camera _camera;
        
        public Vector2 MoveInput {get; private set;}
        public bool JumpInput {get; private set;}
        public bool SprintInput {get; private set;}
        public bool MeleeInput {get; private set;}
        public bool SpellInput { get; private set; }
        public bool IsGrounded { get; private set;}

        [SerializeField] public float moveSpeed = 10f;
        [SerializeField] private float _velocityVertical = 0f;
        [SerializeField] private float _jumpForce;

        private float _groundCheckDistance;
        private void Awake()
        {
            _cooldownSystem = new CooldownSystem();
            _inputSystem = new InputSystem_Actions();
            _moveStateMachine = new StateMachine();
            _fightStateMachine = new StateMachine();
            
            
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
            
            
            _controller = GetComponent<CharacterController>();
            _playerAnimator = GetComponent<PlayerAnimator>();
        }

        private void OnEnable()
        {
            
            _inputSystem.Enable();
        }

        private void Start()
        {
            _groundCheckDistance = (_controller.height / 2) + .1f;

            AttackStatesInit();
            MoveStatesInit();
        }

        private void Update()
        {
            _cooldownSystem.Tick();
            _fightStateMachine.Tick();
            _moveStateMachine.Tick();
            ApplyGravity();
            CheckGround();
        }

        private void AttackStatesInit()
        {
            var attackState = new AttackState(this,_cooldownSystem);
            var spellState = new SpellState(this,_cooldownSystem);
            var idleAttackState = new IdleAttackState(this);
            
            
            bool MeleeAnimationEnded() => _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.99f &&
                                     _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).IsName("Attack");
            bool SpellAnimationEnded() => _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.99f &&
                                     _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).IsName("Spell");
            
            
            
            _fightStateMachine.AddTransition(idleAttackState,attackState, () => MeleeInput && _cooldownSystem.MeleeReady);
            _fightStateMachine.AddTransition(attackState,idleAttackState, MeleeAnimationEnded);
            _fightStateMachine.AddTransition(idleAttackState,spellState, () => SpellInput && _cooldownSystem.SpellReady);
            _fightStateMachine.AddTransition(spellState,idleAttackState, SpellAnimationEnded);
            
            _fightStateMachine.SetState(idleAttackState);
            
        }

        private void MoveStatesInit()
        {
            var idleState = new IdleState(this);
            var jumpingState = new JumpingState(this);
            var walkingState = new WalkingState(this);
            var sprintingState = new SprintingState(this);


            _moveStateMachine.AddTransition(jumpingState, idleState, () => IsGrounded);
            _moveStateMachine.AddTransition(idleState, walkingState, () => MoveInput != Vector2.zero);
            _moveStateMachine.AddTransition(idleState, sprintingState, () => SprintInput);
            _moveStateMachine.AddTransition(walkingState, idleState, () => MoveInput == Vector2.zero);
            _moveStateMachine.AddTransition(walkingState, sprintingState, () => SprintInput);
            _moveStateMachine.AddTransition(sprintingState,walkingState, () => !SprintInput);
            _moveStateMachine.AddAnyTransition(jumpingState, () => JumpInput);
            
            _moveStateMachine.SetState(idleState);
        }

        private void ApplyGravity()
        {
            if (!_controller.isGrounded)
            {
                _velocityVertical -= 15f * Time.deltaTime;
                _controller.Move(Vector3.up * (_velocityVertical * Time.deltaTime));
            }
            else
            {
                _velocityVertical = 0;
            }
        }


        public void Move()
        {
            Vector3 forwardDirection = _camera.transform.forward;
            Vector3 rightDirection = _camera.transform.right;
            forwardDirection.y = 0;
            rightDirection.y = 0;
            Vector3 moveDirection = forwardDirection.normalized * MoveInput.y + rightDirection.normalized * MoveInput.x;

            if (MoveInput != Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.1f);
            }
        
            _controller.Move(moveDirection * (Time.deltaTime * moveSpeed));
        }
    
        public void Jump()
        {
            _velocityVertical = _jumpForce;
            _controller.Move(Vector3.up * (_velocityVertical * Time.deltaTime));
    
        }
        

        private void CheckGround()
        {
            IsGrounded = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance, LayerMask.GetMask("Ground"));
        }
    
        private void OnDisable()
        {
            _inputSystem.Disable();
        }
    }
}