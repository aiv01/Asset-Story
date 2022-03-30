using UnityEngine;

public class SpitterBullet : Bullet {
    private bool spitterIsFlipped = false;
    [SerializeField]
    DatabaseHealth player = null;


    #region OnEnable methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        IsFlipped = Enemy.IsFlipped ? true : false;
        mySpriteRenderer.sprite = databaseBullet.Sprite;
        mySpriteRenderer.flipX = IsFlipped ? true : false;
    }
    #endregion



    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            player.TakeDamage(2);
            DestroyMe();
        }

        if (collision.collider.CompareTag("Shield")) {
            DestroyMe();
        }
    }
}
