using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // tọa biến di chuyển 
    private Rigidbody2D Playerrb;
    [SerializeField] private float MoveSpeed ;
    [SerializeField] private float JumpForce;
    [SerializeField] private float JumpForceSlide;
    private float Move;

    // tạo biến kiểm tra hướng mặt của player 
    public bool FacingRight = true;

    // tạo biến kiểm tra khi nhảy 
    public bool isGrounded = true;
    [SerializeField] private LayerMask WhatIsGounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;

    // khai báo biến anim trong animator
    private Animator Anim;
    private enum MovementState { idle ,run,slide,jump}
    private MovementState state = MovementState.idle;
    //private ChangeStatus changeStatus;
    
    void Start()
    {
        //changeStatus = GetComponent<ChangeStatus>();
        Playerrb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
       
    }

 
    void FixedUpdate()
    {
        // kiểm tra điểm va chạm của player  
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGounded);

        // di chuyển player

        Move = Input.GetAxisRaw("Horizontal");
        Playerrb.velocity = new Vector2(MoveSpeed * Move, Playerrb.velocity.y);

        // kiểm tra hướng mặt của player và flip() lại 
        if (FacingRight == false && Move > 0)    
        {
            Flip();
        }
        else if(FacingRight == true && Move < 0)
        {
            Flip();
        }

    }
    private void Update()
    {

        Jump();
        Slide();
        UpdateAnimationUpdate();
    }
    // hàm flip() player
      void Flip()
    {
        FacingRight =! FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
     
     private void UpdateAnimationUpdate()
    {

        if (Move == 0f)
        {
            state = MovementState.idle;
            
        }
        else if (Move < 0f || Move >0)
        {
            
            state = MovementState.run;
        }
        if(isGrounded == false)
        {
            state = MovementState.jump;
        }
       
       
        Anim.SetInteger("State", (int)state);
    }

    private void Jump()
    {

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Playerrb.velocity = new Vector2(Playerrb.velocity.x, JumpForce);
           
        }

    }
    private void Slide()
    {
        if (Input.GetKeyDown(KeyCode.S) && Move != 0 && isGrounded == true)
        {
            Playerrb.velocity = new Vector2(JumpForce, Playerrb.velocity.y);
            Anim.SetTrigger("slide");
        }
    }

}

