using UnityEngine;

public class GunnerWalk : State {
    #region Serialized attributes
    [SerializeField]
    private float maxPath = 350f;
    [SerializeField]
    private State[] nextStates = null;
    [SerializeField]
    private float speed = 500f;
    #endregion
    #region Private attriubutes
    private float diff = 0f;
    private Gunner owner = null;
    private Vector2 startPosition = Vector2.zero;
    #endregion
    #region Properties
    private float Speed {
        get { return speed * Time.fixedDeltaTime; }
    }
    #endregion



    protected override void Awake() {
        base.Awake();

        this.enabled = false;
    }
    #region Awake methods
    protected override void TakeTheReferences() {
        base.TakeTheReferences();

        owner = GetComponent<Gunner>();
    } 
    #endregion



    #region OnEnable methods
    protected override void OnEnterState() {
        base.OnEnterState();

        myAnimator.SetBool("IsWalking", true);
        MessageManager.CallOnGunnerWalk();
    }
    #endregion
    #region OnDisable methods
    protected override void OnExitState() {
        base.OnExitState();

        myAnimator.SetBool("IsWalking", false);
        diff = 0f;
    }
    #endregion



    protected override void Start() {
        base.Start();

        startPosition = transform.position;
    }



    public override void Update() {
        base.Update();

        if (ExitCondition()) {
            this.enabled = false;
            nextStates[Random.Range(0, nextStates.Length)].enabled = true;
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        return diff >= maxPath;
    }
    #endregion



    public override void FixedUpdate() {
        base.FixedUpdate();

        Movement();
    }
    #region FixedUpdate methods
    private void Movement() {
        #region Variables assignment
        Vector2 direction = owner.IsFlipped ? Vector2.right : -Vector2.right;
        Vector2 flat = FlattenVector(transform.position);
        diff += Mathf.Abs(flat.x - startPosition.x);
        #endregion

        if (diff > maxPath) {
            startPosition = transform.position;
        }

        myRigidbody.velocity = (direction.normalized * Speed) + Gravity(myRigidbody.velocity.y);
    } 
    #endregion
}