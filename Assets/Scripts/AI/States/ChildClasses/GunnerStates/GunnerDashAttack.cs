using UnityEngine;
using System.Collections;

public class GunnerDashAttack : State {
    #region Serialized attributes
    [SerializeField]
    private State nextState = null;
    [SerializeField]
    private float dashThreshold = 20f;
    [SerializeField]
    private float dashForce = 50f;
    #endregion
    #region Private attributes
    private Gunner owner = null;
    private float diff = 0f;
    private Vector2 startPosition = Vector2.zero;
    private Color startColor = Vector4.zero;
    private Vector4 dashColor = Vector4.zero;
    #endregion
    #region Public attributes
    public bool isDash = false;
    #endregion
    #region Constant
    private const float BULLETPOSITION_OFFSET_Y = 0.8f;
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

        isDash = true;
        myAnimator.SetBool("IsDashAttack", true);
        MessageManager.CallOnGunnerDash();
    }
    #endregion
    #region OnDisable methods
    protected override void OnExitState() {
        base.OnExitState();

        myAnimator.SetBool("IsDashAttack", false);
    }
    #endregion



    protected override void Start() {
        base.Start();

        startPosition = transform.position;
        startColor = mySpriteRenderer.color;
        dashColor = new Vector4(1f, 1f, 1f, 0.2f);
    }



    public override void Update() {

        if (isDash) {
            DashAttack();
        }

        if (ExitCondition()) {
            StartCoroutine(GoToTheNextState());
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        return !isDash;
    }
    private IEnumerator GoToTheNextState() {
        yield return new WaitForSeconds(2f);
        this.enabled = false;
        nextState.enabled = true;
    }
    #endregion



    public override void FixedUpdate() {
        base.FixedUpdate();

        DashAttack();
    }



    #region Attack methods
    private void DashAttack() {
        #region Variables assignment
        Vector2 force = !owner.IsFlipped ? -transform.right * dashForce :
                        transform.right * dashForce;

        Vector2 flat = FlattenVector(transform.position);

        diff += Mathf.Abs(flat.x - startPosition.x);
        #endregion

        myRigidbody.AddForce(force, ForceMode2D.Impulse);


        if (diff >= dashThreshold) {
            isDash = false;
            diff = 0f;
        }
    }
    #endregion
}