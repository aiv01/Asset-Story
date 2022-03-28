using UnityEngine;

[DisallowMultipleComponent]
public class KeyManager : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private Key[] keys = null;
    [SerializeField]
    private DatabaseKey databaseKey = null;
    #endregion


    void Awake() {

    }
    #region Awake methods
    #endregion



    void Start() {
        LoadKeysData();
    }
    #region Start methods
    private void LoadKeysData() {
        for (int i = 0; i < databaseKey.numOfKeys; i++) {
            if (keys[i].gameObject.activeSelf) {
                keys[i].gameObject.SetActive(false);

                //if (gameObject.tag == KEYOFF_TAG) {
                //    mySpriteRenderer.color = keyRecoveredColor;
                ////}
                //else {
                //    mySpriteRenderer.color = startColor;
                //}
            }
            //VERSIONE DI OBLITERAZIONE
            //if (keys[i].databaseKey.isTaken) {
            //    //    keys[i].gameObject.SetActive(false);

            //    //keys[i].gameObject.tag = "KeyOff";
            //}
        }
    }
    #endregion



    void Update() {
        //Debug.Log(gameObject.tag);
        ////Debug.Log($"NUMERO DI CHIAVI {databaseKey.numOfKeys}");


        //if (gameObject.tag == KEYOFF_TAG) {
        //    mySpriteRenderer.color = keyRecoveredColor;
        //}
        //else {
        //    mySpriteRenderer.color = startColor;
        //}
    }
    #region Update methods
    #endregion

   
    
    void FixedUpdate() {

    }
    #region FixedUpdate methods
    #endregion

    
    #region Public methods
    #endregion

     

    #region Private methods
    #endregion


    
    #region OnCollision methods
    #endregion
    


    #region OnTrigger methods
    #endregion 
}
