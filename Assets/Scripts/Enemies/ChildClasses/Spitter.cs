using UnityEngine;

public class Spitter : Enemy {
    #region Attributes
    [SerializeField]
    private Transform playerTransform = null;

    [SerializeField]
    private float damage = 0.5f;

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
        if (collision.collider.CompareTag("Player")) {
            playerDatabaseHealth.TakeDamage(damage);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");

        }


        if (collision.collider.CompareTag("Bullet")) {
            myHealthModule.TakeDamage(2);
            myAnimator.SetTrigger("IsHitted");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Club")) {
            myHealthModule.TakeDamage(2);
            myAnimator.SetTrigger("IsHitted");
        }
    }



    private void OnDisable() {
        Ui_Bestiary.numOfSpitterKilled += 1;
    }
}