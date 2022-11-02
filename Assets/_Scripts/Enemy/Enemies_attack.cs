using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_attack : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    public float timer;
    public float timershoot;
    private Moving_Enemies moving_Enemies;

    private void Start()
    {
        moving_Enemies = GetComponent<Moving_Enemies>();    
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") )
        {

            Enemyattack();


        }
       
    }
    public void Enemyattack()
    {

        timer += Time.deltaTime;
        if (timer < timershoot) return;
        animator.SetBool("attack",true);
        moving_Enemies.Enemies_speed = 0f;
        timer = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            moving_Enemies.EnemyAct();
            moving_Enemies.Enemies_speed = 3f;
            animator.SetBool("attack", false);
        }
    }

}

