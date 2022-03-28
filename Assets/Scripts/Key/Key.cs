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
    private Color startColor = Vector4.zero;
    private Vector4 keyRecoveredColor = Vector4.zero;
    #region Constant
    private const int KEY_SORTINGORDER = -1;
    private const float ALPHA_VALUE = 0.5f;

    private const string KEYON_TAG = "Key";
    private const string KEYOFF_TAG = "KeyOff";
    #endregion

   
    //public static int numOfInstance = -1;

    void Awake() {
        TakeTheReferences();

        //numOfInstance += 1;
        //numOfInstance += 1;
        //Debug.Log($"NUMERO DI ISTANZE {numOfInstance}");
    }
    #region Awake methods
    private void TakeTheReferences() {
        myCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }
    #endregion

    //private string TagAttuale;

    void Start() {
        VariablesAssignment();

        gameObject.tag = KEYON_TAG;

        AddListeners();
    }
    #region Start methods
    private void VariablesAssignment() {
        myCollider.isTrigger = true;
        mySpriteRenderer.sprite = databaseKey.Sprite;
        mySpriteRenderer.sortingOrder = KEY_SORTINGORDER;

        myAnimator.speed = databaseKey.AnimatorSpeed;

        startColor = mySpriteRenderer.color;
        keyRecoveredColor = new Vector4(mySpriteRenderer.color.r, mySpriteRenderer.color.g,
                                        mySpriteRenderer.color.b, ALPHA_VALUE);

        LoadKeyData();

    }
    private void LoadKeyData() { 
        databaseKey.numOfKeys = Save.Instance.numOfKeys;

        //if (numOfInstance == 0) {
        //    gameObject.tag = Save.Instance.keytags[numOfInstance];

        //}

        ////numOfInstance
        //if (numOfInstance == 0) {
        //    //string TagAttuale = Save.Instance.keytag_1;
        //    //gameObject.tag = TagAttuale;
        //    //Debug.Log(gameObject.tag);
        //    gameObject.tag = Save.Instance.keytag_1;
        //    //numOfInstance += 1;
        //    Debug.Log($"KEYTAG 1 START { Save.Instance.keytag_1 }");
        //    return;

        //}
        ////numOfInstance
        //if (/*databaseKey.keyID*/  numOfInstance == 1) {
        //    //string TagAttuale = Save.Instance.keytag_2;
        //    //gameObject.tag = TagAttuale;
        //    //Debug.Log(gameObject.tag);

        //    gameObject.tag = Save.Instance.keytag_2;
        //    //numOfInstance += 1;
        //    Debug.Log($"KEYTAG 2 START { Save.Instance.keytag_2 }");
        //    return;

        //}
        ////numOfInstance
        //if (/*databaseKey.keyID */ numOfInstance == 2) {
        //    //string TagAttuale = Save.Instance.keytag_3;
        //    //gameObject.tag = TagAttuale;
        //    //Debug.Log(gameObject.tag);

        //    gameObject.tag = Save.Instance.keytag_3;
        //    //numOfInstance += 1;

        //    Debug.Log($"KEYTAG 3 START { Save.Instance.keytag_3 }");
        //    return;

        //}

        //gameObject.tag = Save.Instance.keytags[numOfInstance];
    }


    private void AddListeners() {
        MessageManager.OnTouchedTheCheckPoint += SaveKeyData;
    }
    #endregion




    #region Events methods
    private void SaveKeyData() {
        Save.Instance.numOfKeys = databaseKey.numOfKeys;
        //numOfInstance
        //if (/*databaseKey.keyID*/ numOfInstance == 0) {
        //    Save.Instance.keytag_1 = gameObject.tag;
        //    Debug.Log($"KEYTAG 1 { Save.Instance.keytag_1 }");
        //    return;
        //}
        ////numOfInstance
        //if (/*databaseKey.keyID*/ numOfInstance == 1) {

        //    Save.Instance.keytag_2 = gameObject.tag;
        //    Debug.Log($"KEYTAG 2 { Save.Instance.keytag_2 }");
        //    return;

        //}
        ////numOfInstance
        //if (/*databaseKey.keyID */ numOfInstance == 2) {
        //    Save.Instance.keytag_3 = gameObject.tag;
        //    Debug.Log($"KEYTAG 3 { Save.Instance.keytag_3 }");
        //    return;

        //}



        //Save.Instance.keytags[numOfInstance] = gameObject.tag;
    }
    #endregion

    [SerializeField]
    DatabaseDoor databaseDoor = null;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") /*&&
            databaseKey.numOfKeys < databaseDoor.KeysNeeded*/
            && gameObject.tag == KEYON_TAG
           /* databaseKey.keyID >= 0 && databaseKey.keyID <= 2*/) {
            databaseKey.isTaken = true;
            //numOfInstance += 1;
            MessageManager.CallOnTakeTheKey();
            TurnMeOff();
        }
    }
    #region OnTriggerEnter methods
    private void TurnMeOff() {
        gameObject.tag = KEYOFF_TAG;
        //databaseKey.keyID = -1;
        gameObject.SetActive(false);
    }
    #endregion



    private void OnDisable() {
        if (databaseKey.isTaken) {
            databaseKey.numOfKeys += 1;
            //databaseKey.isTaken = false;
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


    private void Update() {
        //if (databaseKey.numOfKeys >= databaseDoor.KeysNeeded) {
        //    mySpriteRenderer.color = keyRecoveredColor;
        //}
        //else {
        //    mySpriteRenderer.color = startColor;
        //}
        Debug.Log(gameObject.tag);
        //Debug.Log($"NUMERO DI CHIAVI {databaseKey.numOfKeys}");


        //if (gameObject.tag == KEYOFF_TAG) {
        //    mySpriteRenderer.color = keyRecoveredColor;
        //}
        //else {
        //    mySpriteRenderer.color = startColor;
        //}



        //Debug.Log($"NUMERO DI CHIAVI {Save.Instance.numOfKeys}");


        //if (databaseKey.keyID < 0 || databaseKey.keyID > 2) {
        //    mySpriteRenderer.color = keyRecoveredColor;
        //}
        //else {
        //    mySpriteRenderer.color = startColor;
        //}











        //if (/*databaseKey.keyID*/ KeyID == 0) {
        //    Save.Instance.keytag_1 = gameObject.tag;
        //    Debug.Log($"KEYTAG 1 { Save.Instance.keytag_1 }");
        //}
        ////numOfInstance
        //if (/*databaseKey.keyID*/ KeyID == 1) {

        //    Save.Instance.keytag_2 = gameObject.tag;
        //    Debug.Log($"KEYTAG 2 { Save.Instance.keytag_2 }");


        //}
        ////numOfInstance
        //if (/*databaseKey.keyID */ KeyID == 2) {
        //    Save.Instance.keytag_3 = gameObject.tag;
        //    Debug.Log($"KEYTAG 3 { Save.Instance.keytag_3 }");


        //}
    }
}
