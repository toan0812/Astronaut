using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_DamageReciver : DamageReciver
{
    public Boss_health HealthBar;
    private void Awake()
    {

        CurrentHealth = Maxhealth;
        HealthBar.SetMaxHealth(Maxhealth);
    }
    public virtual void TakeDamage()
    {
        CurrentHealth -= Controller.instance.PlayerDamageSender.Damage();
        HealthBar.SetHealth(CurrentHealth);
    }
    private void Update()
    {
        //Dead();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            BossController.instance.boss_ComBat.ComBatTime= true;
            TakeDamage();
        }
    }

}
