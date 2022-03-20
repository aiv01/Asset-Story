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



    private void OnEnable() {
        playerIsFlipped = Movement.IsFlipped ? true : false;
        mySpriteRenderer.flipX = playerIsFlipped ? true : false;
        counter = databaseBullet.ReloadLifeCounter;
    }



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



    private void Start() {
        VariablesAssignment();
    }
    #region Start methods
    private void VariablesAssignment() {
        //SpriteRenderer
        mySpriteRenderer.sprite = databaseBullet.Sprite;
        //Set counter
        //databaseBullet.SetLifeCounter();
    }
    #endregion



    private void Update() {
        counter -= Time.deltaTime;
        if (counter <= 0) {
            DestroyMe();
            //databaseBullet.SetLifeCounter();
            counter = reloadCounter;
        }
        //Debug.Log(databaseBullet.lifeCounter);

        //databaseBullet.lifeCounter -= Time.deltaTime;
        //if (databaseBullet.lifeCounter <= 0) {
        //    DestroyMe();
        //    databaseBullet.SetLifeCounter();
        //}
        //Debug.Log(databaseBullet.lifeCounter);
    }
    private void DestroyMe() {
        gameObject.SetActive(false);

    }

    //amplitude = altezza dell'onda.
    //FUNZIONE DI SENO
    //float amplitude = 3f;
    //float pulsation = 10f;

    //float accumulator;

    private void FixedUpdate() {
        Move();
    }
    private void Move() {
        //Vector2 direction = Movement.IsFlipped ? -Vector2.right :
        //                    Vector2.right;


        //da pulire
        Vector2 direction = !playerIsFlipped ? Vector2.right : -Vector2.right;
        //myRigidbody.velocity = (direction).normalized * databaseBullet.Speed;

        //FORMA CORRETTA!
        myRigidbody.velocity = direction /*Vector2.right*/ * databaseBullet.Speed;

        //FORMA CON FUNZIONE DI SENO
        //myRigidbody.velocity = (direction * databaseBullet.Speed) /*Vector2.right*/ + (Vector2.up * (Mathf.Sin(Time.time * pulsation) * amplitude));

        //accumulator += Time.deltaTime * 10;
        //myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,
        //    (float)Mathf.Cos(accumulator) * 3);

        Debug.Log(myRigidbody.velocity.x);
    }
}
