using UnityEngine;

public class Save : MonoBehaviour {
    [SerializeField]
    private DatabaseHealth databaseHealth = null;
    #region Constant
    private const string PREF_SKILLTYPE = "Player_SkillType";
    private const SkillType DEFAULT_SKILLTYPE = SkillType.Shield;


    private const string PREF_PLAYERPOSITION_X = "Player_Position_X";
    private const string PREF_PLAYERPOSITION_Y = "Player_Position_Y";
    private const float DEFAULT_PLAYERPOSITION_X = 0f;
    private const float DEFAULT_PLAYERPOSITION_Y = 0f;


    private const string PREF_PLAYERHEALTH = "Player_Health";
    public float DEFAULT_PLAYERHEALTH = 10;


    private const string PREF_PLAYERNAME = "Player_PlayerName";
    private const string DEFAULT_PLAYERNAME = "Ellen";


    private const string PREF_NUMOFKEYS = "Key_NumOfKeys";
    private const int DEFAULT_NUMOFKEYS = 0;

   

    //private const string PREF_CHECKPOINT_ISACTIVATED = "CheckPoint_IsActivated";
    //private const CheckPointSwitch DEFAULT_CHECKPOINT_ISACTIVATED = CheckPointSwitch.Off;


    private string[] PREF_KEYTAGS;               /*    = new string[] { "Key_KeyTaken_1", "Key_KeyTaken_2", "Key_KeyTaken_3" };*/
    /*private string DEAFAULT_KEYSTAGS;*/               /*= new string[] { "Key", "Key", "Key" };*/
    //private const CheckPointSwitch[] DEFAULT_CHECKPOINTS_ISACTIVATED = null;
    //[SerializeField]
    //private const string[]

    private const string PREF_KEYTAGS_1 = "Key_KeyTags_1";
    private const string PREF_KEYTAGS_2 = "Key_KeyTags_2";
    private const string PREF_KEYTAGS_3 = "Key_KeyTags_3";

    private const string DEAFAULT_KEY = "Key";               /*= new string[] { "Key", "Key", "Key" };*/

    [HideInInspector]
    public string keytag_1 = "Key";
    [HideInInspector]
    public string keytag_2 = "Key";
    [HideInInspector]
    public string keytag_3 = "Key";


    [HideInInspector]
    public int keyID_1;
    [HideInInspector]
    public int keyID_2;
    [HideInInspector]
    public int keyID_3;

    [HideInInspector]
    public string[] keytags;

    #endregion

    //private const string PREF_KEYTAKEN = "Key_KeyTaken";
    //private const bool DEAFAULT_KEYTAKEN = false;
    #region Attributes and properties
    [HideInInspector]
    public string playerName;

    [HideInInspector]
    public SkillType skillType;

    [HideInInspector]
    public Vector2 playerPosition;

    [HideInInspector]
    public float playerHealth;

    [HideInInspector]
    public static bool isNewGame = false;

    [HideInInspector]
    public int numOfKeys;

    //[HideInInspector]
    //public CheckPointSwitch isActivated;
    #endregion
    #region Singleton
    public static Save Instance {
        get;
        private set;
    } = null;
    #endregion

    [HideInInspector]
    public bool keyTaken = false;



    private void Awake() {
        //PlayerPrefs.Save();
        Instance = this;

        //da fare nella prima scena quando verrà selezionato: "Nuovo gioco".
        //FARE ATTENZIONE! UTILIZZANDOLO CI SARà BISOGNO SI UNA NUOVA ISTANZA (O NUOVI PARAMETRI CHE VERRANNO SALVATI NELLE PREFS).
        //PlayerPrefs.DeleteAll();





        //VERSIONE FUNZIONANTE
        //PREF_KEYTAGS = new string[3];
        //keytags = new string[3];

        //PREF_KEYTAGS[0] = "Key_KeyTaken_1";
        //PREF_KEYTAGS[1] = "Key_KeyTaken_2";
        //PREF_KEYTAGS[2] = "Key_KeyTaken_3";

        ////if () {

        ////}
        //keytags[0] = "Key";
        //keytags[1] = "Key";
        //keytags[2] = "Key";






        //if (!isNewGame) {
        //    keytags[0] = PlayerPrefs.GetString(PREF_KEYTAGS[0], DEAFAULT_KEY);
        //    keytags[1] = PlayerPrefs.GetString(PREF_KEYTAGS[1], DEAFAULT_KEY);
        //    keytags[2] = PlayerPrefs.GetString(PREF_KEYTAGS[2], DEAFAULT_KEY);

        //}
        //else {
        //    keytags[0] = "Key";
        //    keytags[1] = "Key";
        //    keytags[2] = "Key";

        //}

        //DEAFAULT_KEYSTAGS = "Key";
    }


    private void Update() {
        //keytags[0] = "Key";
        //keytags[1] = "Key";
        //keytags[2] = "Key";
        //keytags[0] = PlayerPrefs.GetString(PREF_KEYTAGS[0], DEAFAULT_KEY);
        //keytags[1] = PlayerPrefs.GetString(PREF_KEYTAGS[1], DEAFAULT_KEY);
        //keytags[2] = PlayerPrefs.GetString(PREF_KEYTAGS[2], DEAFAULT_KEY);
    }



    private void Start() {
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
        PlayerPrefs.SetFloat(PREF_PLAYERHEALTH, playerHealth);
        PlayerPrefs.SetString(PREF_PLAYERNAME, playerName);
        PlayerPrefs.SetInt(PREF_NUMOFKEYS, numOfKeys);
        //PlayerPrefs.SetInt(PREF_CHECKPOINT_ISACTIVATED, (int)isActivated);

        //for (int i = 0; i < PREF_KEYTAGS.Length; i++) {
        //    PlayerPrefs.SetString(PREF_KEYTAGS[i], keytags[i]);
        //}

        //PlayerPrefs.SetString(PREF_KEYTAGS_1, keytags[0]);
        //PlayerPrefs.SetString(PREF_KEYTAGS_2, keytags[1]);
        //PlayerPrefs.SetString(PREF_KEYTAGS_3, keytags[2]);



        //PlayerPrefs.SetInt(PREF_KEYTAGS_1, keyID_1);
        //PlayerPrefs.SetInt(PREF_KEYTAGS_2, keyID_2);
        //PlayerPrefs.SetInt(PREF_KEYTAGS_3, keyID_3);












        //VERSIONE FUNZIONANTE

        //PlayerPrefs.SetString(PREF_KEYTAGS[0], keytags[0]);
        //PlayerPrefs.SetString(PREF_KEYTAGS[1], keytags[1]);
        //PlayerPrefs.SetString(PREF_KEYTAGS[2], keytags[2]);

        //PlayerPrefs.SetString(PREF_KEYTAGS_1, keytag_1);
        //PlayerPrefs.SetString(PREF_KEYTAGS_2, keytag_2);
        //PlayerPrefs.SetString(PREF_KEYTAGS_3, keytag_3);


    }


    public void LoadData() {
        if (isNewGame) {
            //mi serve che skilltype venga assegnato prima che vengano svuotate le prefs. 
            skillType = (SkillType)PlayerPrefs.GetInt(PREF_SKILLTYPE, (int)DEFAULT_SKILLTYPE);
            //playerHealth = DEFAULT_PLAYERHEALTH;
            playerHealth = databaseHealth.MaxHealth;
            //playerHealth = PlayerPrefs.GetFloat(PREF_PLAYERHEALTH, databaseHealth.MaxHealth);
            //numOfKeys = 0;

            PlayerPrefs.DeleteAll();
            //PlayerPrefs.
            //PlayerPrefs.DeleteKey()
        }
        else {
            skillType = (SkillType)PlayerPrefs.GetInt(PREF_SKILLTYPE, (int)DEFAULT_SKILLTYPE);
            playerPosition = new Vector2(PlayerPrefs.GetFloat(PREF_PLAYERPOSITION_X, DEFAULT_PLAYERPOSITION_X),
                                         PlayerPrefs.GetFloat(PREF_PLAYERPOSITION_Y, DEFAULT_PLAYERPOSITION_Y));
            playerHealth = PlayerPrefs.GetFloat(PREF_PLAYERHEALTH, DEFAULT_PLAYERHEALTH);
            //playerHealth = PlayerPrefs.GetFloat(PREF_PLAYERHEALTH, databaseHealth.MaxHealth);

            playerName = PlayerPrefs.GetString(PREF_PLAYERNAME, DEFAULT_PLAYERNAME);
            numOfKeys = PlayerPrefs.GetInt(PREF_NUMOFKEYS, DEFAULT_NUMOFKEYS);
            //isActivated = (CheckPointSwitch)PlayerPrefs.GetInt(PREF_CHECKPOINT_ISACTIVATED, (int)DEFAULT_CHECKPOINT_ISACTIVATED);

            //keyTak
            //for (int i = 0; i < keytags.Length; i++) {
            //    keytags[i] = PlayerPrefs.GetString(PREF_KEYTAGS[i], DEAFAULT_KEYSTAGS);
            //}



            //keytags[0] = PlayerPrefs.GetString(PREF_KEYTAGS_1, DEAFAULT_KEY);
            //keytags[1] = PlayerPrefs.GetString(PREF_KEYTAGS_2, DEAFAULT_KEY);
            //keytags[2] = PlayerPrefs.GetString(PREF_KEYTAGS_3, DEAFAULT_KEY);





            //keyID_1 = PlayerPrefs.GetInt(PREF_KEYTAGS_1, 0);
            //keyID_2 = PlayerPrefs.GetInt(PREF_KEYTAGS_2, 1);
            //keyID_3 = PlayerPrefs.GetInt(PREF_KEYTAGS_3, 2);







            //VERSIONE FUNZIONANTE
            //keytags[0] = PlayerPrefs.GetString(PREF_KEYTAGS[0], DEAFAULT_KEY);
            //keytags[1] = PlayerPrefs.GetString(PREF_KEYTAGS[1], DEAFAULT_KEY);
            //keytags[2] = PlayerPrefs.GetString(PREF_KEYTAGS[2], DEAFAULT_KEY);

            //keytag_1 = PlayerPrefs.GetString(PREF_KEYTAGS_1, DEAFAULT_KEY);
            //keytag_2 = PlayerPrefs.GetString(PREF_KEYTAGS_2, DEAFAULT_KEY);
            //keytag_3 = PlayerPrefs.GetString(PREF_KEYTAGS_3, DEAFAULT_KEY);
        }
    }
    #endregion
}
