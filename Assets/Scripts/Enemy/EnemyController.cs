using Fight;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;
using UnityEngine.AI;
using Weapons;
using Weapons.Colliding;
using StateMachine = StateMachines.StateMachine;
using Base;
using Weapons.Base;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] public Sword _sword;
        private StateMachine enemyStateMachine;
        private EnemyAnimator enemyAnimator;
        private HealthSystem healthSystem;
        private NavMeshAgent _agent;
        private GameObject _player;
        private SkillsController _skillsController;
        private float searchRadius;
        private float attackRange;
        public bool IsChasing { get; private set;}

        public bool IsInAttackRange { get; private set;}
        
        public bool IsInCastRange { get; private set;}

        private void Awake()
        {   
            _sword.Init(healthSystem, new Damage(DamageType.Physic, 20f));
            enemyStateMachine = new StateMachine();
            _skillsController = GetComponent<SkillsController>();
            enemyAnimator = GetComponent<EnemyAnimator>();
            healthSystem = GetComponent<HealthSystem>();
            gameObject.GetComponent<IHittable>().onHit.AddListener(enemyAnimator.DoHitEvent);
            searchRadius = 10f;
            attackRange = 2f;
        }

        private void Start()
        {   
            
            _agent = GetComponent<NavMeshAgent>();
            EnemyStatesInit();
            _player = FindFirstObjectByType<CharacterController>().gameObject;

        }

        private void Update()
        {   
            
            ChasingChecker();
            _agent.SetDestination(_player.transform.position);
            enemyStateMachine.Tick();
        }

        private void EnemyStatesInit()
        {
            var idleState = new IdleState(this,enemyAnimator, _agent);
            var walkState =  new WalkState(this,enemyAnimator,_agent);
            var deathState = new DeathState(this,enemyAnimator,_agent);
            var attackState = new AttackState(this,enemyAnimator,_agent, _skillsController);
            // var spellState = new RangeAttackState(this,enemyAnimator,_agent);
            
            bool MeleeAnimationEnded() => enemyAnimator.CheckAnimationState(0,1f,"attackTest");
            // bool RangeAnimationEnded() => enemyAnimator.CheckAnimationState(0,1f,"attackTest");
            
            enemyStateMachine.AddTransition(idleState, walkState, () => IsChasing && !IsInAttackRange);
            enemyStateMachine.AddTransition(walkState, idleState, () => !IsChasing);
            enemyStateMachine.AddAnyTransition(deathState, () => healthSystem.Health <= 0f);
            enemyStateMachine.AddTransition(walkState, attackState, () => IsInAttackRange);
            enemyStateMachine.AddTransition(attackState, idleState,
                () => IsInAttackRange && MeleeAnimationEnded());
            enemyStateMachine.AddTransition(attackState, walkState,
                () => !IsInAttackRange && MeleeAnimationEnded());
            enemyStateMachine.AddTransition(idleState, attackState,
                () => IsInAttackRange && (_skillsController.Skills[SkillType.Melee]._isReady));
            
            
            // enemyStateMachine.AddTransition(idleState, spellState, () => IsInCastRange && (Time.time - lastAttackTime >= attackCooldown));
            // enemyStateMachine.AddTransition(spellState, idleState, () => IsInCastRange && RangeAnimationEnded());
            // enemyStateMachine.AddTransition(walkState, spellState, () => IsInCastRange);
            // enemyStateMachine.AddTransition(spellState, walkState, () => !IsInCastRange && RangeAnimationEnded());
            
            
            
            
            enemyStateMachine.SetState(idleState);
        }

        
        private void ChasingChecker()
        {
            if (Vector3.Distance(_agent.transform.position, _player.transform.position) <= searchRadius)
            {   
                IsChasing = true;
                if (Vector3.Distance(_agent.transform.position, _player.transform.position) <= attackRange)
                {
                    IsInAttackRange = true;
                }
                else
                {   
                    IsInAttackRange = false;
                }
            }
            else
            {   
                IsChasing = false;
            }
        }
        
        
}
}
