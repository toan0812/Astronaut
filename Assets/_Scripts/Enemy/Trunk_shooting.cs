using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk_shooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shootPoint;
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
        if (collision.gameObject.CompareTag("Player"))
        {

            EnemyShootting();
        }

    }
    public void EnemyShootting()
    {

        timer += Time.deltaTime;
        if (timer < timershoot) return;
        animator.SetBool("attack", true);
        moving_Enemies.Enemies_speed = 0f;
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        timer = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moving_Enemies.EnemyAct();
            moving_Enemies.Enemies_speed = 3f;
            animator.SetBool("attack", false);
        }
    }

}



