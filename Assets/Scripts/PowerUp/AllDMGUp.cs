using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDMGUp : BasePowerUp
{
    [SerializeField]
    DatabaseBullet bulletDB = null;
    [SerializeField]
    DatabasePlayer playerDB = null;
    private int bulletDMG = 1;
    private int staffDMG = 2;



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
        bulletDB.Damage += bulletDMG;
        playerDB.Damage += staffDMG;
    }

    protected void TurnMeOff()
    {
        gameObject.SetActive(false);
    }

    //private void Update()
    //{
    //    Debug.Log($"Player Staff {playerDB.Damage} and Bullet {bulletDB.Damage} damage");
    //}
}
