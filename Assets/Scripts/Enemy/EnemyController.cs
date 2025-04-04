﻿using Fight;
using StateMachines;
using UnityEngine;
using UnityEngine.AI;
using StateMachine = StateMachines.StateMachine;
using Weapons.Base;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameObject _sword;
        
        public Collider SwordCollider { get; private set; }
        
        private Canvas hpCanvas;
        private StateMachine enemyStateMachine;
        private EnemyAnimator enemyAnimator;
        private HealthSystem healthSystem;
        private NavMeshAgent _agent;
        private Transform _playerTransform;
        private SkillsController _skillsController;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float searchRadius;
        [SerializeField] private float attackRange;
        public bool IsChasing { get; private set;}

        public bool IsInAttackRange { get; private set;}
        
        private void Awake()
        {
            SwordCollider = _sword.GetComponent<BoxCollider>();
            enemyStateMachine = new StateMachine();
            _skillsController = GetComponent<SkillsController>();
            enemyAnimator = GetComponent<EnemyAnimator>();
            healthSystem = GetComponent<HealthSystem>();
            gameObject.GetComponent<IHittable>().onHit.AddListener(enemyAnimator.DoHitEvent);
            _agent = GetComponent<NavMeshAgent>();
            hpCanvas = GetComponentInChildren<Canvas>();
        }

        private void Start()
        {   
            _playerTransform = FindFirstObjectByType<CharacterController>().transform;
            EnemyStatesInit();

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

        private void EnemyStatesInit()
        {
            IState attackState;
            SkillType type;
            if (CompareTag("Wizard"))
            {
                attackState = new RangeAttackState(this, enemyAnimator, _agent, _skillsController);
                type = SkillType.Fireball;
            }
            else
            {
                attackState = new AttackState(this, enemyAnimator, _agent, _skillsController);
                type = SkillType.Melee;
            }
            bool AttackReady() => _skillsController.Skills[type]._isReady;
            
            
            
            var idleState = new IdleState(this,enemyAnimator, _agent);
            var walkState =  new WalkState(this,enemyAnimator,_agent);
            var deathState = new DeathState(this,enemyAnimator,_agent, hpCanvas);
            
            bool AttackAnimationEnded() => enemyAnimator.CheckAnimationState(0,1f,"attackTest");

            
            enemyStateMachine.AddTransition(idleState, walkState, () => IsChasing && !IsInAttackRange);
            enemyStateMachine.AddTransition(walkState, idleState, () => !IsChasing || IsInAttackRange);
            enemyStateMachine.AddAnyTransition(deathState, () => healthSystem.Health <= 0f);
            enemyStateMachine.AddTransition(walkState, attackState, () => IsInAttackRange && AttackReady());
            enemyStateMachine.AddTransition(attackState, idleState,
                () => IsInAttackRange && AttackAnimationEnded());
            enemyStateMachine.AddTransition(attackState, walkState,
                () => !IsInAttackRange && AttackAnimationEnded());
            enemyStateMachine.AddTransition(idleState, attackState,
                () => IsInAttackRange && AttackReady());
            
            
            // enemyStateMachine.AddTransition(idleState, spellState, () => IsInCastRange && (Time.time - lastAttackTime >= attackCooldown));
            // enemyStateMachine.AddTransition(spellState, idleState, () => IsInCastRange && RangeAnimationEnded());
            // enemyStateMachine.AddTransition(walkState, spellState, () => IsInCastRange);
            // enemyStateMachine.AddTransition(spellState, walkState, () => !IsInCastRange && RangeAnimationEnded());
            
            
            
            
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
