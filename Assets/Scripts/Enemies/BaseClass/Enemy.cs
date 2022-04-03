using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyHealthModule))]
public abstract class Enemy : MonoBehaviour {
    #region Protected attributes
    [SerializeField]
    protected DatabaseHealth playerDatabaseHealth = null;
    protected Rigidbody2D myRigidbody = null;
    protected SpriteRenderer mySpriteRenderer = null;
    protected Animator myAnimator = null;
    protected EnemyHealthModule myHealthModule = null;
    #endregion
    #region Public property
    public bool IsFlipped {
        get;
        private set;
    } = false;
    #endregion



    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected virtual void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
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



    #region Public methods
    public IEnumerator TurnOffMe() {
        myRigidbody.simulated = false;
        myAnimator.SetBool("IsDead", true);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
    #endregion
}