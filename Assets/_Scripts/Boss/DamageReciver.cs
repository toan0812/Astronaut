using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciver : MonoBehaviour
{
    [Header("DamageReceiver")]
    public int Maxhealth;
    public int CurrentHealth;

    private void Start()
    {
        CurrentHealth = Maxhealth;
    }

    public virtual bool IsDead()
    {
        return CurrentHealth <= 0;
    }


}
