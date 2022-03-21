using UnityEngine;

public abstract class State : MonoBehaviour {
    #region Attributes
    protected Rigidbody2D myRigidbody = null;
    protected SpriteRenderer mySpriteRenderer = null;
    protected Animator myAnimator = null;

    [SerializeField]
    protected Transform playerTransform = null;
    #endregion



    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }
    #endregion



    protected virtual void OnEnable() {
        OnEnterState();    
    }
    #region OnEnable methods
    protected virtual void OnEnterState() { } 
    #endregion



    protected virtual void Start() { }



    public virtual void Update() { }



    public virtual void FixedUpdate() { }



    protected virtual void OnDisable() {
        OnExitState();
    }
    #region OnDisable methods
    protected virtual void OnExitState() { } 
    #endregion



    protected abstract bool ExitCondition();



    #region Reusable methods
    protected Vector2 FlattenVector(Vector3 _toFlatten) {
        Vector2 flatVector = new Vector2(_toFlatten.x, _toFlatten.y);
        return flatVector;
    }


    protected Vector2 Gravity(float _gravity) {
        return _gravity * Vector2.up;
    }
    #endregion
}
