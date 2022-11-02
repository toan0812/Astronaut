using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Spawn : MonoBehaviour
{
    public float MaxSpeed ;
    public Transform Boss;
    private Rigidbody2D rb;
    public float direction;
    private Animator animator;
    public bool OnBoss = false;

    [SerializeField] private float Timer;
    [SerializeField] private float TimeBack;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Boss = GameObject.Find("Boss").transform;
    }
    private void Start()
    {
            //transform.localScale = Boss.localScale;
        
    }
    private void Update()
    {
        rb.velocity = Vector2.right * MaxSpeed * Direction();
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            animator.SetBool("embedded", false);
            Timer += Time.deltaTime;
            if (Timer >= TimeBack)
            {
                MaxSpeed = -MaxSpeed;
                rb.constraints = RigidbodyConstraints2D.None;
                animator.SetTrigger("Back");
                Timer = 0f;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
                animator.SetTrigger("Back");
                
        }      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {

            animator.SetBool("embedded",true);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;


        }
        if(collision.gameObject.CompareTag("Boss"))
        {
            OnBoss = true;
            MaxSpeed = -MaxSpeed;
            gameObject.SetActive(false);
            
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            Boss.GetComponent<Animator>().SetBool("IsAttack",true);
            gameObject.SetActive(false);
            Boss.transform.position = transform.position;
            if (MaxSpeed < 0 && BossController.instance.Movement.FacingRight == false)
            {
                BossController.instance.Movement.LookAtPlayer();
                
            }
            else if(MaxSpeed < 0 && BossController.instance.Movement.FacingRight == true)
            {
                BossController.instance.Movement.LookAtPlayer();
            }


        }
    }
    public int Direction()
    {
        if (Boss.transform.rotation.y < 0)
        {
            return -1;
        }
        else
            return 1;
    }
}
