using UnityEngine;

public class Attack : State {
    #region Private attributes
    [SerializeField]
    private float reloadCounter = 5f;
    private float counter = 0f;

    [SerializeField]
    private float attackSpeed = 100f;
    private float AttackSpeed {
        get { return attackSpeed * Time.fixedDeltaTime; }
    }

    private Vector2 direction = Vector2.zero;

    [SerializeField]
    private State nextState = null;
    #endregion



    protected override void Awake() {
        //startScale = transform.localScale;

        //SISTEMARE IL FATTO CHE DEVO RIRPENDERE LE REFERENCE QUI.
        //Rigidbody = GetComponent<Rigidbody2D>();
        //SpriteRenderer = GetComponent<SpriteRenderer>();
        base.Awake();
        this.enabled = false;
    }



    protected override void OnEnterState() {
        myAnimator.SetBool("IsAttacking", true);
        mySpriteRenderer.color = Color.red;
    }
    protected override void OnExitState() {
        myAnimator.SetBool("IsAttacking", false);
        mySpriteRenderer.color = Color.white;
    }



    protected override void Start() {
        //set the counter
        counter = reloadCounter;
        mySpriteRenderer.color = Color.red;
    }



    public override void Update() {
        direction = (playerTransform.position - transform.position);
        counter -= Time.deltaTime;

        if (ExitCondition()) {
            counter = reloadCounter;
            this.enabled = false;
            nextState.enabled = true;
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        return counter <= 0f;
    } 
    #endregion



    public override void FixedUpdate() {
        Move();
    }
    #region FixedUpdate methods
    private void Move() {
        myRigidbody.velocity = (direction.normalized * AttackSpeed) +
                               Gravity(myRigidbody.velocity.y);
    } 
    #endregion
}
