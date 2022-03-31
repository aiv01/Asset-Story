using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffDamagePowerUp : BasePowerUp
{
    [SerializeField]
    DatabasePlayer playerDB = null;
    private int damage = 2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChangeStats();
            TurnMeOff();
        }


    }

    protected override void ChangeStats()
    {
        playerDB.Damage += damage;

    }

    protected void TurnMeOff()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log($"Player Damage{playerDB.Damage}");
    }
}
