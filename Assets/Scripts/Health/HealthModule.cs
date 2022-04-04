using UnityEngine;

[DisallowMultipleComponent]
public class HealthModule : MonoBehaviour {
    #region Attributes
    [SerializeField]
    public DatabaseHealth databaseHealth = null;

    private float health = 0f;
    #endregion



    private void Start() {
        LoadHealthData();
        AddListeners();
    }
    #region Start methods
    private void LoadHealthData() {
        databaseHealth.Health = Save.Instance.playerHealth;
    }
    private void AddListeners() {
        MessageManager.OnTouchedTheCheckPoint += SaveHealthData;
        MessageManager.OnNewGame += SaveDefaultHealthData;
    }
    #endregion



    #region Events methods
    public void SaveHealthData() {
        Save.Instance.playerHealth = databaseHealth.Health;
    }
    public void SaveDefaultHealthData() {
        Save.Instance.playerHealth = databaseHealth.MaxHealth;
    }
    #endregion
    


    private void Update() {
        if (Died()) {
            StartCoroutine(Movement.Instance.Death());
        }
    }



    #region Public methods
    //public void TakeHealth(float _health) {
    //    databaseHealth.Health += _health;
    //}
    //public void TakeDamage(float _damage) {
    //    databaseHealth.Health -= _damage;
    //}

    public void TakeHealth(float _health) {
        health += _health;
    }
    public void TakeDamage(float _damage) {
        health -= _damage;
    }
    #endregion



    #region Private methods
    private bool Died() {
        return databaseHealth.Health <= 0;
    }
    #endregion



    private void OnDestroy() {
        RemoveListeners();
    }
    #region OnDestroy methods
    private void RemoveListeners() {
        MessageManager.OnTouchedTheCheckPoint -= SaveHealthData;
        MessageManager.OnNewGame -= SaveDefaultHealthData;
    }
    #endregion
}
