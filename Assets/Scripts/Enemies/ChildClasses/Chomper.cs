using UnityEngine;
using System.Collections;

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
        if (collision.collider.CompareTag("Player")) {
            StartCoroutine(TurnOffMe());
        }
    }
    #region OnCollision methods
    private IEnumerator TurnOffMe() {
        playerDatabaseHealth.TakeDamage(damage);
        myRigidbody.simulated = false;
        myAnimator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
    #endregion



    private void OnDisable() {
        Ui_Bestiary.numOfChomperKilled += 1;
    }
}