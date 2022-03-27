using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HealthModule))]
public class Enemy : MonoBehaviour {
    #region Attributes and properties
    [SerializeField]
    private EnemyType myEnemyType = EnemyType.chomper;
    public EnemyType MyEnemyType {
        get { return myEnemyType; }
    }

    //References
    private Rigidbody2D myRigidbody = null;
    private SpriteRenderer mySpriteRenderer = null;
    private HealthModule myHealthModule = null;
    #endregion
    #region Static property
    public static bool IsFlipped {
        get;
        private set;
    } = false; 
    #endregion


    private void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myHealthModule = GetComponent<HealthModule>();
    } 
    #endregion



    private void Update() {
        IsFlipped = mySpriteRenderer.flipX;
        FlipMe();
    }
    #region Update methods
    private void FlipMe() {
        if (myRigidbody.velocity.x <= 0.9f) {
            mySpriteRenderer.flipX = true;
        }
        else {
            mySpriteRenderer.flipX = false;
        }
    }
    #endregion



    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            myHealthModule.TakeDamage(2);
        }
    }
}
