using UnityEngine;

public class GhostyAttack : State {
    #region Serialized attributes
    [SerializeField]
    private float reloadLifeCounter = 10f;
    [SerializeField]
    private float attackSpeed = 20f;
    [SerializeField]
    private float pulsation = 10f;
    [SerializeField]
    private float amplitude = 3f;
    #endregion
    #region Private attributes
    private float lifeCounter = 0f;
    private Ghosty owner = null;
    private Vector3 playerPosOffset = Vector2.zero;
    #endregion
    #region Properties
    private float AttackSpeed {
        get { return attackSpeed * Time.fixedDeltaTime; }
    }
    #endregion



    #region Awake methods
    protected override void TakeTheReferences() {
        base.TakeTheReferences();

        owner = GetComponent<Ghosty>();
    } 
    #endregion



    protected override void Start() {
        base.Start();

        lifeCounter = reloadLifeCounter; 
        playerPosOffset = Vector3.up;
    }



    public override void Update() {
        base.Update();

        lifeCounter -= Time.deltaTime;

        if (ExitCondition()) {
            owner.myHealthModule.TakeDamage(owner.myHealthModule.maxHealth);
            lifeCounter = reloadLifeCounter;
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        return lifeCounter <= 0f;
    }
    #endregion



    public override void FixedUpdate() {
        base.FixedUpdate();

        Move();
    }
    #region FixedUpdate methods
    private void Move() {
        #region Variable assignment
        Vector2 direction = ((Movement.Instance.transform.position + playerPosOffset) - transform.position).normalized;
        #endregion

        myRigidbody.velocity = (direction * AttackSpeed) + (Vector2.up * (Mathf.Sin(Time.time * pulsation) * amplitude));
    }
    #endregion
}