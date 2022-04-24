using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Ui_Bestiary : MonoBehaviour {
    #region Private attributes
    [SerializeField]
    private GameObject bestiary = null;
    [SerializeField]
    private Button bestiaryIconButton = null;

    [SerializeField]
    private Text chomperTitle = null;
    [SerializeField]
    private Text spitterTitle = null;
    [SerializeField]
    private Text gunnerTitle = null;
    [SerializeField]
    private Font titleFont = null;
    [SerializeField]
    private int titleFontSize = 0;
    [SerializeField]
    private FontStyle titleFontStyle = FontStyle.Normal;
    [SerializeField]
    private Color titleColor = Vector4.zero;



    [SerializeField]
    private Text chomperText = null;
    [SerializeField]
    private Text spitterText = null;
    [SerializeField]
    private Text gunnerText = null;
    [SerializeField]
    private Font textFont = null;
    [SerializeField]
    private int textFontSize = 0;
    [SerializeField]
    private FontStyle textFontStyle = FontStyle.Normal;
    [SerializeField]
    private Color textColor = Vector4.zero;

    private bool isOpen = false;

    public string checkString = null;
    #endregion
    #region Static attributes
    public static int numOfChomperKilled = 0;
    public static int numOfSpitterKilled = 0;
    public static int numOfGunnerKilled = 0;
    #endregion



    void Start() {
        VariablesAssignment();
        AddListeners();
    }
    #region Start methods
    private void VariablesAssignment() {
        SetBestiaryTitles();
        SetBestiaryText();
        LoadBestiaryData();
        BestiarySwitch(false);
    }
    private void AddListeners() {
        MessageManager.OnClickCustomButton += SetIsOpen;
    }
    private void SetTextParameters() {
        chomperTitle.font = titleFont;
        chomperTitle.fontSize = titleFontSize;
        chomperTitle.fontStyle = titleFontStyle;
        chomperTitle.color = titleColor;
    }
    private void SetBestiaryTitles() {
        SetText(chomperTitle, "CHOMPER");
        SetText(spitterTitle, "SPITTER");
        SetText(gunnerTitle, "GUNNER");
    }
    private void LoadBestiaryData() {
        numOfChomperKilled = Save.Instance.numOfChomperKilled;
        numOfSpitterKilled = Save.Instance.numOfSpitterKilled;
        numOfGunnerKilled = Save.Instance.numOfGunnerKilled;
    }
    #endregion



    void Update() {
        if (isOpen) {
            OpenState();
        }
        else {
            CloseState();
        }

        SaveBestiaryData();
    }
    #region Update methods
    private void OpenState() {
        SetBestiaryText();
        BestiarySwitch(true);
    }
    private void CloseState() {
        BestiarySwitch(false);
    }


    private void SaveBestiaryData() { 
        Save.Instance.numOfChomperKilled = numOfChomperKilled;
        Save.Instance.numOfSpitterKilled = numOfSpitterKilled;
        Save.Instance.numOfGunnerKilled = numOfGunnerKilled;
    }
    #endregion



    #region Reusable methods
    private void BestiarySwitch(bool _value) {
        bestiary.SetActive(_value);
    }
    private void SetText(Text _text, string _myText) {
        _text.text = _myText;
    }
    private void SetBestiaryText() {
        SetText(chomperText, $"Chomper killed: {numOfChomperKilled}");
        SetText(spitterText, $"Spitter killed: {numOfSpitterKilled}");
        SetText(gunnerText, $"Gunner killed: {numOfGunnerKilled}");
    }
    #endregion



    #region Events methods
    private void SetIsOpen() {
        isOpen = !isOpen;
    }
    #endregion



    private void OnDestroy() {
        RemoveListeners();
    }
    #region OnDestroy methods
    private void RemoveListeners() {
        MessageManager.OnClickCustomButton -= SetIsOpen;
    }
    #endregion
}