using UnityEngine;

[DisallowMultipleComponent]
public class TrapManager : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private GameObject[] myTraps = null;
    #endregion



    private void Start() {
        TurnOffTraps();
        ActivateRandomTrap();
    }
    #region Start methods
    private void TurnOffTraps() {
        for (int i = 0; i < myTraps.Length; i++) {
            myTraps[i].SetActive(false);
        }
    }
    private void ActivateRandomTrap() {
        myTraps[Random.Range(0, myTraps.Length)].SetActive(true);
    }
    #endregion
}