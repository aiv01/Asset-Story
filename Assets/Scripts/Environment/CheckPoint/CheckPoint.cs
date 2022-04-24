using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CheckPoint : MonoBehaviour {
    #region Attributes
    private bool isFirstTime = true;
    [SerializeField]
    private DatabaseCheckPoint databaseCheckPoint = null;
    private BoxCollider2D myCollider = null;
    private SpriteRenderer mySpriteRenderer = null;
    #endregion
    #region Constant
    private const int CHECKPOINT_SORTINGORDER = -1;
    #endregion



    void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion



    void Start() {
        VariablesAssignment();
    }
    #region Start methods
    private void VariablesAssignment() {
        myCollider.isTrigger = true;
        mySpriteRenderer.sortingOrder = CHECKPOINT_SORTINGORDER;
        mySpriteRenderer.sprite = databaseCheckPoint.StartingSprite;
    }
    #endregion



    private void OnTriggerEnter2D(Collider2D collision) {
        if (isFirstTime && collision.CompareTag("Player") ) {
            ActivateCheckPoint();
            SaveData();
        }
    }
    #region OnTrigger methods
    private void ActivateCheckPoint() {
        mySpriteRenderer.sprite = databaseCheckPoint.GetSprite((int)EnvironmentSpriteType.On);
        isFirstTime = false;
    }
    private void SaveData() {
        MessageManager.CallOnTouchedTheCheckPoint();
    }
    #endregion
}