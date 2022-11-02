using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Running : StateMachineBehaviour
{
    public float BossSpeed;
    [SerializeField] private GameObject RunEffect;
    [SerializeField] private Transform RunPoint;
    [SerializeField] private float attackRange;
    public float MaxDistance;
    public Transform PlayerTaget;

    private Rigidbody2D rb;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerTaget = GameObject.FindGameObjectWithTag("Player").transform;
        RunPoint = GameObject.Find("RunE").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (Vector2.Distance(animator.transform.position, PlayerTaget.transform.position) > MaxDistance)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, new Vector2(PlayerTaget.position.x, rb.transform.position.y), BossSpeed * Time.deltaTime);
            GameObject RunE = Instantiate(RunEffect);
            RunE.transform.position = RunPoint.position;
            Destroy(RunE, 0.1f);
        }
        else if (Vector2.Distance(animator.transform.position, PlayerTaget.transform.position) < attackRange)
        { 
            animator.SetTrigger("attack_1");
            animator.SetBool("idle", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

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
