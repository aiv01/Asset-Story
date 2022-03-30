using UnityEngine;

[DisallowMultipleComponent]
public class KeyManager : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private GameObject[] keys = null;
    [SerializeField]
    private DatabaseKey databaseKey = null;
    #endregion



    void Start() {
        LoadKeysData();
    }
    #region Start methods
    private void LoadKeysData() {
        for (int i = 0; i < databaseKey.numOfKeys; i++) {
            if (keys[i].activeSelf) {
                keys[i].SetActive(false);
            }
        }
    }
    #endregion
}