using Fight;
using StateMachines;
using UnityEngine;

namespace Base
{
    public class FightController : MonoBehaviour
    {
        private InputManager _inputManager;
        private StateMachine _fightStateMachine;
        private PlayerAnimator _playerAnimator;
        private CooldownSystem _cooldownSystem;
        private MovementController _movementController;


        private void Awake()
        {
            _cooldownSystem = new CooldownSystem();
            _fightStateMachine = new StateMachine();
            _inputManager = GetComponent<InputManager>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _movementController = GetComponent<MovementController>();
        }

        private void Start()
        {
            AttackStatesInit();
        }

        private void Update()
        {
            _cooldownSystem.Tick();
            _fightStateMachine.Tick();
        }
        
        private void AttackStatesInit()
        {
            var attackState = new AttackState(_movementController,_cooldownSystem);
            var spellState = new SpellState(_movementController,_cooldownSystem);
            var idleAttackState = new IdleAttackState(_movementController);
            
            
            bool MeleeAnimationEnded() => _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.99f &&
                                          _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).IsName("Attack");
            bool SpellAnimationEnded() => _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.99f &&
                                          _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).IsName("Spell");
            
            
            
            _fightStateMachine.AddTransition(idleAttackState,attackState, () => _inputManager.MeleeInput && _cooldownSystem.MeleeReady);
            _fightStateMachine.AddTransition(attackState,idleAttackState, MeleeAnimationEnded);
            _fightStateMachine.AddTransition(idleAttackState,spellState, () => _inputManager.SpellInput && _cooldownSystem.SpellReady);
            _fightStateMachine.AddTransition(spellState,idleAttackState, SpellAnimationEnded);
            
            _fightStateMachine.SetState(idleAttackState);
            
        }
    }
}