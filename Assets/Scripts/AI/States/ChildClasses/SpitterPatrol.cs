using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class SpitterPatrol : State {
    #region Private attributes
    private Enemy enemy = null;

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
    private float maxPath = 30f;
    #endregion


    #region Awake methods
    protected override void TakeTheReferences() {
        base.TakeTheReferences();
        enemy = GetComponent<Enemy>();
    }
    #endregion





    public override void Update() {
        if (ExitCondition()) {
            this.enabled = false;
            nextState.enabled = true;
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        #region Variable assignment
        float distFromPlayer = (transform.position - playerTransform.position).magnitude;
        #endregion

        return distFromPlayer <= minDist;
    }
    #endregion



    public override void FixedUpdate() {
        //Movement();
    }
    //#region FixedUpdate methods
    //private void Movement() {
    //    #region Variables assignment
    //    Vector2 direction = change ? Vector2.right : -Vector2.right;
    //    Vector2 flat = FlattenVector(transform.position);
    //    #endregion

    //    diff += Mathf.Abs(flat.x - startPosition.x);

    //    if (diff > maxPath) {
    //        startPosition = transform.position;
    //        change = !change;
    //        diff = 0f;
    //    }

    //    myRigidbody.velocity = (direction.normalized * Speed) + Gravity(myRigidbody.velocity.y);
    //}
    //#endregion
}
