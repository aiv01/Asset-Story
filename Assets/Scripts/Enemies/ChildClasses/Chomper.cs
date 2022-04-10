using UnityEngine;

public class Chomper : Enemy {
    #region Attributes
    [SerializeField]
    private float damage = 0f;

    [SerializeField]
    private float flipOffset = 0.85f;

    [SerializeField]
    private float mass = 10f;
    #endregion



    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        transform.localScale = new Vector3(1.5f, 1.5f, 1);
        myRigidbody.mass = mass;
    }
    #endregion



    #region Update methods
    protected override void FlipMe() {
        base.FlipMe();

        if (myRigidbody.velocity.x <= flipOffset) {
            mySpriteRenderer.flipX = true;
        }
        else {
            mySpriteRenderer.flipX = false;
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
            myHealthModule.TakeDamage(myHealthModule.maxHealth);
        }
        if (collision.collider.CompareTag("Player") &&
            !Movement.Instance.IsDashing && !Movement.Instance.IsInvincible) {
            playerHealth.TakeDamage(damage);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");
            myHealthModule.TakeDamage(myHealthModule.maxHealth);
        }
        if (collision.collider.CompareTag("Bullet")) {
            myAnimator.SetTrigger("IsHitted");
            myHealthModule.TakeDamage(1);
            MessageManager.CallOnChomperHitted();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Club")) {
            myAnimator.SetTrigger("IsHitted");
            myHealthModule.TakeDamage(1);
            MessageManager.CallOnChomperHitted();
        }
    }



    private void OnDisable() {
        Ui_Bestiary.numOfChomperKilled += 1;
    }
}