using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : DeSpawBullet
{
    public GameObject Trunk;
    private Rigidbody2D rb;
 
    void Start()
    {
        Trunk = GameObject.FindGameObjectWithTag("Trunk");
        rb = GetComponent<Rigidbody2D>();
        BulletSpeed();
        Invoke("destroyBullet", lifeTime);
    }
    void Update()
    {
      
    }
    public override void BulletSpeed()
    {
        rb.velocity = Vector2.right * speed * dir();
        if(Trunk.transform.localScale.x <0)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x = Scaler.x * -1;
            transform.localScale = Scaler;
        }
    }
    int dir()
    {
        if (Trunk.transform.localScale.x < 0)
        {
            return 1;
        }
        else return -1;
    }
}
