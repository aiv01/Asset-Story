using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour {
    #region Public attributes
    public DatabasePlayer databasePlayer = null;
    public DatabaseInput databaseInput = null;
    #endregion
    #region Protected attributes
    protected Rigidbody2D myRigidbody = null;
    protected BoxCollider2D myHeadCollider = null;
    protected CapsuleCollider2D myBodyCollider = null;
    protected SpriteRenderer mySpriteRenderer = null;
    protected Animator myAnimator = null;
    #endregion
    #region Static property
    public static bool IsFlipped {
        get;
        private set;
    } = false;
    #endregion
    #region Protected properties
    protected bool IsJumping {
        get;
        private set;
    } = false;


    protected bool IsHitting {
        get;
        private set;
    } = false;


    protected bool IsShooting {
        get;
        private set;
    } = false;
    #endregion

    public CircleCollider2D circleCollider = null;

    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected virtual void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myHeadCollider = GetComponent<BoxCollider2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }
    #endregion



    protected virtual void Start() {
        VariablesAssignment();
        databaseInput.AssignRewiredPlayer();

        circleCollider.enabled = false;
    }
    #region Start methods
    protected virtual void VariablesAssignment() {
        //SpriteRenderer
        mySpriteRenderer.sprite = databasePlayer.StartingSprite;
        //Animator
        myAnimator.speed = databasePlayer.SpeedAnimation;
        //Rigidbody
        myRigidbody.bodyType = databasePlayer.RigidbodyType;
        myRigidbody.drag = databasePlayer.LinearDrag;
        myRigidbody.angularDrag = databasePlayer.AngularDrag;
        myRigidbody.mass = databasePlayer.Mass;
        myRigidbody.gravityScale = databasePlayer.Gravity;
        myRigidbody.constraints = databasePlayer.RigidbodyConstraints;
        myRigidbody.sharedMaterial = databasePlayer.PhysicMaterial;
        //HeadCollider
        myHeadCollider.sharedMaterial = databasePlayer.PhysicMaterial;
        myHeadCollider.isTrigger = databasePlayer.HeadIsTrigger;
        myHeadCollider.usedByEffector = databasePlayer.HeadUsedByEffector;
        myHeadCollider.usedByComposite = databasePlayer.HeadUsedByComposite;
        myHeadCollider.autoTiling = databasePlayer.HeadAutoTiling;
        myHeadCollider.edgeRadius = databasePlayer.HeadEdgeRadius;
        //BodyCollider
        myBodyCollider.sharedMaterial = databasePlayer.BodyPhysicsMaterial;
        myBodyCollider.isTrigger = databasePlayer.BodyIsTrigger;
        myBodyCollider.usedByEffector = databasePlayer.BodyUsedByEffector;
        myBodyCollider.usedByComposite = databasePlayer.BodyUsedByComposite;
        myBodyCollider.direction = databasePlayer.CapsuleDirection;
    }
    #endregion



    protected virtual void Update() {
        //TakeTheInputs();

        databaseInput.TakeTheInputs();
        //SPEED
        //SetAnimatorSpeed();
        SetAnimatorParameters("Speed", Mathf.Abs(databaseInput.horizontal));

        //RUN
        if (databaseInput.Player.GetButton
           (databaseInput.RunButton)) {
            Run();
        }
        else {
            databasePlayer.isRunning = false;
            SetAnimatorParameters("IsRunning", false);
        }

        if (databaseInput.Player.GetButtonDown
           (databaseInput.HitButton)) {
            Hit();
        }


        if (IsHitting) {
            if (IsFlipped) {
                circleCollider.offset = new Vector2(-2.46f, 0.84f);
                circleCollider.enabled = true;
            }
            else {
                circleCollider.offset = new Vector2(2.46f, 0.84f);
                circleCollider.enabled = true;
            }
            IsHitting = false;
        }
        else {
            circleCollider.enabled = false;
        }
        //VERSIONE ORIGINALE
        //if (myRigidbody.velocity.magnitude != 0) {
        //    Walk();
        //}
        //else {
        //    Idle();
        //}


        //if (myRigidbody.velocity.magnitude <= 0.1f ||
        //    myRigidbody.velocity.magnitude >= 0.1f) {
        //    Walk();
        //}
        //else {
        //    Idle();
        //}

        if (databaseInput.jump) {
            Jump();
            databaseInput.jump = false;
            //SetAnimatorParameters("IsJumping", false);
        }


        if (databaseInput.horizontal < 0f) {
            FlipSprite(SnapAxis.X, true);
            IsFlipped = true;
        }
        else if (databaseInput.horizontal > 0f) {
            FlipSprite(SnapAxis.X, false);
            IsFlipped = false;
        }

        Debug.Log(myAnimator.speed);
    }
    #region Update methods
    //protected virtual void TakeTheInputs() {
    //    databaseInput.horizontal = Input.GetAxis("Horizontal");
    //    databaseInput.vertical = Input.GetAxis("Vertical");
    //}
    private void SetAnimatorSpeed() {
        SetAnimatorParameters("Speed", Mathf.Abs(databaseInput.horizontal));
    }
    //private void Walk() {
    //    SetAnimatorParameters("IsWalking", true);
    //    //SetAnimatorParameters("Speed", mat);
    //}
    //private void Idle() {
    //    SetAnimatorParameters("IsWalking", false);
    //}
    private void Run() {
        SetAnimatorParameters("IsRunning", true);
        databasePlayer.isRunning = true;
    }
    private void Jump() {
        SetAnimatorParameters("IsJumping", true);
    }
    private void Hit() {
        IsHitting = true;
        SetAnimatorParameters("IsHitting", true);
    }
    #endregion



    protected virtual void FixedUpdate() {
        Move();

        if (databaseInput.jump) {
            myRigidbody.AddForce(new Vector2(0, 100), ForceMode2D.Impulse);
        }
    }
    #region FixedUpdate methods
    private void Move() {
        #region Variable assignment
        Vector2 velocity = new Vector2(databaseInput.horizontal,
                                       myRigidbody.velocity.y);
        #endregion

        myRigidbody.velocity = velocity.normalized * databasePlayer.Speed;
    }
    #endregion



    #region Reusable methods
    protected void SetAnimatorParameters(string _name, bool _value) {
        myAnimator.SetBool(_name, _value);
    }
    protected void SetAnimatorParameters(string _name, float _value) {
        myAnimator.SetFloat(_name, _value);
    }
    protected void SetAnimatorParameters(string _name, int _value) {
        myAnimator.SetInteger(_name, _value);
    }


    private void FlipSprite(SnapAxis _axis, bool _value) {
        switch (_axis) {
            case SnapAxis.None:
                return;
            case SnapAxis.X:
                mySpriteRenderer.flipX = _value;
                break;
            case SnapAxis.Y:
                mySpriteRenderer.flipY = _value;
                break;
        }
    }


    protected Vector2 FlattenVector(Vector3 _toFlatten) {
        Vector2 flatVector = new Vector2(_toFlatten.x, _toFlatten.y);
        return flatVector;
    }
    #endregion
}
