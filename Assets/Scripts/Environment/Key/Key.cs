using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Key : MonoBehaviour {
    #region Attributes
    [SerializeField]
    public DatabaseKey databaseKey = null;
    private BoxCollider2D myCollider = null;
    private SpriteRenderer mySpriteRenderer = null;
    private Animator myAnimator = null;
    #endregion
    #region Constant
    private const int KEY_SORTINGORDER = -1;
    private const string KEYON_TAG = "Key";
    private const string KEYOFF_TAG = "KeyOff";
    #endregion



    void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }
    #endregion



    void Start() {
        VariablesAssignment();
        LoadKeyData();
        gameObject.tag = KEYON_TAG;
        AddListeners();
    }
    #region Start methods
    private void VariablesAssignment() {
        myCollider.isTrigger = true;
        mySpriteRenderer.sprite = databaseKey.Sprite;
        mySpriteRenderer.sortingOrder = KEY_SORTINGORDER;
        myAnimator.speed = databaseKey.AnimatorSpeed;
    }
    private void LoadKeyData() { 
        databaseKey.numOfKeys = Save.Instance.numOfKeys;
    }


    private void AddListeners() {
        MessageManager.OnTouchedTheCheckPoint += SaveKeyData;
    }
    #endregion



    #region Events methods
    private void SaveKeyData() {
        Save.Instance.numOfKeys = databaseKey.numOfKeys;
    }
    #endregion



    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") 
            && gameObject.tag == KEYON_TAG) {
            databaseKey.isTaken = true;
            MessageManager.CallOnTakeTheKey();
            TurnMeOff();
        }
    }
    #region OnTriggerEnter methods
    private void TurnMeOff() {
        gameObject.tag = KEYOFF_TAG;
        gameObject.SetActive(false);
    }
    #endregion



    private void OnDisable() {
        if (databaseKey.isTaken) {
            databaseKey.numOfKeys += 1;
            databaseKey.isTaken = false;
        }
    }



    private void OnDestroy() {
        RemoveListeners();
    }
    #region OnDestroy methods
    private void RemoveListeners() {
        MessageManager.OnTouchedTheCheckPoint -= SaveKeyData;
    }
    #endregion
}
