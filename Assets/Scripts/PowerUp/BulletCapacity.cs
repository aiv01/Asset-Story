using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCapacity : BasePowerUp
{
    [SerializeField]
    DatabaseBulletManager bulletMGRDB = null;
    private int bulletCapacity = 2;


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
        bulletMGRDB.NumOfBullet += bulletCapacity;
    }

    protected void TurnMeOff()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log($"Bullet Capacity {bulletMGRDB.NumOfBullet}");
    }
}
