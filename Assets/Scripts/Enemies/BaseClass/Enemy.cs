using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HealthModule))]
public abstract class Enemy : MonoBehaviour {
    #region Protected attributes
    [SerializeField]
    protected DatabaseHealth playerDatabaseHealth = null;
    protected Rigidbody2D myRigidbody = null;
    protected SpriteRenderer mySpriteRenderer = null;
    protected Animator myAnimator = null;
    protected HealthModule myHealthModule = null;
    #endregion
    #region Static property
    public static bool IsFlipped {
        get;
        private set;
    } = false;

    //public bool IsFlipped {
    //    get;
    //    private set;
    //} = false;
    #endregion



    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected virtual void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myHealthModule = GetComponent<HealthModule>();
    }
    #endregion



    protected virtual void Start() {
        VariablesAssignment();
    }
    #region Start methods
    protected virtual void VariablesAssignment() {
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