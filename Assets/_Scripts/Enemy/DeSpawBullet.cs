using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawBullet : MonoBehaviour
{
    public float speed ;
    public float lifeTime;

    void Start()
    {
          Invoke("destroyBullet", lifeTime);
    }


    void Update()
    {
        BulletSpeed();
    }
    public void destroyBullet()
    {
            Destroy(gameObject);
    }
   public virtual void BulletSpeed()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
        
}
