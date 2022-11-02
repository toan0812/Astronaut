using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameMaster GM;
    [SerializeField] GameObject LastGM;
    public GameObject rePlay;
    public GameObject Load;
    public GameObject Warning;
    
    void Start()
    {
        LastGM = GameObject.FindGameObjectWithTag("Last");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Controller.instance.PlayerDamagereciver.TakeDamage();
            die();
        }
        if (collision.gameObject.CompareTag("trap"))
        {
            die();
            Controller.instance.item.Health -= 1;
            Controller.instance.item.LifesText.text = "" + Controller.instance.item.Health;
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            //Win Game
            UIManager.Instance.PlayGame();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemyBullet"))
        {
            die();
            Controller.instance.item.Health -= 1;
            Controller.instance.item.LifesText.text = "" + Controller.instance.item.Health;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Last"))
        {
            Warning.SetActive(true);
            Load.SetActive(false);
        }
    }
    private void Update()
    {
        if (Controller.instance.PlayerDamagereciver.IsDead() == true)
        {
            Controller.instance.item.LifesText.text = "" + 0;
            anim.SetTrigger("Reallydead");
            anim.SetBool("dead", false);
            rb.bodyType = RigidbodyType2D.Static;
           
        }
    }
    public void die()
    {
        anim.SetBool("dead", true);
    }
    public void ilde()
    {
        anim.SetInteger("State", 0);
        anim.SetBool("dead", false);
    }

    public void resetPos()
    {
        transform.position = GM.lascheckPointPos;
        rePlay.SetActive(false);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void PauseGame()
    {
        UIManager.Instance.Toturial();
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void HomeGame()
    {
        UIManager.Instance.RestartloadGame();
    }

}
