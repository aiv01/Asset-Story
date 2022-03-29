using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : BasePowerUp
{
    [SerializeField]
    DatabasePlayer playerDB = null;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { ChangeStats();
          TurnMeOff();
        }
    }

    protected override void ChangeStats()
    {
        playerDB.Speed = 5;
        
    }

    protected void TurnMeOff()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log($"Player Speed{playerDB.Speed}");
    }
}
