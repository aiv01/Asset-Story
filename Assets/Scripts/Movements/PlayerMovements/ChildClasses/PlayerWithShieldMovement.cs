using UnityEngine;

public class PlayerWithShieldMovement : Movement, IDefensible {
    #region Public attributes
    public Sprite shieldSprite = null;
    #endregion
    #region Private attributes
    private bool defence = false;
    private GameObject shield = null; 
    #endregion
    #region Constant
    private const int SORTINGORDER_VALUE = 1; 
    #endregion



    protected override void Start() {
        base.Start();

        shield = CreateShieldObject();
    }
    #region Start methods
    private GameObject CreateShieldObject() {
        //object
        GameObject shield = new GameObject("Shield");
        shield.tag = "Shield";
        //set position
        shield.transform.SetParent(transform);
        shield.transform.position = FlattenVector(transform.position) + new Vector2(0, 1);
        //add and set renderer
        SpriteRenderer renderer = shield.AddComponent<SpriteRenderer>();
        renderer.sprite = shieldSprite;
        renderer.sortingOrder = 1;
        //add circle collider
        shield.AddComponent<CircleCollider2D>();
        shield.SetActive(false);
        return shield;
    } 
    #endregion



    protected override void Update() {
        base.Update();

        if (databaseInput.Player.GetButtonDown
           (databaseInput.SpecialSkillButton)) {
            defence = !defence;
        }
    }



    protected override void FixedUpdate() {
        base.FixedUpdate();

        if (defence) {
            Defence();
        }
        else {
            myRigidbody.bodyType = RigidbodyType2D.Dynamic;
            shield.SetActive(false);
            SetAnimatorParameters("IsInSpecialSkill", false);
        }
    }
    #region FixedUpdate methods
    public void Defence() {
        SetAnimatorParameters("IsInSpecialSkill", true);
        shield.SetActive(true);
        myRigidbody.bodyType = RigidbodyType2D.Static;
    } 
    #endregion
}
