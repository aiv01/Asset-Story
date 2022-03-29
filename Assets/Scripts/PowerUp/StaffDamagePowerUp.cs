using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffDamagePowerUp : BasePowerUp
{
    [SerializeField]
    DatabasePlayer playerDB = null;


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
        playerDB.Damage = 2;

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
