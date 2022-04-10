using UnityEngine;

public class GunnerConfusion : State {
    #region Serialized attributes
    [SerializeField]
    private float reloadConfusionCounter = 0f;
    [SerializeField]
    private State nextState = null;
    #endregion
    #region Private attributes
    private float confusionCounter = 0f;
    private Gunner owner = null;
    private Vector2 startPosition = Vector2.zero;
    #endregion
    #region constant
    private const int CONFUSION_SORTINGORDER = -1;
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

        myAnimator.SetBool("IsConfuse", true);
        mySpriteRenderer.sortingOrder = CONFUSION_SORTINGORDER;
        owner.IsConfuse = true;
        startPosition = myRigidbody.position;
    }
    #endregion
    #region OnDisable methods
    protected override void OnExitState() {
        base.OnExitState();

        owner.IsConfuse = false;
        mySpriteRenderer.sortingOrder = Gunner.GUNNER_SORTINGORDER;
        confusionCounter = reloadConfusionCounter;
        myAnimator.SetBool("IsConfuse", false);
    }
    #endregion



    protected override void Start() {
        base.Start();

        confusionCounter = reloadConfusionCounter;
    }



    public override void Update() {
        base.Update();

        myRigidbody.position = startPosition;
        confusionCounter -= Time.deltaTime;

        if (ExitCondition()) {
            this.enabled = false;
            nextState.enabled = true;
        }

        if (owner.myHealthModule.Died()) {
            this.enabled = false;
            nextState.enabled = false;
            //owner.enabled = false;
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        return confusionCounter <= 0;
    } 
    #endregion
}