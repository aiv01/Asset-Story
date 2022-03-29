using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Trap : MonoBehaviour {
    #region Attributes
    [SerializeField]
    protected DatabaseTrap databaseTrap = null; 
    [SerializeField]
    protected DatabaseHealth playerDatabaseHealth = null;
    protected Collider2D myCollider = null;
    protected SpriteRenderer mySpriteRenderer = null;
    #endregion
    #region Constant
    private const int TRAP_SORTINGORDER = 1;
    #endregion



    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected virtual void TakeTheReferences() {
        myCollider = GetComponent<Collider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    } 
    #endregion



    protected virtual void Start() {
        VariablesAssignment();
    }
    #region Start methods
    protected virtual void VariablesAssignment() {
        myCollider.isTrigger = true;
        mySpriteRenderer.sortingOrder = TRAP_SORTINGORDER;
    } 
    #endregion



    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerDatabaseHealth.TakeDamage(databaseTrap.Damage);
        }
    }
}