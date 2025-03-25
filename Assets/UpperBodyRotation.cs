using Base;
using UnityEngine;

public class UpperBodyRotation : StateMachineBehaviour
{
    public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!InputManager.Instance.RMBInput) return;
        Transform head = animator.GetBoneTransform(HumanBodyBones.Head);
        if (head == null) return;
        Transform camera = Camera.main.transform;
        Vector3 LookDirection()
        {
            var lookDirection = camera.forward;
            lookDirection.y = 0; // Ограничиваем поворот по горизонтали
            lookDirection.Normalize();
            return lookDirection;
        }

        Vector3 lookAtPoint = LookDirection() * 10f + head.position;
        animator.SetLookAtPosition(lookAtPoint);
        animator.SetLookAtWeight(headWeight: 1, bodyWeight: .5f, weight: 1);
       
    }


}
