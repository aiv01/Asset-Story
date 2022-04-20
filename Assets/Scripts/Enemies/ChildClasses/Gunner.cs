using UnityEngine;

public class Gunner : Enemy {
    #region Serialized attributes
    [SerializeField]
    private DatabaseDamage myDatabaseDamage = null;

    [SerializeField]
    private DatabaseDamage playerDatabaseDamage = null;

    [SerializeField]
    private float mass = 100f;

    //[SerializeField]
    //private Transform playerTransform = null;
    #endregion
    #region Private attributes
    private BoxCollider2D myCollider = null;
    #endregion
    #region Constant
    public const int GUNNER_SORTINGORDER = 1;
    #endregion
    #region Public Properties
    public bool IsConfuse {
        get;
        set;
    } = false;
    #endregion



    #region Awake methods
    protected override void TakeTheReferences() {
        base.TakeTheReferences();

        myCollider = GetComponent<BoxCollider2D>();
    } 
    #endregion



    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        myRigidbody.mass = mass;
        mySpriteRenderer.sortingOrder = GUNNER_SORTINGORDER;
    }
    #endregion



    protected override void Update() {
        base.Update();

        myRigidbody.isKinematic = IsConfuse;
        myCollider.isTrigger = IsConfuse;
    }
    #region Update methods
    protected override void FlipMe() {
        base.FlipMe();

        if (transform.position.x <= playerTransform.position.x) {
            mySpriteRenderer.flipX = true;
        }
        else {
            mySpriteRenderer.flipX = false;

        }
    }
    #endregion



    #region OnCollision
    private void OnCollisionEnter2D(Collision2D collision) {
        if (myAnimator.GetBool("IsWalking") && collision.collider.CompareTag("Player")) {
            playerHealth.TakeDamage(myDatabaseDamage.contactDamage);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");
        }

        if (myAnimator.GetBool("IsDashAttack") && collision.collider.CompareTag("Player")) {
            playerHealth.TakeDamage(myDatabaseDamage.meleeDamage);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (myAnimator.GetBool("IsWalking") && collision.collider.CompareTag("Player")) {
            playerHealth.TakeDamage(myDatabaseDamage.TimedDamage);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");
        }

        if (myAnimator.GetBool("IsDashAttack") && collision.collider.CompareTag("Player")) {
            playerHealth.TakeDamage(myDatabaseDamage.TimedDamage);
            Movement.Instance.myAnimator.SetTrigger("IsHitted");
        }
    }
    #endregion
    #region OnTrigger
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet")) {
            myHealthModule.TakeDamage(playerDatabaseDamage.bulletDamage);
            MessageManager.CallOnGunnerHitted();
            collision.gameObject.SetActive(false);
        }

        if (myAnimator.GetBool("IsConfuse") && collision.CompareTag("Club")) {
            myHealthModule.TakeDamage(playerDatabaseDamage.meleeDamage);
            MessageManager.CallOnGunnerHitted();
        }
    } 
    #endregion



    private void OnDisable() {
        Ui_Bestiary.numOfGunnerKilled += 1;
    }
}