using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Shield : MonoBehaviour {
    #region Serialized attributes
    [SerializeField]
    public int shieldHp = 0;

    [SerializeField]
    public Sprite[] mySprites = null;
    #endregion
    #region Private attributes
    //public CircleCollider2D myCollider = null;
    //public SpriteRenderer mySpriteRenderer = null;
    [SerializeField]
    public int shieldLife = 0;
    #endregion
    #region Singleton
    public static Shield Instance {
        get;
        private set;
    } = null;
    #endregion


    private void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        //myCollider = GetComponent<CircleCollider2D>();
        //mySpriteRenderer = GetComponent<SpriteRenderer>();
        Instance = this;
    }
    #endregion



    private void OnEnable() {
        shieldLife = shieldHp;
        //mySpriteRenderer.sprite = mySprites[2];
    }


    private void Start() {
        
    }
    private void VariablesAssignment() { 
       
    }



    private void Update() {
        CheckLife();
    }
    #region Update methods
    private void CheckLife() {
        if (shieldLife <= 0) {
            gameObject.SetActive(false);
        }
    }
    #endregion


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Enemy") ||
            collision.collider.CompareTag("Bullet")) {
            shieldLife -= 1;
            //mySpriteRenderer.sprite = mySprites[shieldLife];
        }
    }
}