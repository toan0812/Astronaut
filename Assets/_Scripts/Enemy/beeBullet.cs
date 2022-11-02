using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeBullet : DeSpawBullet
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyBullet", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
