using UnityEngine;

public class PlayerWithInvincibility : Movement, IInvincible {
    #region Private attributes
    private bool isInvincible = false;
    private float invincibilityCounter = 0f;
    [SerializeField]
    private float invincibilityThreshold = 20f;
    private Vector4 startColor = Vector4.zero;
    private Vector4 invincibilityColor = Vector4.zero;
    [SerializeField]
    [Range(0f, 1f)]
    private float invincibilityOffset = 0f;
    #endregion
    #region Constant
    private const string INVINCIBILITY_TAG = "Invincible";
    private const string PLAYER_TAG = "Player";
    #endregion



    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();
        SetCounters(0f, 0f);
        startColor = mySpriteRenderer.color;
        invincibilityColor = new Vector4(mySpriteRenderer.color.r, invincibilityOffset,
                                         mySpriteRenderer.color.b, mySpriteRenderer.color.a);
    }
    #endregion



    protected override void Update() {
        base.Update();

        databasePlayer.skillCounter -= Time.deltaTime;

        if (InvincibleConditions()) {
            isInvincible = true;
        }

        if (isInvincible) {
            invincibilityCounter += Time.deltaTime;
            Invincible();

            if (invincibilityCounter >= invincibilityThreshold) {
                isInvincible = false;
                NormalState();
                SetCounters(0f, databasePlayer.ReloadSkillCounter);
            }
        }
    }
    #region Update methods
    private bool InvincibleConditions() {
        return databaseInput.Player.GetButtonDown
               (databaseInput.SpecialSkillButton) &&
               !isInvincible && databasePlayer.skillCounter <= 0f;
    }


    public void Invincible() {
        mySpriteRenderer.color = invincibilityColor;
        gameObject.tag = INVINCIBILITY_TAG;
    }
    private void NormalState() {
        gameObject.tag = PLAYER_TAG;
        mySpriteRenderer.color = startColor;
    }
    #endregion



    #region Reusable methods
    private void SetCounters(float _invincibilityCounterValue, float _skillCounterValue) {
        invincibilityCounter = _invincibilityCounterValue;
        databasePlayer.skillCounter = _skillCounterValue;
    }
    #endregion
}