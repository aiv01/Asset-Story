using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour {
    #region Attributes
    private bool isOpen = false;

    [SerializeField]
    private DatabaseDoor databaseDoor = null;
    [SerializeField]
    private DatabaseKey databaseKey = null;

    private BoxCollider2D myCollider = null;
    private SpriteRenderer mySpriteRenderer = null;
    #endregion
    #region Constant
    private const float SCALE_X = 0.5F;
    private const float SCALE_Y = 0.5F;
    private const int DOOR_SORTINGORDER = -1;
    #endregion



    void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion



    void Start() {
        VariablesAssignment();
    }
    #region Start methods
    private void VariablesAssignment() {
        gameObject.transform.localScale = new Vector3(SCALE_X, SCALE_Y, 0);
        mySpriteRenderer.sprite = databaseDoor.StartingSprite;
        mySpriteRenderer.sortingOrder = DOOR_SORTINGORDER;
    }
    #endregion



    void Update() {
        if (DisableCondition()) {
            TurnMeOff();
        }

        if (OpenCondition()) {
            Open();
            MessageManager.CallOnOpenTheDoor();
            //TRIGGER CUTSCENE
        }

        ChangeSprite();
    }
    #region Update methods
    private bool OpenCondition() {
        return databaseKey.numOfKeys == databaseDoor.KeysNeeded;
    }
    private bool DisableCondition() {
        #region VariablesAssignment
        float positionY = transform.position.y;
        float sizeY = myCollider.size.y;
        float calculatedPosition = positionY + sizeY;
        #endregion

        return calculatedPosition < databaseDoor.DeactivationOffset;
    }


    private void Open() {
        #region VariableAssignment
        Vector3 direction = Vector3.down; 
        #endregion

        transform.position += direction.normalized * databaseDoor.OpeningSpeed;
    }
    private void ChangeSprite() {
        #region VariablesAssignment
        float firstChangeValue = 1;
        float secondChangeValue = 2;
        float thirdChangeValue = 3; 
        #endregion

        mySpriteRenderer.sprite = databaseKey.numOfKeys == firstChangeValue ? databaseDoor.GetSprite((int)DoorSpriteType.OnePieceActive) :
                                  databaseKey.numOfKeys == secondChangeValue ? databaseDoor.GetSprite((int)DoorSpriteType.TwoPieceActive) :
                                  databaseKey.numOfKeys == thirdChangeValue ? databaseDoor.GetSprite((int)DoorSpriteType.Active) :
                                  mySpriteRenderer.sprite;
    }
    private void TurnMeOff() {
        gameObject.SetActive(false);
    }
    #endregion
}