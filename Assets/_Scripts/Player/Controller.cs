using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    public CollectItem item;
    public PlayerController PlayerController;
    public PlayerLife PlayerLife;
    public ChangeStatus ChangeStatus;
    public Player_DamageSender PlayerDamageSender;
    public Player_DamageReciver PlayerDamagereciver;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerDamagereciver = GetComponent<Player_DamageReciver>();
        PlayerDamageSender = GetComponent<Player_DamageSender>();
        PlayerController = GetComponent<PlayerController>();  
        PlayerLife = GetComponent<PlayerLife>();
        item = GetComponent<CollectItem>();
        ChangeStatus = GetComponent<ChangeStatus>();
    }
}
