using UnityEngine;

public class PlayerWithShieldMovement : Movement, IDefensible {
    #region Public attributes
    public Sprite shieldSprite = null;
    #endregion
    #region Private attributes
    private bool isDefence = false;
    private GameObject shield = null;
    private Vector2 shieldPositionOffset = Vector2.zero;
    #endregion
    #region Constant
    private const string SHIELD_TAG = "Shield";
    private const int SHIELD_SORTINGORDER = 1;
    private const int SHIELD_OFFSETX = 0;
    private const int SHIELD_OFFSETY = 1;
    #endregion



    protected override void Start() {
        base.Start();

        shield = CreateShieldObject();
    }
    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();
        shieldPositionOffset = new Vector2(SHIELD_OFFSETX, SHIELD_OFFSETY);
        databasePlayer.skillCounter = 0f;
    }
    private GameObject CreateShieldObject() {
        GameObject shield = new GameObject(SHIELD_TAG);
        shield.tag = SHIELD_TAG;
        shield.transform.SetParent(transform);
        shield.transform.position = FlattenVector(transform.position) + shieldPositionOffset;
        SpriteRenderer spriteRenderer = shield.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = shieldSprite;
        spriteRenderer.sortingOrder = SHIELD_SORTINGORDER;
        shield.AddComponent<CircleCollider2D>();
        shield.SetActive(false);
        return shield;
    } 
    #endregion



    protected override void Update() {
        base.Update();

        databasePlayer.skillCounter -= Time.deltaTime;

        if (DefenceConditions()) {
            isDefence = !isDefence;

            if (!isDefence) {
                databasePlayer.skillCounter = databasePlayer.ReloadSkillCounter;
            }
        }
    }
    #region Update methods
    private bool DefenceConditions() {
        return databaseInput.Player.GetButtonDown
               (databaseInput.SpecialSkillButton) &&
               databasePlayer.skillCounter <= 0f;
    }
    #endregion



    protected override void FixedUpdate() {
        base.FixedUpdate();

        if (isDefence) {
            Defence();
        }
        else {
            NormalState();
        }
    }
    #region FixedUpdate methods
    public void Defence() {
        SetAnimatorParameters("IsInSpecialSkill", true);
        shield.SetActive(true);
        myRigidbody.bodyType = RigidbodyType2D.Static;
    }
    private void NormalState() {
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        shield.SetActive(false);
        SetAnimatorParameters("IsInSpecialSkill", false);
    }
    #endregion
}