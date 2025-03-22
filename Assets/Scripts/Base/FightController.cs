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

        [SerializeField] private GameObject _spellProjectile;
        [SerializeField] private Transform _castPoint;
        
        public GameObject SwordGameObject { get; private set; }
        public Collider SwordCollider { get; private set; }


        private void Awake()
        {
            _cooldownSystem = new CooldownSystem();
            _fightStateMachine = new StateMachine();
            _inputManager = GetComponent<InputManager>();
            _playerAnimator = GetComponent<PlayerAnimator>();
            SwordGameObject = GameObject.Find("Sword");
            SwordCollider = SwordGameObject.GetComponent<BoxCollider>();
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
            var attackState = new AttackState(this,_cooldownSystem, _playerAnimator);
            var spellState = new SpellState(this,_cooldownSystem, _playerAnimator);
            var idleAttackState = new IdleAttackState(this, _cooldownSystem, _playerAnimator);
            
            
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

        public void CastSpell()
        {
            var obj = Instantiate(_spellProjectile,_castPoint.position, Quaternion.identity);
            var rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(gameObject.transform.forward*1000f);
            rb.AddTorque(new Vector3(0.8f,.4f,.3f)*200f);
            

        }
    }
}