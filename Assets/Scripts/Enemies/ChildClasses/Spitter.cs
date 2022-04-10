using UnityEngine;

public class Spitter : Enemy {
    #region Attributes
    //[SerializeField]
    //private Transform playerTransform = null;
    [SerializeField]
    private DatabaseDamage playerDamage = null;

    [SerializeField]
    private float damage = 0.5f;

    [SerializeField]
    private DatabaseDamage spitterDamage = null;

    private float mass = 100f;
    #endregion



    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        myRigidbody.mass = mass;
    }
    #endregion



    #region Update methods
    protected override void FlipMe() {
        base.FlipMe();

        if (transform.position.x <= playerTransform.position.x) {
            mySpriteRenderer.flipX = false;
        }
        else {
            mySpriteRenderer.flipX = true;

        }
    } 
    #endregion



    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player") &&
            Movement.Instance.IsInvincible) {
            myHealthModule.TakeDamage(myHealthModule.maxHealth);
        }
        if (collision.collider.CompareTag("Player") &&
            Movement.Instance.IsDashing) {
            myHealthModule.TakeDamage(myHealthModule.maxHealth * 0.5f);
        }
        if (collision.collider.CompareTag("Player") &&
            !Movement.Instance.IsDashing && !Movement.Instance.IsInvincible) {
            playerHealth.TakeDamage(spitterDamage.contactDamage);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");
        }


        if (collision.collider.CompareTag("Bullet")) {
            myHealthModule.TakeDamage(playerDamage.bulletDamage);
            myAnimator.SetTrigger("IsHitted");
            MessageManager.CallOnSpitterHitted();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Club")) {
            myHealthModule.TakeDamage(playerDamage.meleeDamage);
            myAnimator.SetTrigger("IsHitted");
            MessageManager.CallOnSpitterHitted();
        }
    }



    private void OnDisable() {
        Ui_Bestiary.numOfSpitterKilled += 1;
    }
}