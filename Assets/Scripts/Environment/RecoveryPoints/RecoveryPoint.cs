using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class RecoveryPoint : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private DatabaseRecoveryPoint databaseRecoveryPoint = null;
    [HideInInspector]
    public HealthModule playerHealth = null;


    private BoxCollider2D myCollider = null;
    private SpriteRenderer mySpriteRenderer = null;
    #endregion
    #region Constant
    private const int RECOVERYPOINT_SORTINGORDER = -1;
    #endregion



    private void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion



    private void Start() {
        VariablesAssignment();
    }
    #region Start methods
    private void VariablesAssignment() {
        mySpriteRenderer.sprite = databaseRecoveryPoint.StartingSprite;
        mySpriteRenderer.sortingOrder = RECOVERYPOINT_SORTINGORDER;
    } 
    #endregion



    #region OnCollision methods
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            mySpriteRenderer.sprite = databaseRecoveryPoint.GetSprite((int)EnvironmentSpriteType.On);
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            playerHealth.TakeHealth(databaseRecoveryPoint.TimedLifeAmount);
            MessageManager.CallOnTakeTheHealth();
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            mySpriteRenderer.sprite = databaseRecoveryPoint.GetSprite((int)EnvironmentSpriteType.Off);
        }
    }
    #endregion
}