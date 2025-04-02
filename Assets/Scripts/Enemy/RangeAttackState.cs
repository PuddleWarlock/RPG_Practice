using System.Collections;
using Fight;
using UnityEngine;
using UnityEngine.AI;
using Weapons.Base;

namespace Enemy
{
    public class RangeAttackState : StatesEnemyConst
    {
        public RangeAttackState(EnemyController enemyController, EnemyAnimator animator, NavMeshAgent navMeshAgent ) : base(enemyController, animator, navMeshAgent)
        {
        }

        public override void Enter()
        {
            EnemyController._sword.ClearEnemiesList();
            Debug.Log("Entering ENEMY RANGE ATTACK");
            EnemyAnimator.DoSpellEvent();
            NavMeshAgent.isStopped = true;
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
        
        // private IEnumerator SpellCast()
        // {
        //     yield return new WaitUntil(()=>EnemyAnimator.CheckAnimationState(0, 0.425f, "Spell"));
        //     SkillsController.Skills[SkillType.Fireball].Cast();
        // }
    }
}