using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatus : MonoBehaviour
{
    public GameObject PlayerGun;
    public bool ShootingStatus = false;
    private void Update()
    {
        ChangePlayerStatus();
    }

    public void ChangePlayerStatus()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            ShootingStatus = true;
            gameObject.SetActive(false);
            PlayerGun.SetActive(true);
            PlayerGun.transform.position = gameObject.transform.position;            
        }
       
    }
}
