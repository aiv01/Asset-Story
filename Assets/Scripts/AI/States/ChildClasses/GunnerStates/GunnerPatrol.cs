using UnityEngine;

public class GunnerPatrol : State {
    #region Serialized attributes
    [SerializeField]
    private State nextState = null;

    [SerializeField]
    private float exitOffset = 0f;

    private Gunner owner;
    #endregion


    protected override void TakeTheReferences() {
        owner = GetComponent<Gunner>();
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
        float distToPlayer = (owner.playerTransform.position - transform.position).magnitude; 
        #endregion

        return distToPlayer <= exitOffset;
    }
    #endregion 
}