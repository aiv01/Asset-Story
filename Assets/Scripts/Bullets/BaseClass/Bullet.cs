using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour {
    #region Public attributes
    public DatabaseBullet databaseBullet = null;
    #endregion
    #region Private attributes
    protected Rigidbody2D myRigidbody = null;
    protected CircleCollider2D myCircleCollider = null;
    protected SpriteRenderer mySpriteRenderer = null;

    protected float counter = 0;
    protected float reloadCounter = 5f;
    protected bool IsFlipped = false;
    #endregion



    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected virtual void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();
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
        //mySpriteRenderer.sprite = databaseBullet.Sprite;
        //mySpriteRenderer.flipX = IsFlipped ? true : false;
        reloadCounter = databaseBullet.ReloadLifeCounter;
        counter = reloadCounter;
    } 
    #endregion



    protected virtual void Update() {
        counter -= Time.deltaTime;

        if (counter <= 0) {
            DestroyMe();
            counter = reloadCounter;
        }
    }
    #region Update methods
    protected virtual void DestroyMe() {
        gameObject.SetActive(false);
    }
    #endregion



    protected virtual void FixedUpdate() {
        Move();
    }
    #region FixedUpdate methods
    protected virtual void Move() {
        #region Variable assignment
        Vector2 direction = !IsFlipped ? Vector2.right : -Vector2.right;
        #endregion

        myRigidbody.velocity = direction.normalized * databaseBullet.Speed;
    }
    #endregion



    //private void OnCollisionEnter2D(Collision2D collision) {
    //    if (collision.collider.CompareTag("Enemy") ||
    //      collision.collider.CompareTag("Bullet") ||
    //      collision.collider.CompareTag("Player")) {
    //        DestroyMe();
    //    }
    //}
}
