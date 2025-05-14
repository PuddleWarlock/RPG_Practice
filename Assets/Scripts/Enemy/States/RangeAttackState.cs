using System.Collections;
using Controllers.Entities;
using UnityEngine;
using UnityEngine.AI;
using Weapons.Base;

namespace Enemy.States
{
    public class RangeAttackState : StatesEnemyConst
    {
        private SkillsController _skillsController;
        public RangeAttackState(EnemyController enemyController, EnemyAnimator animator, NavMeshAgent navMeshAgent, SkillsController skillsController ) : base(enemyController, animator, navMeshAgent)
        {
            _skillsController = skillsController;
        }

        public override void Enter()
        {
            Debug.Log("Entering ENEMY RANGE ATTACK");
            EnemyAnimator.DoAttack();
            NavMeshAgent.isStopped = true;
            EnemyAnimator.StartCoroutine(SpellCast());
        }

        public override void Execute()
        {
            EnemyController.RotateToPlayer();
        }

        public override void Exit()
        {
            
        }
        
        private IEnumerator SpellCast()
        {
            yield return new WaitUntil(()=>EnemyAnimator.CheckAnimationState(0, 0.425f, "attackTest"));
            _skillsController.Skills[SkillType.Fireball].Cast();
        }
    }
}