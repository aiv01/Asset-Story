using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class SpitterPatrol : State {
    #region Private attributes
    private Spitter owner = null;

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
        owner = GetComponent<Spitter>();
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
        float distFromPlayer = (transform.position - owner.playerTransform.position).magnitude;
        #endregion

        return distFromPlayer <= minDist;
    }
    #endregion



    public override void FixedUpdate() {

    }
}
