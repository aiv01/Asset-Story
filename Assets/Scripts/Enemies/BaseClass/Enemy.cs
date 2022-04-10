using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyHealthModule))]
public abstract class Enemy : MonoBehaviour {
    #region Public attributes
    [HideInInspector]
    public BoxCollider2D myCollider = null;
    public HealthModule playerHealth = null;
    [HideInInspector]
    public Rigidbody2D myRigidbody = null;
    [HideInInspector]
    public SpriteRenderer mySpriteRenderer = null;
    [HideInInspector]
    public Animator myAnimator = null;
    [HideInInspector]
    public EnemyHealthModule myHealthModule = null;
    [HideInInspector]
    public Transform playerTransform = null;
    #endregion
    #region Public property
    public bool IsFlipped {
        get;
        set;
    } = false;
    #endregion
    #region Constant
    private const int ENEMY_SORTINGORDER = 1;
    #endregion



    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected virtual void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myHealthModule = GetComponent<EnemyHealthModule>();
    }
    #endregion



    protected virtual void Start() {
        VariablesAssignment();
    }
    #region Start methods
    protected virtual void VariablesAssignment() {
        mySpriteRenderer.sortingOrder = ENEMY_SORTINGORDER;
    } 
    #endregion



    protected virtual void Update() {
        IsFlipped = mySpriteRenderer.flipX;
        FlipMe();
    }
    #region Update methods
    protected virtual void FlipMe() { 
    }
    #endregion
}