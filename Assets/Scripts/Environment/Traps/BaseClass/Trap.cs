using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Trap : MonoBehaviour {
    #region Attributes
    [SerializeField]
    protected DatabaseHealth playerDatabaseHealth = null;
    [SerializeField]
    protected DatabaseTrap databaseTrap = null;

    protected SpriteRenderer mySpriteRenderer = null;
    protected Collider2D myCollider = null;
    #endregion



    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected virtual void TakeTheReferences() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<Collider2D>();
    }
    #endregion



    protected virtual void Start() {
        VariablesAssignment();
    }
    #region Start methods
    protected virtual void VariablesAssignment() {
        if (myCollider is BoxCollider2D myBoxCollider) {
            myBoxCollider.size = mySpriteRenderer.size;
        }
    }
    #endregion



    protected virtual void Update() {

    }



    protected virtual void FixedUpdate() {

    }
}
