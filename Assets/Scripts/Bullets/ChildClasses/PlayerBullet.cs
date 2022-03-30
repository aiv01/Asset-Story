using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet {



    #region OnEnable methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();
        IsFlipped = Movement.IsFlipped? true : false;

        mySpriteRenderer.sprite = databaseBullet.Sprite;
        mySpriteRenderer.flipX = IsFlipped ? true : false;
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Enemy") ||
            collision.collider.CompareTag("Bullet")) {
            DestroyMe();
        }
    }

    //private void /*OnCollisionEnter*/(Collision collision) {
    //    if (collision.collider.CompareTag("Enemy") ||
    //        collision.collider.CompareTag("Bullet")) {
    //        DestroyMe();
    //    }
    //}

}
