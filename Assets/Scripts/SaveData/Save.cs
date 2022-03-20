using UnityEngine;

public class Save : MonoBehaviour {
    #region Constant
    private const string PREF_SKILLTYPE = "Player_SkillType";
    private const SkillType DEFAULT_SKILLTYPE = SkillType.Shield;


    private const string PREF_PLAYERPOSITION_X = "Player_Position_X";
    private const string PREF_PLAYERPOSITION_Y = "Player_Position_Y";
    private const float DEFAULT_PLAYERPOSITION_X = 0f;
    private const float DEFAULT_PLAYERPOSITION_Y = 0f;


    private const string PREF_HP = "Player_Hp";
    private int DEFAULT_HP = 5;


    private const string PREF_PLAYERNAME = "Player_PlayerName";
    private const string DEFAULT_PLAYERNAME = "Ellen";
    #endregion
    #region Attributes and properties
    [HideInInspector]
    public string playerName;

    [HideInInspector]
    public SkillType skillType;

    [HideInInspector]
    public Vector2 playerPosition;

    [HideInInspector]
    public int playerHp;

    [HideInInspector]
    public static bool isNewGame = false;
    #endregion
    #region Singleton
    public static Save Instance {
        get;
        private set;
    } = null;
    #endregion



    private void Awake() {
        //PlayerPrefs.Save();
        Instance = this;

        //da fare nella prima scena quando verrà selezionato: "Nuovo gioco".
        //FARE ATTENZIONE! UTILIZZANDOLO CI SARà BISOGNO SI UNA NUOVA ISTANZA (O NUOVI PARAMETRI CHE VERRANNO SALVATI NELLE PREFS).
        //PlayerPrefs.DeleteAll();
    }



    private void OnEnable() {
        LoadData();
    }



    private void OnDisable() {
        SaveData();
    }


    #region Public methods
    public void SaveData() {
        PlayerPrefs.SetInt(PREF_SKILLTYPE, (int)skillType);
        PlayerPrefs.SetFloat(PREF_PLAYERPOSITION_X, playerPosition.x);
        PlayerPrefs.SetFloat(PREF_PLAYERPOSITION_Y, playerPosition.y);
        PlayerPrefs.SetInt(PREF_HP, playerHp);
        PlayerPrefs.SetString(PREF_PLAYERNAME, playerName);
    }


    public void LoadData() {
        if (isNewGame) {
            //mi serve che skilltype venga assegnato prima che vengano svuotate le prefs. 
            skillType = (SkillType)PlayerPrefs.GetInt(PREF_SKILLTYPE, (int)DEFAULT_SKILLTYPE);
            PlayerPrefs.DeleteAll();
        }
        else {
            skillType = (SkillType)PlayerPrefs.GetInt(PREF_SKILLTYPE, (int)DEFAULT_SKILLTYPE);
            playerPosition = new Vector2(PlayerPrefs.GetFloat(PREF_PLAYERPOSITION_X, DEFAULT_PLAYERPOSITION_X),
                                         PlayerPrefs.GetFloat(PREF_PLAYERPOSITION_Y, DEFAULT_PLAYERPOSITION_Y));
            playerHp = PlayerPrefs.GetInt(PREF_HP, DEFAULT_HP);
            playerName = PlayerPrefs.GetString(PREF_PLAYERNAME, DEFAULT_PLAYERNAME);
        }
    }
    #endregion
}
