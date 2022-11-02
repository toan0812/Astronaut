using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject PlayerTaget;
    [SerializeField] private float MaxDistance;
    public bool FacingRight = false;

    private void Start()
    {

        PlayerTaget = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        LookAtPlayer();
    }

    public void LookAtPlayer()
    {

        if (transform.position.x < PlayerTaget.transform.position.x && !FacingRight)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x = Scaler.x * -1;
            transform.localScale = Scaler;
            FacingRight = true; 
        }
        else if (transform.position.x > PlayerTaget.transform.position.x && FacingRight)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x = Scaler.x * -1;
            transform.localScale = Scaler;
            FacingRight = false;
        }
    }


}
