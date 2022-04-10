using UnityEngine;

public class PlayerWithInvincibility : Movement, IInvincible {
    #region Serialized attributes
    [SerializeField]
    private float invincibilityThreshold = 20f;
    [SerializeField]
    [Range(0f, 1f)]
    private float invincibilityOffset = 0f;
    #endregion
    #region Private attributes
    private float invincibilityCounter = 0f;
    private Vector4 startColor = Vector4.zero;
    private Vector4 invincibilityColor = Vector4.zero;
    #endregion



    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();
        SetCounters(0f, 0f);
        startColor = mySpriteRenderer.color;
        invincibilityColor = new Vector4(mySpriteRenderer.color.r, invincibilityOffset,
                                         mySpriteRenderer.color.b, mySpriteRenderer.color.a);
        IsInvincible = false;
    }
    #endregion



    protected override void Update() {
        base.Update();

        databasePlayer.skillCounter += Time.deltaTime;

        if (InvincibleConditions()) {
            IsInvincible = true;
        }

        if (IsInvincible) {
            invincibilityCounter += Time.deltaTime;
            Invincible();

            if (invincibilityCounter >= invincibilityThreshold) {
                IsInvincible = false;
                NormalState();
                SetCounters(0f, 0f);
            }
        }
    }
    #region Update methods
    private bool InvincibleConditions() {
        return databaseInput.Player.GetButtonDown
               (databaseInput.SpecialSkillButton) &&
               !IsInvincible && databasePlayer.skillCounter >= databasePlayer.ReloadSkillCounter;
    }


    public void Invincible() {
        mySpriteRenderer.color = invincibilityColor;
    }
    private void NormalState() {
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