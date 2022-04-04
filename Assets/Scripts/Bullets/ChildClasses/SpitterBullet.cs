using UnityEngine;

public class SpitterBullet : Bullet {
    [SerializeField]
    DatabaseHealth player = null;



    #region OnEnable methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        mySpriteRenderer.sprite = databaseBullet.Sprite;
        IsFlipped = direction == -Vector2.right ? true : false;
    }
    #endregion



    protected override void OnCollisionEnter2D(Collision2D collision) {
        base.OnCollisionEnter2D(collision);

        if (collision.collider.CompareTag("Player")) {
            player.TakeDamage(2);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");
        }
    }
}
