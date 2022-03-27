using UnityEngine;

[DisallowMultipleComponent]
public class Ui_Keys : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private Animator[] uiKeysAnimators = null;

    [SerializeField]
    private DatabaseKey databaseKey = null;
    #endregion



    void Start() {
        DisableAnimators();
        LoadAnimatorsData();
        AddListeners();
    }
    #region Start methods
    private void DisableAnimators() {
        for (int i = 0; i < uiKeysAnimators.Length; i++) {
            uiKeysAnimators[i].enabled = false;
        }
    }
    private void LoadAnimatorsData() {
        for (int i = 0; i < databaseKey.numOfKeys; i++) {
            EnableAnimators();
        }
    }


    private void AddListeners() {
        MessageManager.OnTakeTheKey += EnableAnimators;
    }
    #endregion



    #region Events methods
    private void EnableAnimators() {
        for (int i = 0; i < uiKeysAnimators.Length; i++) {
            if (!uiKeysAnimators[i].enabled) {
                uiKeysAnimators[i].enabled = true;
                return;
            }
        }
    }
    #endregion



    private void OnDestroy() {
        RemoveListeners();
    }
    #region OnDestroy methods
    private void RemoveListeners() {
        MessageManager.OnTakeTheKey -= EnableAnimators;
    }
    #endregion
}