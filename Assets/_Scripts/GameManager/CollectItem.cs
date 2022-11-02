using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    public int Apples;
    public int Health = 3;
    public Text AppleText;
    public Text LifesText;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Appies"))
        {
            Destroy(collision.gameObject);
            Apples++;
            AppleText.text=""+Apples;

        }
        else if(collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            Health++;
            LifesText.text= "" +Health;
        }
        
    }
}
