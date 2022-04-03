using UnityEngine;

[DisallowMultipleComponent]
public class EnemyHealthModule : MonoBehaviour {
    #region Private attributes
    [SerializeField]
    private float maxHealth = 0f;
    private float health = 0f;
    private Animator myAnimator = null;
    private Enemy owner = null;
    #endregion
    #region Public properties
    public float Health {
        get { return health; }
        set {
            health = value > maxHealth ? health = maxHealth :
                     value < 0 ? health = 0 : health = value;
        }
    }
    #endregion



    void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myAnimator = gameObject.GetComponent<Animator>();
        owner = GetComponent<Enemy>();
    }
    #endregion



    void Start() {
        VariablesAssignment();
    }
    #region Start methods
    private void VariablesAssignment() {
        health = maxHealth;
    }
    #endregion



    void Update() {
        if (Died()) {
            StartCoroutine(owner.TurnOffMe());
        }
    }
    #region Update methods
    private bool Died() {
        return health <= 0;
    }
    #endregion



    #region Public methods
    public void TakeDamage(float _damage) {
        health -= _damage;
    }
    public void TakeHealth(float _health) {
        health += _health;
    }
    #endregion
}