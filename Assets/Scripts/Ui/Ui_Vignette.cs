using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class Ui_Vignette : MonoBehaviour {
    #region Private attributes
    [SerializeField]
    [Tooltip("Vignette database")]
    private DatabaseVignette databaseVignette = null;

    [SerializeField]
    [Tooltip("The 'UI_Vignette'")]
    private GameObject vignette = null;

    private Text myText = null;

    [SerializeField]
    [Tooltip("Font of the text's vignette")]
    private Font font = null;

    [SerializeField]
    [Tooltip("Font size of the text's vignette")]
    private int fontSize = 15;
    [SerializeField]
    private FontStyle fontStyle = FontStyle.Bold;

    [SerializeField]
    [Tooltip("Color of the text's vignette")]
    private Color color = Color.black;

    private float counter = 0f;
    #endregion
    #region Singleton
    public static Ui_Vignette Instance {
        get;
        private set;
    } = null;
    #endregion



    void Awake() {
        TakeTheReferences();
        Instance = this;
    }
    #region Awake methods
    private void TakeTheReferences() {
        myText = vignette.GetComponentInChildren<Text>();
    } 
    #endregion



    void Start() {
        VariablesAssignment();
        SetCounter(databaseVignette.ReloadCounter);
        ObjectSwitch(false);
        AddListeners();
    }
    #region Start methods
    private void VariablesAssignment() {
        myText.font = font;
        myText.fontSize = fontSize;
        myText.fontStyle = fontStyle;
        myText.color = color;
    }


    private void AddListeners() {
        MessageManager.OnNpcInteraction += TurnOnMe;
        MessageManager.OnEscDialogue += TurnOffMe;
    }
    #endregion



    #region Events methods
    private void TurnOnMe() {
        ObjectSwitch(true);
    }
    private void TurnOffMe() {
        ObjectSwitch(false);
    }
    #endregion



    #region Reusable methods
    private void ObjectSwitch(bool _value) {
        vignette.SetActive(_value);
    }
    private void SetCounter(float _time) {
        counter = _time;
    }
    #endregion



    #region Public methods
    public void SetText(string _text) {
        myText.text = _text;
    }
    #endregion



    void Update() {
        VignetteActivationStatus();
    }
    #region Update methods
    private void VignetteActivationStatus() {
        if (vignette.activeSelf) {
            counter -= Time.deltaTime;
        }
        else {
            SetCounter(databaseVignette.ReloadCounter);
        }

        if (counter <= 0) {
            ObjectSwitch(false);
            MessageManager.CallOnTurnOffVignette();
            SetCounter(databaseVignette.ReloadCounter);
        }
    } 
    #endregion



    private void OnDestroy() {
        RemoveListeners();
    }
    #region OnDestroy methods
    private void RemoveListeners() {
        MessageManager.OnNpcInteraction -= TurnOnMe;
        MessageManager.OnEscDialogue -= TurnOffMe;
    }
    #endregion
}