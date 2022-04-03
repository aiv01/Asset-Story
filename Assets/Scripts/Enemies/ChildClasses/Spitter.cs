using UnityEngine;
using System.Collections;

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



    protected override void Update() {
        base.Update();

        //if (myHealthModule.databaseHealth.Health <= 0) {
        //    TurnOffMe();
        //}

        //Debug.Log($"MY HEALTH {myHealthModule.databaseHealth.Health}");
    }
   


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
        }
        //if (collision.collider.CompareTag("Club")) {
        //    TurnOffMe();
        //}
        //if (collision.collider.CompareTag("Player") &&
        //    Movement.IsHitting) {
        //    myHealthModule.databaseHealth.TakeDamage(0.8f);
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Club")) {
            myHealthModule.TakeDamage(2);
            //StartCoroutine(TurnOffMe());
            //gameObject.SetActive(false);
        }
    }

    //private IEnumerator TurnOffMe() {
    //    myRigidbody.simulated = false;
    //    myAnimator.SetBool("IsDead", true);
    //    yield return new WaitForSeconds(0.5f);
    //    gameObject.SetActive(false);
    //}



    private void OnDisable() {
        Ui_Bestiary.numOfSpitterKilled += 1;
    }
}
