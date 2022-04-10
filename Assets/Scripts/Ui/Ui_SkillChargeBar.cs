using UnityEngine;
using UnityEngine.UI;

public class Ui_SkillChargeBar : MonoBehaviour {
    #region Serialized attributes
    [SerializeField]
    private DatabasePlayer[] databasesPlayer = new DatabasePlayer[(int)SkillType.Last];

    [SerializeField]
    private Sprite[] iconSprites = new Sprite[(int)SkillType.Last];

    [SerializeField]
    private Image iconImage = null;

    [SerializeField]
    private GameObject skillChargeBar = null;
    #endregion
    #region Private attributes
    private DatabasePlayer databasePlayer = null;
    private float startScaleX = 0f;
    #endregion
    #region Properties
    private float BarLimit {
        get { return databasePlayer.skillCounter; }
        set {
            databasePlayer.skillCounter = value > databasePlayer.ReloadSkillCounter ?
                                          databasePlayer.ReloadSkillCounter : value < 0 ? 0 : value;
        }
    }


    private float CurrentCharge {
        get { return BarLimit / databasePlayer.ReloadSkillCounter; }
    }
    #endregion



    void Start() {
        VariablesAssignment();
        SetSkillChargeBar();
    }
    #region Start methods
    private void VariablesAssignment() { 
        startScaleX = skillChargeBar.transform.localScale.x;

        if (Movement.Instance is PlayerWithShieldMovement) {
            databasePlayer = databasesPlayer[(int)SkillType.Shield];
            iconImage.sprite = iconSprites[(int)SkillType.Shield];
        }
        else if (Movement.Instance is PlayerWithDashMovement) {
            databasePlayer = databasesPlayer[(int)SkillType.Dash];
            iconImage.sprite = iconSprites[(int)SkillType.Dash];
        }
        else {
            databasePlayer = databasesPlayer[(int)SkillType.Invincibilty];
            iconImage.sprite = iconSprites[(int)SkillType.Invincibilty];
        }
    }
    #endregion



    void Update() {
        SetSkillChargeBar();
    }
    #region Update methods
    private void SetSkillChargeBar() {
        SetBar(CurrentCharge);

        if (BarLimit <= 0) {
            SetBar(0);
        }
        else if (BarLimit >= databasePlayer.ReloadSkillCounter) {
            SetBar(startScaleX);

            if (ResetBarConditions()) {
                SetBar(0);
            }
        }
    }
    private bool ResetBarConditions() {
        return Movement.Instance.myAnimator.GetBool("IsInSpecialSkill") ||
               Movement.Instance.IsInvincible; 
    }
    private void SetBar(float _value) {
        skillChargeBar.transform.localScale = new Vector2(_value, skillChargeBar.transform.localScale.y);
    }
    #endregion
}