using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
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



    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "WallTile") {
            myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
