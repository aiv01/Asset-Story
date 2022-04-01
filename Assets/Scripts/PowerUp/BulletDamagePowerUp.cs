using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamagePowerUp : BasePowerUp
{
    [SerializeField]
    DatabaseBullet bulletDB = null;
    private int bulletDMG = 1;


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
    }

    protected void TurnMeOff()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log($"Player bullet dmg {bulletDB.Damage}");
    }
}
