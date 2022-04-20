using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class HealthModule : MonoBehaviour {
    #region Attributes
    [SerializeField]
    public DatabaseHealth databaseHealth = null;

    public float maxHealth = 10f;
    private float health = 0f;


    public float Health {
        get { return health; }
        set {
            health = value > maxHealth ? health = maxHealth :
                     value < 0 ? health = 0 : health = value;
        }
    }


    public float CurrentHealthPercentage {
        get { return Health / maxHealth; }
    }


    public static bool IsDead {
        get;
        private set;
    } = false;
    #endregion


    private void Awake() {
        health = maxHealth;
    }


    private void Start() {
        LoadHealthData();
        AddListeners();
    }
    #region Start methods
    private void LoadHealthData() {
        Health = Save.Instance.playerHealth;
    }
    private void AddListeners() {
        MessageManager.OnTouchedTheCheckPoint += SaveHealthData;
    }
    #endregion



    #region Events methods
    public void SaveHealthData() {
        Save.Instance.playerHealth = Health;
    }
    #endregion
    


    private void Update() {
        if (Died()) {
            IsDead = true;
            StartCoroutine(Movement.Instance.Death());
            SceneManager.LoadScene(SceneType.DeathScene.ToString());
        }
        //if (Health < 0) {
        //    Health = 0;
        //}
        //else if (Health > maxHealth) {
        //    Health = maxHealth;
        //}

        Debug.Log($"VITA {Health}");
    }



    #region Public methods
    public void TakeHealth(float _health) {
        Health += _health;
    }
    public void TakeDamage(float _damage) {
        Health -= _damage;
    }
    #endregion



    #region Private methods
    private bool Died() {
        return Health <= 0;
    }
    #endregion



    private void OnDestroy() {
        RemoveListeners();
    }
    #region OnDestroy methods
    private void RemoveListeners() {
        MessageManager.OnTouchedTheCheckPoint -= SaveHealthData;
    }
    #endregion
}
