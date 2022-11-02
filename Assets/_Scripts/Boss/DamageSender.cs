using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [Header("DamageSender")]
    [SerializeField] protected int damage;

    public virtual int Damage()
    {
        return this.damage;
    }
}
