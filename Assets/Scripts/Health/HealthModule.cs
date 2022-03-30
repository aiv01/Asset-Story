using UnityEngine;

[DisallowMultipleComponent]
public class HealthModule : MonoBehaviour {
    #region Attributes
    [SerializeField]
    public DatabaseHealth databaseHealth = null;

    private float health = 0f;
    #endregion


    private void Awake() {
        
    }

    private void Start() {
        //databaseHealth.LifeAssign();
        LoadHealthData();
        Debug.Log($"HEALTH VALUE {databaseHealth.Health}");
        AddListeners();

        health = databaseHealth.Health;
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
            gameObject.SetActive(false);
        }

        //if (Input.GetKeyDown(KeyCode.P)) {
        //    databaseHealth.TakeDamage(3);
        //}

        //if (Input.GetKeyDown(KeyCode.L)) {
        //    databaseHealth.TakeHealth(2);
        //}

        Debug.Log(databaseHealth.Health);
        Debug.Log(databaseHealth.CurrentHealthPercentage);
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
