using Fight;
using StateMachines;
using UnityEngine;
using Weapons.Base;

namespace Base
{
    public class FightController : MonoBehaviour
    {
        private StateMachine _fightStateMachine;
        private PlayerAnimator _playerAnimator;
        private SkillsController _skillsController;
        private InputManager _inputManager;


        public GameObject SwordGameObject { get; private set; }
        public Collider SwordCollider { get; private set; }


        private void Awake()
        {
            _fightStateMachine = new StateMachine();
            _skillsController = GetComponent<SkillsController>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _inputManager = GetComponent<InputManager>();
            // fix .Find() later
            SwordGameObject = GameObject.Find("Sword");
            SwordCollider = SwordGameObject.GetComponent<BoxCollider>();
        }

        private void Start()
        {
            AttackStatesInit();
        }

        private void Update()
        {
            _fightStateMachine.Tick();
        }
        
        private void AttackStatesInit()
        {
            var attackState = new AttackState(this,_skillsController, _playerAnimator);
            var spellState = new SpellState(this,_skillsController, _playerAnimator);
            var idleAttackState = new IdleAttackState(this, _skillsController, _playerAnimator);
            
            
            bool MeleeAnimationEnded() => _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.99f &&
                                          _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).IsName("Attack");
            bool SpellAnimationEnded() => _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.99f &&
                                          _playerAnimator._animator.GetCurrentAnimatorStateInfo(1).IsName("Spell");
            
            
            
            _fightStateMachine.AddTransition(idleAttackState,attackState, () => _inputManager.MeleeInput && _skillsController.Skills[SkillType.Melee]._isReady);
            _fightStateMachine.AddTransition(attackState,idleAttackState, MeleeAnimationEnded);
            _fightStateMachine.AddTransition(idleAttackState,spellState, () => _inputManager.SpellInput && _skillsController.Skills[SkillType.Fireball]._isReady);
            _fightStateMachine.AddTransition(spellState,idleAttackState, SpellAnimationEnded);
            
            _fightStateMachine.SetState(idleAttackState);
            
        }

        
    }
}