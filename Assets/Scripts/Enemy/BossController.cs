using Controllers.Entities;
using Controllers.Entities.HealthController;
using Controllers.Entities.HealthController.Interfaces;
using Enemy.States;
using StateMachines;
using UnityEngine;
using UnityEngine.AI;
using Views.Gameplay;
using StateMachine = StateMachines.StateMachine;
using Weapons.Base;
using AttackState = Enemy.States.AttackState;

namespace Enemy
{
    public class BossController : MonoBehaviour, ICharacterController
    {
        
        
        // public bool isDead { get; set; }
        // public string UniqueId { get; set; }
        // public int PrefabIndex { get; set; }
        // Transform ICharacterController.transform => transform;
        // GameObject ICharacterController.gameObject => gameObject;
        // HealthSystem ICharacterController.GetComponent<T>() => GetComponent<HealthSystem>();
        // T ICharacterController.GetComponentInChildren<T>() => GetComponentInChildren<T>();
        
        
        public bool isDead { get; set; }
        public string UniqueId { get; set; }
        public int PrefabIndex { get; set; }
        Transform ICharacterController.transform => transform;
        GameObject ICharacterController.gameObject => gameObject;
        HealthSystem ICharacterController.GetComponent<T>() => GetComponent<HealthSystem>();
        T ICharacterController.GetComponentInChildren<T>() => GetComponentInChildren<T>();
        
        
        
        
        
        
        [SerializeField] private GameObject _sword;
        
        public Collider SwordCollider { get; private set; }
        // public string UniqueId;
        // public int PrefabIndex;
        private Canvas hpCanvas;
        private StateMachine enemyStateMachine;
        private BossAnimator bossAnimator;
        private HealthSystem healthSystem;
        private NavMeshAgent _agent;
        private Transform _playerTransform;
        private SkillsController _skillsController;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float searchRadius;
        [SerializeField] private float attackRange;
        
        public bool IsChasing { get; private set;}
        // public bool isDead;
        public bool IsInAttackRange { get; private set;}
        public bool _superAttack { get; private set; }
        private void Awake()
        {
            enemyStateMachine = new StateMachine();
            bossAnimator = GetComponent<BossAnimator>();
            healthSystem = GetComponent<HealthSystem>();
            gameObject.GetComponent<IHittable>().onHit.AddListener(bossAnimator.DoHitEvent);
            _agent = GetComponent<NavMeshAgent>();
            hpCanvas = GetComponentInChildren<Canvas>();
        }

        private void Start()
        {   
            _playerTransform = FindFirstObjectByType<CharacterController>().transform;
            BossStatesInit();

        }

        private void Update()
        {   
            
            ChasingChecker();
            _agent.SetDestination(_playerTransform.position);
            enemyStateMachine.Tick();
        }

        public void RotateToPlayer()
        {
            Vector3 direction = _playerTransform.position - transform.position;
            Quaternion desiredRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }

        private void BossStatesInit()
        {
            
            
            
            SkillType type;
            
            var attackState = new BossAttackState(this, bossAnimator, _agent);
            bool AttackReady() => _skillsController.Skills[type]._isReady;

            
            var superAttackState = new BossSuperAttackState(this, bossAnimator, _agent);
            
            var idleState = new BossIdleState(this,bossAnimator, _agent);
            var walkState =  new BossWalkState(this,bossAnimator,_agent);
            var deathState = new BossDeathState(this,bossAnimator,_agent, hpCanvas);
            
            bool AttackAnimationEnded() => bossAnimator.CheckAnimationState(0,1f,"BossAttack");

            
            enemyStateMachine.AddTransition(idleState, walkState, () => IsChasing && !IsInAttackRange);
            enemyStateMachine.AddTransition(walkState, idleState, () => !IsChasing || IsInAttackRange);
            enemyStateMachine.AddAnyTransition(deathState, () => healthSystem.Health <= 0f);
            // enemyStateMachine.AddTransition(walkState, attackState, () => IsInAttackRange && AttackReady());
            // enemyStateMachine.AddTransition(attackState, idleState,
            //     () => IsInAttackRange && AttackAnimationEnded());
            // enemyStateMachine.AddTransition(attackState, walkState,
            //     () => !IsInAttackRange && AttackAnimationEnded());
            
            // enemyStateMachine.AddTransition(idleState, attackState,
            //     () => IsInAttackRange && AttackReady());
            
            // enemyStateMachine.AddTransition(walkState, superAttackState, () => IsInAttackRange && AttackReady() && _superAttack);
            // enemyStateMachine.AddTransition(superAttackState, idleState,
            //     () => IsInAttackRange && AttackAnimationEnded());
            // enemyStateMachine.AddTransition(attackState, superAttackState,
            //     () => !IsInAttackRange && AttackAnimationEnded() && _superAttack);
            // enemyStateMachine.AddTransition(idleState, superAttackState,
            //     () => IsInAttackRange && AttackReady() && _superAttack);
            
           

            
            enemyStateMachine.SetState(idleState);
        }

        
        private void ChasingChecker()
        {
            if (Vector3.Distance(_agent.transform.position, _playerTransform.position) <= searchRadius)
            {   
                IsChasing = true;
                if (Vector3.Distance(_agent.transform.position, _playerTransform.position) <= attackRange)
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
