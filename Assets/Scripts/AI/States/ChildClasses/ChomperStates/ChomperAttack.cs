using UnityEngine;

[RequireComponent(typeof(Chomper))]
public class ChomperAttack : State {
    #region Private attributes
    [SerializeField]
    private float reloadCounter = 5f;
    private float counter = 0f;

    [SerializeField]
    private float attackSpeed = 100f;
    private float AttackSpeed {
        get { return attackSpeed * Time.fixedDeltaTime; }
    }

    private float direction = 0;

    [SerializeField]
    private State nextState = null;

    private Chomper owner = null;
    #endregion

    [SerializeField]
    private DatabaseHealth ChomperDatabaseHealth = null;

    protected override void Awake() {
        //startScale = transform.localScale;

        //SISTEMARE IL FATTO CHE DEVO RIRPENDERE LE REFERENCE QUI.
        //Rigidbody = GetComponent<Rigidbody2D>();
        //SpriteRenderer = GetComponent<SpriteRenderer>();
        base.Awake();
        this.enabled = false;
    }
    protected override void TakeTheReferences() {
        base.TakeTheReferences();
        owner = GetComponent<Chomper>();
    }



    #region OnEnable methods
    protected override void OnEnterState() {
        myAnimator.SetBool("IsAttacking", true);
    }
    #endregion
    #region OnDisable methods
    protected override void OnExitState() {
        myAnimator.SetBool("IsAttacking", false);
    }
    #endregion


    protected override void Start() {
        //set the counter
        counter = reloadCounter;
        //mySpriteRenderer.color = Color.red;
    }



    public override void Update() {
        #region Variables assignment
        direction = (owner.playerTransform.position.x - transform.position.x);
        counter -= Time.deltaTime; 
        #endregion

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
        myRigidbody.velocity = Vector2.right * (direction * AttackSpeed) /*+
                               Gravity(myRigidbody.velocity.y)*/;
    }


    private void Shoot() { 
        //myRigidbody.bodyType = 
    }
    #endregion
}
