using UnityEngine;

public class Ghosty : Enemy {
    #region Serialized attributes
    //[SerializeField]
    //private Transform playerTransform = null;
    #endregion
    #region Public attributes
    public DatabaseDamage ghostyDamage = null;
    public Color startColor = Vector4.zero;
    public Color newColor = Vector4.zero;
    #endregion



    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        myRigidbody.gravityScale = 0;
        myCollider.isTrigger = true;
        startColor = /*mySpriteRenderer.color*/new Vector4(1, 1, 1, 1);
        newColor = new Vector4(1, 1, 1, 0.2f);
        playerHealth = Movement.Instance.myHealtModule;
    }
    #endregion


    private void OnEnable() {
        myCollider.enabled = true;
        myHealthModule.Health = myHealthModule.maxHealth;
    }


    #region Update methods
    protected override void FlipMe() {
        base.FlipMe();

        if (transform.position.x <= /*playerTransform.position.x*/Movement.Instance.transform.position.x) {
            mySpriteRenderer.flipX = true;
        }
        else {
            mySpriteRenderer.flipX = false;

        }
    }
    #endregion


    private void OnDisable() {
        mySpriteRenderer.color = startColor;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerHealth.TakeDamage(ghostyDamage.meleeDamage);
            myHealthModule.TakeDamage(myHealthModule.maxHealth);
        }
    }
}