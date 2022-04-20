using UnityEngine;

[DisallowMultipleComponent]
public class TeleporterCont : MonoBehaviour {
    #region Serialized attributes
    [SerializeField]
    private EnemyHealthModule bossHealth = null;

    [SerializeField]
    private Teleporter myTeleporter = null;
    #endregion



    private void Start() {
        myTeleporter.gameObject.SetActive(false);
    }



    private void Update() {
        if (bossHealth.Health <= 0) {
            Appear();
        }
    }
    #region Update methods
    private void Appear() {
        myTeleporter.gameObject.SetActive(true);
    }
    #endregion
}