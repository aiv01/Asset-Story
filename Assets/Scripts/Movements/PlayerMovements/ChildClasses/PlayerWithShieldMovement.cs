using UnityEngine;

public class PlayerWithShieldMovement : Movement, IDefensible {
    #region Serialized attributes
    [SerializeField]
    private int shieldHp = 3;
    #endregion
    #region Public attributes
    public Sprite shieldSprite = null;
    #endregion
    #region Private attributes
    private bool isDefence = false;
    private GameObject shield = null;
    private Vector2 shieldPositionOffset = Vector2.zero;
    [HideInInspector]
    public int shieldLife = 0;
    private float tempJumpForce = 0f;
    #endregion
    #region Constant
    private const string SHIELD_TAG = "Shield";
    private const int SHIELD_SORTINGORDER = 2;
    private const int SHIELD_OFFSETX = 0;
    private const int SHIELD_OFFSETY = 1;
    #endregion


    private void OnEnable() {
        shieldHp = shieldLife;
    }


    protected override void Start() {
        base.Start();

        shield = CreateShieldObject();
    }
    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();
        shieldPositionOffset = new Vector2(SHIELD_OFFSETX, SHIELD_OFFSETY);
        databasePlayer.skillCounter = 0f;
        tempJumpForce = databasePlayer.JumpForce;
    }
    private GameObject CreateShieldObject() {
        GameObject shield = new GameObject(SHIELD_TAG);
        shield.tag = SHIELD_TAG;
        shield.transform.SetParent(transform);
        shield.transform.position = FlattenVector(transform.position) + shieldPositionOffset;
        SpriteRenderer spriteRenderer = shield.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = shieldSprite;
        spriteRenderer.sortingOrder = SHIELD_SORTINGORDER;
        CircleCollider2D myCollider = shield.AddComponent<CircleCollider2D>();
        myCollider.offset = new Vector2(0, 0.2911924f);
        myCollider.radius = 1.648142f;
        shield.SetActive(false);
        return shield;
    } 
    #endregion



    protected override void Update() {
        base.Update();

        databasePlayer.skillCounter += Time.deltaTime;

        if (DefenceConditions()) {
            isDefence = !isDefence;

            if (!isDefence) {
                databasePlayer.skillCounter = 0f;
            }
        }
    }
    #region Update methods
    private bool DefenceConditions() {
        return databaseInput.Player.GetButtonDown
               (databaseInput.SpecialSkillButton) &&
               databasePlayer.skillCounter >= databasePlayer.ReloadSkillCounter;
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
        myRigidbody.mass = 200f;
        myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        databasePlayer.JumpForce = 0;
    }
    private void NormalState() {
        myRigidbody.mass = 1f;
        databasePlayer.JumpForce = tempJumpForce;
        shield.SetActive(false);
        SetAnimatorParameters("IsInSpecialSkill", false);
    }
    #endregion
}