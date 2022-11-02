using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_Spawn : MonoBehaviour
{
    public float speed;
    public Transform Player;
    private Rigidbody2D rb;
    public float direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("gun_side").transform;
     
       
    }
    private void Update()
    {
        rb.velocity = Vector2.right * speed* -direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
{     
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("Win"))
        {
            gameObject.SetActive(false);
        } 
    }
    public void Direction(float dir)
        
    {
        direction = dir;
        gameObject.SetActive(true);
    }
   
}
