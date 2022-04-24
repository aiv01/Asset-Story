using UnityEngine;

public class GunnerBullet : Bullet {
    [SerializeField]
    private DatabaseDamage databaseDamage = null;

    [SerializeField]
    private float damage = 0f;

    public float Damage {
        get { return damage * Time.fixedDeltaTime; }
    }


    #region OnEnable methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        mySpriteRenderer.sprite = databaseBullet.Sprite;
        mySpriteRenderer.sortingOrder = 1;
        IsFlipped = direction == -Vector2.right ? true : false;
    }
    #endregion


    protected override void OnCollisionEnter2D(Collision2D collision) {
        base.OnCollisionEnter2D(collision);

        if (collision.collider.CompareTag("Player")) {
            playerHealth.TakeDamage(databaseDamage.bulletDamage);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");
        }
    }
}