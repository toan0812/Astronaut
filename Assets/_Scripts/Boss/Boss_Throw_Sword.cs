using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Throw_Sword : StateMachineBehaviour
{
    [SerializeField] private GameObject Sword;
    public float MaxSword;
    [SerializeField] private Transform Throw_point;
    private PoolObject pool;
    [SerializeField] private float Timer;
    [SerializeField] private float TimeToAction;
    [SerializeField] private float BossSpeed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pool = animator.GetComponent<PoolObject>();
        Throw_point = GameObject.Find("Point_Throw").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Timer += Time.deltaTime;
        if(Timer >= TimeToAction)
        {
            Sword = pool.GetPoolObject();
            if (Sword != null)
            {
                Sword.transform.position = Throw_point.position;
                Sword.SetActive(true);
                Timer = 0f;
            }
            

        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


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
