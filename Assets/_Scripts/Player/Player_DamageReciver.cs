using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DamageReciver : DamageReciver
{
    private void Update()
    {
        Controller.instance.PlayerDamagereciver.CurrentHealth = Controller.instance.item.Health;
    }
    public virtual void TakeDamage()
    {
        
        Controller.instance.item.Health-= BossController.instance.damageSender.Damage();
        Controller.instance.item.LifesText.text =""+ Controller.instance.item.Health;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            TakeDamage();
        }
    }
    public override bool IsDead()
    {
        return base.IsDead();
    }
}
