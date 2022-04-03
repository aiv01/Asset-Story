using UnityEngine;

public class PlayerBullet : Bullet {
    #region OnEnable methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        mySpriteRenderer.sprite = databaseBullet.Sprite;
        direction = Movement.IsFlipped ? -Vector2.right : Vector2.right;
        IsFlipped = direction == -Vector2.right ? true : false;
    }
    #endregion



    protected override void OnCollisionEnter2D(Collision2D collision) {
        base.OnCollisionEnter2D(collision);

        //if (collision.collider.CompareTag("Enemy")) {
        //    collision.collider.gameObject.SetActive(false);
        //}
    }
}