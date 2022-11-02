using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public static BossController instance;
    public BossMovement Movement;
    public Boss_ComBat boss_ComBat;
    public DamageSender damageSender;
    public Boss_DamageReciver damageReciver;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        damageSender = GetComponent<DamageSender>();
        damageReciver = GetComponent<Boss_DamageReciver>();
        Movement = GetComponent<BossMovement>();
        boss_ComBat = GetComponent<Boss_ComBat>();
       
    }

}
