using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_jump : StateMachineBehaviour
{
    public bool CanJump;
    [SerializeField] private float JumpForce;
    private Rigidbody2D rigidbody2D;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask LayerMask;
    [SerializeField] private float CircleRadius;
    public bool IsGrounded;
    [SerializeField] private GameObject EffectJump;
    [SerializeField] private Transform PoinJump;
    [SerializeField] private float Timer;
    [SerializeField] private float TimeToJump;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigidbody2D = animator.GetComponent<Rigidbody2D>();
        GroundCheck = GameObject.Find("CheckGround").transform;
        PoinJump = GameObject.Find("PointJump").transform;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        CanJump = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Timer += Time.deltaTime;
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, CircleRadius, LayerMask);
        float DistanceFromPlayer = Player.position.x - animator.transform.position.x;
        if (IsGrounded && Timer >= TimeToJump)
        {
            CanJump = false;
            BossController.instance.boss_ComBat.JumpTime--;
            rigidbody2D.velocity = new Vector2(DistanceFromPlayer, JumpForce);
            GameObject JumpE = Instantiate(EffectJump);
            JumpE.transform.position = PoinJump.position;
            Destroy(JumpE, 0.5f);
            Timer = 0f;
        }
        else if (CanJump == false)
        {
            animator.SetTrigger("Falling");
            
        }
        else if(CanJump == true)
        {
            animator.SetBool("idle", true);
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
