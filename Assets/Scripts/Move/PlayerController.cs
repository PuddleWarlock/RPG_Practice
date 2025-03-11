using UnityEngine;

namespace Move
{
    public class PlayerController : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private InputSystem_Actions _inputSystem;
        private CharacterController _controller;
        public Animator _animator { get; private set; }
        [SerializeField] private Camera _camera;
    
        private IPlayerState _currentState;

        public Vector2 MoveInput {get; private set;}
        public bool JumpInput {get; private set;}
        public bool SprintInput {get; private set;}
        public bool AttackInput {get; private set;}
        public bool IsGrounded { get; private set;}

        [SerializeField] public float moveSpeed = 10f;
        [SerializeField] private float _velocityVertical = 0f;
        [SerializeField] private float _jumpForce;

        private float _groundCheckDistance;
        private void Awake()
        {
            _inputSystem = new InputSystem_Actions();
            _inputSystem.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
            _inputSystem.Player.Move.canceled += ctx => MoveInput = Vector2.zero;
            _inputSystem.Player.Jump.performed += ctx => JumpInput = true;
            _inputSystem.Player.Jump.canceled += ctx => JumpInput = false;
            _inputSystem.Player.Sprint.performed += ctx => SprintInput = true;
            _inputSystem.Player.Sprint.canceled += ctx => SprintInput = false;
            _inputSystem.Player.Attack.performed += ctx => AttackInput = true;
            _inputSystem.Player.Attack.canceled += ctx => AttackInput = false;
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _inputSystem.Enable();
        }

        private void Start()
        {
            ChangeState(new IdleState());
            _groundCheckDistance = (_controller.height / 2) + .1f;
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

        private void Update()
        {
            ApplyGravity();
            CheckGround();
            _currentState.Execute(this);
        }

        public void ChangeState(IPlayerState newState)
        {
            _currentState?.Exit(this);
            _currentState = newState;
            _currentState.Enter(this); 
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

        public void DoAttack()
        {
            _animator.SetTrigger(Attack);
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