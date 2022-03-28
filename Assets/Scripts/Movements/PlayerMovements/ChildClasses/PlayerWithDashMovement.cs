using UnityEngine;

public class PlayerWithDashMovement : Movement, IDashable {
    #region Private attributes
    private bool isDash = false;
    private Vector4 startColor = Vector4.zero;
    private Vector4 dashColor = Vector4.zero;

    [SerializeField]
    private float dashForce = 10f;

    [SerializeField]
    private float dashThreshold = 10f;
    Vector2 startPosition;

    private float diff = 0f;
    #endregion



    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        startColor = mySpriteRenderer.color;
        dashColor = new Vector4(1f, 1f, 1f, 0.2f);
        databasePlayer.skillCounter = 0f;
    } 
    #endregion



    protected override void Update() {
        base.Update();

        if (DashConditions()) {
            isDash = true;
            startPosition = transform.position;
        }

        if (!isDash) {
            databasePlayer.skillCounter -= Time.deltaTime;
        }
    }
    #region Update methods
    private bool DashConditions() {
        return databaseInput.Player.GetButtonDown
               (databaseInput.SpecialSkillButton) &&
               databasePlayer.skillCounter <= 0;
    }
    #endregion



    protected override void FixedUpdate() {
        base.FixedUpdate();

        if (isDash) {
            Dash();
        }
        else {
            NormalState();
        }
    }
    #region FixedUpdate methods
    public void Dash() {
        #region Variables assignment
        Vector2 force = !mySpriteRenderer.flipX ? transform.right * dashForce :
                        -transform.right * dashForce;

        Vector2 flat = FlattenVector(transform.position);

        diff += Mathf.Abs(flat.x - startPosition.x);
        #endregion

        SetAnimatorParameters("IsInSpecialSkillMode", true);
        mySpriteRenderer.color = dashColor;
        myRigidbody.AddForce(force, ForceMode2D.Impulse);

        if (diff > dashThreshold) {
            isDash = false;
            diff = 0f;
            databasePlayer.skillCounter = databasePlayer.ReloadSkillCounter;
        }
    }
    private void NormalState() {
        mySpriteRenderer.color = startColor;
        SetAnimatorParameters("IsInSpecialSkillMode", false);
    }
    #endregion
}