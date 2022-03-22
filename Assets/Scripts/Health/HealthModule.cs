using UnityEngine;

[DisallowMultipleComponent]
public class HealthModule : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private DatabaseHealth databaseHealth = null; 
    #endregion



    private void Start() {
        databaseHealth.LifeAssign();
    }



    private void Update() {
        if (Died()) {
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            TakeDamage(3);
        }


        Debug.Log(databaseHealth.Health);
        Debug.Log(databaseHealth.CurrentHealthPercentage);
    }



    #region Public methods
    public void TakeHealth(float _health) {
        databaseHealth.Health += _health;
    }
    public void TakeDamage(float _damage) {
        databaseHealth.Health -= _damage;
    }
    #endregion



    #region Private methods
    private bool Died() {
        return databaseHealth.Health <= 0;
    }
    #endregion
}
