using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSp : MonoBehaviour
{
    Animator animator;
        private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(gameObject.transform.position.y <0)
        {
            animator.SetTrigger("Falling");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }
}
