using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SpriteRenderer))]
public class Npc : MonoBehaviour {
    #region Enum variable
    [SerializeField]
    protected PhrasesType phrasesType = PhrasesType.Last;
    #endregion
    #region Private attributes
    private SpriteRenderer dialogueSignSpriteRenderer = null;
    #endregion
    #region Public attributes
    [Tooltip("Npc's database")]
    public DatabaseNPC databaseNPC = null;

    [Tooltip("Input database")]
    public DatabaseInput databaseInput = null;

    [HideInInspector]
    public SpriteRenderer mySpriteRenderer = null;

    [Tooltip("Child object")]
    public GameObject dialogueSign = null;

    [HideInInspector]
    public string phrase = null;
    #endregion
    #region Protected attributes
    [SerializeField]
    protected bool randomDialogue = false;
    #endregion
    #region Constant
    private const int NPC_SORTINGORDER = -1;
    #endregion



    private void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        dialogueSignSpriteRenderer = dialogueSign.GetComponent<SpriteRenderer>();
    }
    #endregion



    protected virtual void Start() {
        VariablesAssignment();
    }
    #region Start methods
    protected virtual void VariablesAssignment() {
        mySpriteRenderer.sortingOrder = NPC_SORTINGORDER;
        dialogueSignSpriteRenderer.sortingOrder = NPC_SORTINGORDER;
        dialogueSign.SetActive(false);
    }
    #endregion
}