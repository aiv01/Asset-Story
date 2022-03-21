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
    private Rigidbody2D myRigidbody = null;
    private CircleCollider2D myCircleCollider = null;
    private SpriteRenderer mySpriteRenderer = null;


    private float counter = 0;
    private float reloadCounter = 5f;
    private bool playerIsFlipped = false;
    #endregion



    private void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion



    private void OnEnable() {
        VariablesAssignment();
    }
    #region OnEnable methods
    private void VariablesAssignment() {
        playerIsFlipped = Movement.IsFlipped ? true : false;
        mySpriteRenderer.sprite = databaseBullet.Sprite;
        mySpriteRenderer.flipX = playerIsFlipped ? true : false;
        reloadCounter = databaseBullet.ReloadLifeCounter;
        counter = reloadCounter;
    } 
    #endregion



    private void Update() {
        counter -= Time.deltaTime;

        if (counter <= 0) {
            DestroyMe();
            counter = reloadCounter;
        }
    }
    #region Update methods
    private void DestroyMe() {
        gameObject.SetActive(false);
    }
    #endregion



    private void FixedUpdate() {
        Move();
    }
    #region FixedUpdate methods
    private void Move() {
        #region Variable assignment
        Vector2 direction = !playerIsFlipped ? Vector2.right : -Vector2.right;
        #endregion

        myRigidbody.velocity = direction.normalized * databaseBullet.Speed;
    } 
    #endregion
}
