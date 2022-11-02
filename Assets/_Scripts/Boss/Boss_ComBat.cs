using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ComBat : MonoBehaviour
{
    private Animator animator;
    public bool OnBoss;
    public int AttackTime;
    public bool ComBatTime;
    [SerializeField] private GameObject BossHealth;
    public int JumpTime = 3;
    [SerializeField] private float DashRange;
    public GameObject Obs;
    public GameObject WinCup;
    void Start()
    {
        Obs.SetActive(false);
        WinCup.SetActive(false);
        ComBatTime = false;
        animator = GetComponent<Animator>();
      
    }
    void Update()
    {
        SpawnChicken();
        BossDead();
        ComBat();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
            OnBoss = true;
            animator.SetTrigger("Sword_Back");
        }
    }
    void BossDead()
    {
        if (BossController.instance.damageReciver.CurrentHealth <= 0)
        {
            animator.SetBool("Dead", true);
            WinCup.transform.position = gameObject.transform.position;
            WinCup.SetActive(true);
            Obs.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    void SpawnChicken()
    {
        if (BossController.instance.damageReciver.CurrentHealth <= BossController.instance.damageReciver.Maxhealth * 0.5f)
        {
            Obs.SetActive(true);
            JumpOn();
        }
    }
    public void ThrowSwordOn()
    {   
        animator.SetTrigger("Throw_Sword");

    }
    public void JumpOn()
    {
        
        animator.SetTrigger("IsJumping");
        animator.SetBool("IsAttack", false);
        animator.SetBool("idle", false);
      
    }
    public void ComBat()
    {
        if (ComBatTime == true)
        {
            BossHealth.SetActive(true);
            Dash();
        }
    }
    public void Idle()
    {
        animator.SetBool("idle", true);
    }
    public void Running()
    {
        animator.SetTrigger("running");
        animator.SetBool("IsAttack", false);
    }
      public void Dash()
      {

        if (ComBatTime == true)
        {
            animator.SetBool("idle", false);
            animator.SetTrigger("Dashing");
        }
      
      }

}
