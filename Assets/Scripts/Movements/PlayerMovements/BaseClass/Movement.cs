using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HealthModule))]
public class Movement : MonoBehaviour {
    #region Public attributes
    public DatabasePlayer databasePlayer = null;
    public DatabaseInput databaseInput = null;
    #endregion
    #region Protected attributes
    protected Rigidbody2D myRigidbody = null;
    protected BoxCollider2D myHeadCollider = null;
    protected CapsuleCollider2D myBodyCollider = null;
    protected CircleCollider2D myStickCollider = null;
    protected SpriteRenderer mySpriteRenderer = null;
    protected Animator myAnimator = null;
    #endregion
    #region Private attributes
    private Vector2 shootPosition;
    private Vector2 shootPositionFlipped;
    #endregion
    #region Protected Properties
    protected bool IsRunning {
        get;
        private set;
    } = false;


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


    protected bool IsGrounded {
        get;
        private set;
    } = false;


    protected bool IsCrouching {
        get;
        private set;
    } = false;
    #endregion
    #region Static property
    public static bool IsFlipped {
        get;
        private set;
    } = false;
    #endregion
    #region Constant
    private const float STICKCOLLIDER_POSITION_X = 2.46f;
    private const float STICKCOLLIDER_POSITION_Y = 0.84f;
    private const float SHOOTPOSITION_XOFFSET = 1f;
    private const float SHOOTPOSITION_YOFFSET = 1.35f;
    private const int DEFAULT_LAYER = 0;
    #endregion



    protected virtual void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    protected virtual void TakeTheReferences() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myHeadCollider = GetComponent<BoxCollider2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myStickCollider = GetComponent<CircleCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }
    #endregion



    protected virtual void Start() {
        VariablesAssignment();
        databaseInput.AssignRewiredPlayer();
        AddListener();
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
        myRigidbody.gravityScale = databasePlayer.GravityScale;
        myRigidbody.constraints = databasePlayer.RigidbodyConstraints;
        myRigidbody.sharedMaterial = databasePlayer.PhysicMaterial;
        myRigidbody.sleepMode = RigidbodySleepMode2D.NeverSleep;
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
        //myBodyCollider.usedByEffector = databasePlayer.BodyUsedByEffector;
        //myBodyCollider.usedByComposite = databasePlayer.BodyUsedByComposite;
        myBodyCollider.direction = databasePlayer.CapsuleDirection;
        //StickCollider
        myStickCollider.enabled = false;
    }
    private void AddListener() {
        MessageManager.OnTouchedTheCheckPoint += SavePlayerData;
    }
    #endregion



    #region Events methods
    public void SavePlayerData() {
        Save.Instance.playerPosition = transform.position;
    }
    #endregion


    protected virtual void Update() {
        databaseInput.TakeTheInputs();

        #region Variable assignment
        SetAnimatorParameters("Speed", Mathf.Abs(databaseInput.horizontal));

        shootPosition = new Vector2(transform.position.x + SHOOTPOSITION_XOFFSET,
                                    transform.position.y + SHOOTPOSITION_YOFFSET);
        shootPositionFlipped = new Vector2(transform.position.x + (-SHOOTPOSITION_XOFFSET),
                                        transform.position.y + SHOOTPOSITION_YOFFSET);  
        #endregion
        #region Flip
        if (databaseInput.horizontal < 0f) {
            FlipSprite(SnapAxis.X, true);
            IsFlipped = true;
        }
        else if (databaseInput.horizontal > 0f) {
            FlipSprite(SnapAxis.X, false);
            IsFlipped = false;
        } 
        #endregion
        #region Run
        if (databaseInput.Player.GetButton
           (databaseInput.RunButton)) {
            Run();
        }
        else {
            IsRunning = false;
            databasePlayer.run = false;
            SetAnimatorParameters("IsRunning", false);
        }
        #endregion
        #region Jump
        IsJumping = !IsJumping && databaseInput.Player.GetButtonDown
                    (databaseInput.JumpButton) ? true : IsJumping;
        #endregion
        #region Hit
        if (databaseInput.Player.GetButtonDown
           (databaseInput.HitButton) 
            && IsGrounded
            && !IsCrouching) {
            IsHitting = true;
        }

        if (IsHitting) {
            Hit();
        }
        else {
            myStickCollider.enabled = false;
            SetAnimatorParameters("IsHitting", false);
        }
        #endregion
        #region Shoot
        if (databaseInput.Player.GetButtonDown
           (databaseInput.ShootButton)
            && !IsCrouching
            && IsGrounded) {
            IsShooting = true;
        }

        if (IsShooting) {
            Shoot();
        }
        else {
            SetAnimatorParameters("IsShooting", false);
        }
        #endregion
        #region Crouch
        if (databaseInput.Player.GetButton
           (databaseInput.CrouchButton) &&
           !IsRunning) {
            Crouch();
        }
        else {
            myRigidbody.simulated = true;
            SetAnimatorParameters("IsCrouching", false);
            IsCrouching = false;
        } 
        #endregion
    }
    #region Update methods
    private void Run() {
        SetAnimatorParameters("IsRunning", true);
        databasePlayer.run = true;
        IsRunning = true;
    }
    private void Crouch() {
        IsCrouching = true;
        SetAnimatorParameters("IsCrouching", true);
        myRigidbody.simulated = false;
    }
    private void Hit() {
        #region StickCollider positioning
        if (IsFlipped) {
            SetStickColliderPosition(-STICKCOLLIDER_POSITION_X,
                                      STICKCOLLIDER_POSITION_Y);
        }
        else {
            SetStickColliderPosition(STICKCOLLIDER_POSITION_X,
                                     STICKCOLLIDER_POSITION_Y);
        } 
        #endregion

        SetAnimatorParameters("IsHitting", true);
        myStickCollider.enabled = true;
        IsHitting = false;
    }
    private void Shoot() {
        BulletManager.Instance.GetBullet(!IsFlipped ? shootPosition :
                                         shootPositionFlipped);

        SetAnimatorParameters("IsShooting", true);
        IsShooting = false;
    }


    private void SetStickColliderPosition(float _posX, float _posY) {
        myStickCollider.offset = new Vector2(_posX, _posY);
    }
    #endregion



    protected virtual void FixedUpdate() {
        Move();
        #region Jump
        if (IsJumping) {
            Jump();
        }
        else {
            SetAnimatorParameters("IsJumping", false);
        } 
        #endregion
    }
    #region FixedUpdate methods
    private void Move() {
        #region Variable assignment
        Vector2 velocity = new Vector2(databaseInput.horizontal, 0);
        #endregion

        myRigidbody.velocity = (velocity.normalized * databasePlayer.Speed) +
                               databasePlayer.Gravity(myRigidbody.velocity.y);
    }


    private void Jump() {
        if (IsGrounded) {
            IsGrounded = false;
            myRigidbody.AddForce(transform.up * databasePlayer.JumpForce,
                                 ForceMode2D.Impulse);
            SetAnimatorParameters("IsJumping", true);
        }
        IsJumping = false;
    }
    #endregion



    #region OnCollision methods
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == DEFAULT_LAYER) {
            IsGrounded = true;
        }
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



    private void OnDestroy() {
        RemoveListeners();
    }
    private void RemoveListeners() {
        MessageManager.OnTouchedTheCheckPoint -= SavePlayerData;
    }
}