using Fight;
using StateMachines;
using UnityEngine;
using Weapons;
using Weapons.Base;
using Weapons.Colliding;

namespace Base
{
    public class FightController : MonoBehaviour
    {
        private StateMachine _fightStateMachine;
        private PlayerAnimator _playerAnimator;
        private SkillsController _skillsController;
        private InputManager _inputManager;


        [SerializeField] public GameObject swordGameObject;
        public Sword Sword { get; private set; }
        public Collider SwordCollider { get; private set; }


        private void Awake()
        {
            _fightStateMachine = new StateMachine();
            _skillsController = GetComponent<SkillsController>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            _inputManager = GetComponent<InputManager>();
            Sword = swordGameObject.AddComponent<Sword>();
            Sword.Init(gameObject.GetComponent<HealthSystem>(),new Damage(DamageType.Physic, 10f));
            SwordCollider = swordGameObject.GetComponent<BoxCollider>();
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
            
            
            bool MeleeAnimationEnded() => _playerAnimator.CheckAnimationState((int)LayerNames.Fight,0.99f,"Attack");
            bool SpellAnimationEnded() => _playerAnimator.CheckAnimationState((int)LayerNames.Fight,0.99f,"Spell");
            
            
            
            _fightStateMachine.AddTransition(idleAttackState,attackState, () => _inputManager.MeleeInput && _skillsController.Skills[SkillType.Melee]._isReady);
            _fightStateMachine.AddTransition(attackState,idleAttackState, MeleeAnimationEnded);
            _fightStateMachine.AddTransition(idleAttackState,spellState, () => _inputManager.SpellInput && _skillsController.Skills[SkillType.Fireball]._isReady);
            _fightStateMachine.AddTransition(spellState,idleAttackState, SpellAnimationEnded);
            
            _fightStateMachine.SetState(idleAttackState);
            
        }

        
    }
}