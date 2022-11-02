using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shootPoint;
    private Animator animator;
    public float timer;
    public float timershoot;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < timershoot) return;
        animator.SetBool("attack", true);
        Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        timer = 0;
    }
}
