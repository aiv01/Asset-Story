using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour {
    #region Protected attributes
    protected Rigidbody2D myRigidbody = null;
    protected CircleCollider2D myCollider = null;
    protected SpriteRenderer mySpriteRenderer = null;

    protected float counter = 0;
    protected float reloadCounter = 5f;
    protected bool IsFlipped = false;

    [SerializeField]
    public HealthModule playerHealth = null;
    #endregion
    #region Public attributes
    public DatabaseBullet databaseBullet = null;
    [HideInInspector]
    public Vector2 direction = Vector2.zero;
    #endregion



    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected virtual void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CircleCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion



    protected virtual void OnEnable() {
        VariablesAssignment();
    }
    #region OnEnable methods
    protected virtual void VariablesAssignment() {
        //playerIsFlipped = Movement.IsFlipped ? true : false;
        gameObject.tag = "Bullet";
        //myCollider.isTrigger = true;
        //mySpriteRenderer.sprite = databaseBullet.Sprite;
        //mySpriteRenderer.flipX = IsFlipped ? true : false;
        reloadCounter = databaseBullet.ReloadLifeCounter;
        counter = reloadCounter;
    } 
    #endregion



    protected virtual void Update() {
        counter -= Time.deltaTime;

        FlipMe();

        if (counter <= 0) {
            DestroyMe();
            counter = reloadCounter;
        }
    }
    #region Update methods
    private void FlipMe() {
        mySpriteRenderer.flipX = IsFlipped;
    }


    protected virtual void DestroyMe() {
        gameObject.SetActive(false);
    }
    #endregion



    protected virtual void FixedUpdate() {
        Move();
    }
    #region FixedUpdate methods
    protected virtual void Move() {
        myRigidbody.velocity = direction.normalized * databaseBullet.Speed;
    }
    #endregion



    protected virtual void OnCollisionEnter2D(Collision2D collision) {
        DestroyMe();
    }


    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Shield")) {
            DestroyMe();
        }
    }
}