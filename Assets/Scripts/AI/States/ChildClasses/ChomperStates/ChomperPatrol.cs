using UnityEngine;

[RequireComponent(typeof(Chomper))]
public class ChomperPatrol : State {
    #region Private attributes
    private Chomper owner = null;

    [SerializeField]
    private float minDist = 0f;

    [SerializeField]
    private State nextState = null;

    [SerializeField]
    private float speed = 0f;
    private float Speed {
        get { return speed * Time.fixedDeltaTime; }
    }

    private float diff = 0f;

    private Vector2 startPosition = Vector2.zero;


    private bool change = false;

    [SerializeField]
    private float maxPath = 250f;
    #endregion



    #region Awake methods
    protected override void TakeTheReferences() {
        base.TakeTheReferences();
        owner = GetComponent<Chomper>();
    } 
    #endregion



    protected override void Start() {
        startPosition = transform.position;
    }



    public override void Update() {
        if (ExitCondition()) {
            this.enabled = false;
            nextState.enabled = true;
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        #region Variable assignment
        float distFromPlayer = (transform.position - owner.playerTransform.position).magnitude;
        #endregion

        return distFromPlayer <= minDist;
    } 
    #endregion



    public override void FixedUpdate() {
        Movement();
    }
    #region FixedUpdate methods
    private void Movement() {
        #region Variables assignment
        Vector2 direction = change ? Vector2.right : -Vector2.right;
        Vector2 flat = FlattenVector(transform.position);
        #endregion

        diff += Mathf.Abs(flat.x - startPosition.x);

        if (diff > maxPath) {
            startPosition = transform.position;
            change = !change;
            diff = 0f;
        }

        myRigidbody.velocity = (direction.normalized * Speed) + Gravity(myRigidbody.velocity.y);
    } 
    #endregion
}
