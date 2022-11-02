using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] private Transform Effect_ShootPoint;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private GameObject Effect;
    [SerializeField] private float timer = 0;

    [SerializeField] private float timeBtwShoot = 1f;
    public GameObject Player;

    private PoolObject Pool;
    private void Start()
    {
        Pool = GetComponent<PoolObject>();
    }
    void Update()
    {
        Shootting();
        direction();
    }

    protected virtual void Shootting()
    {
        timer += Time.deltaTime;
        if(Input.GetButtonDown("Fire2") && timer < timeBtwShoot &&  Controller.instance.item.Apples > 0)
        {
            Controller.instance.ChangeStatus.ShootingStatus = true;
            GameObject Applebulet = Pool.GetPoolObject();
            if(Applebulet != null)
            {
                Applebulet.transform.position = ShootPoint.position;
                Applebulet.GetComponent<bullet_Spawn>().Direction(Mathf.Sign(transform.localScale.x));
                Applebulet.SetActive(true);
            }
            Controller.instance.item.Apples--;
            Controller.instance.item.AppleText.text = ""+Controller.instance.item.Apples;
            GameObject Effectb = Instantiate(Effect, Effect_ShootPoint.position, Effect_ShootPoint.rotation);
            Destroy(Effectb, 0.25f);
            
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) && Controller.instance.PlayerController.isGrounded == true)
        {
           Controller.instance.ChangeStatus.ShootingStatus = false;
            Player.SetActive(true);
            gameObject.SetActive(false);
        }
   
        timer = 0;

    }
    protected virtual void direction()
    {
        gameObject.transform.localScale = Player.transform.localScale;
    }
}
