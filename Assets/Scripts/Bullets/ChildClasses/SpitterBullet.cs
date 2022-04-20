using UnityEngine;

public class SpitterBullet : Bullet {
    //[SerializeField]
    //public HealthModule playerHealth = null;
    [SerializeField]
    private DatabaseDamage spitterDamage = null;


    private void Start() {

    }


    #region OnEnable methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        mySpriteRenderer.sprite = databaseBullet.Sprite;
        IsFlipped = direction == -Vector2.right ? true : false;
    }
    #endregion



    protected override void OnCollisionEnter2D(Collision2D collision) {
        base.OnCollisionEnter2D(collision);

        if (collision.collider.CompareTag("Player") &&
            !Movement.Instance.IsDashing && !Movement.Instance.IsInvincible) {
            //playerHealth = GameLogic.Instance.healthModule;
            playerHealth.TakeDamage(spitterDamage.bulletDamage);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");
        }
    }
}
