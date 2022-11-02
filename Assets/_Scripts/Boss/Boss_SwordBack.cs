using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_SwordBack : StateMachineBehaviour
{
    private float Timer;
    private float TimerToThrow =1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BossController.instance.Movement.LookAtPlayer();
        Timer += Time.deltaTime;
        if (Timer >= TimerToThrow)
        {
            animator.SetTrigger("Throw_Sword");
            Timer = 0f;
        }
   
        

    }


    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
