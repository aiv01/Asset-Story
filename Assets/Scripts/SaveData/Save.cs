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
    private const float DEFAULT_PLAYERPOSITION_Y = 5f;

    private const string PREF_CAMERAPOSITION_X = "Camera_Position_X";
    private const string PREF_CAMERAPOSITION_Y = "Camera_Position_Y";
    private const float DEFAULT_CAMERAPOSITION_X = 0f;
    private const float DEFAULT_CAMERAPOSITION_Y = 0f;

    private const string PREF_PLAYERHEALTH = "Player_Health";
    private const float DEFAULT_PLAYERHEALTH = 10f;

    private const string PREF_PLAYERNAME = "Player_PlayerName";
    private const string DEFAULT_PLAYERNAME = "Ellen";

    private const string PREF_NUMOFKEYS = "Key_NumOfKeys";
    private const int DEFAULT_NUMOFKEYS = 0;

    private const string PREF_NUMOFCHOMPERKILLED = "Bestiary_NumOfChomperKilled";
    private const int DEFAULT_NUMOFCHOMPERKILLED = 0;

    private const string PREF_NUMOFSPITTERKILLED = "Bestiary1_NumOfSpitterrKilled";
    private const int DEFAULT_NUMOFSPITTERKILLED = 0;

    private const string PREF_NUMOFGUNNERKILLED = "Bestiary2_NumOfGunnerKilled";
    private const int DEFAULT_NUMOFGUNNERKILLED = 0;

    private const string PREF_CURRENTSCENE = "Player_CurrentScene";
    private const SceneType DEFAULT_CURRENTSCENE = SceneType.StartScene;
    #endregion
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

    [HideInInspector]
    public int numOfChomperKilled;

    [HideInInspector]
    public int numOfSpitterKilled;

    [HideInInspector]
    public int numOfGunnerKilled;

    [HideInInspector]
    public bool keyTaken = false;

    [HideInInspector]
    public Vector2 cameraPosition;

    [HideInInspector]
    public string currentScene;
    #endregion
    #region Singleton
    public static Save Instance {
        get;
        private set;
    } = null;
    #endregion



    private void Awake() {
        Instance = this;
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
        PlayerPrefs.SetFloat(PREF_CAMERAPOSITION_X, cameraPosition.x);
        PlayerPrefs.SetFloat(PREF_CAMERAPOSITION_Y, cameraPosition.y);
        PlayerPrefs.SetFloat(PREF_PLAYERHEALTH, playerHealth);
        PlayerPrefs.SetString(PREF_PLAYERNAME, playerName);
        PlayerPrefs.SetInt(PREF_NUMOFKEYS, numOfKeys);
        PlayerPrefs.SetInt(PREF_NUMOFCHOMPERKILLED, numOfChomperKilled);
        PlayerPrefs.SetInt(PREF_NUMOFSPITTERKILLED, numOfSpitterKilled);
        PlayerPrefs.SetInt(PREF_NUMOFGUNNERKILLED, numOfGunnerKilled);
        PlayerPrefs.SetString(PREF_CURRENTSCENE, currentScene);
    }


    public void LoadData() {
        if (isNewGame) {
            skillType = (SkillType)PlayerPrefs.GetInt(PREF_SKILLTYPE, (int)DEFAULT_SKILLTYPE);
            playerHealth = databaseHealth.maxHealth;
            PlayerPrefs.DeleteAll();
        }
        else {
            skillType = (SkillType)PlayerPrefs.GetInt(PREF_SKILLTYPE, (int)DEFAULT_SKILLTYPE);
            playerPosition = new Vector2(PlayerPrefs.GetFloat(PREF_PLAYERPOSITION_X, DEFAULT_PLAYERPOSITION_X),
                                         PlayerPrefs.GetFloat(PREF_PLAYERPOSITION_Y, DEFAULT_PLAYERPOSITION_Y));
            cameraPosition = new Vector2(PlayerPrefs.GetFloat(PREF_CAMERAPOSITION_X, DEFAULT_CAMERAPOSITION_X),
                                         PlayerPrefs.GetFloat(PREF_CAMERAPOSITION_Y, DEFAULT_CAMERAPOSITION_Y));
            playerHealth = PlayerPrefs.GetFloat(PREF_PLAYERHEALTH, DEFAULT_PLAYERHEALTH);
            playerName = PlayerPrefs.GetString(PREF_PLAYERNAME, DEFAULT_PLAYERNAME);
            numOfKeys = PlayerPrefs.GetInt(PREF_NUMOFKEYS, DEFAULT_NUMOFKEYS);
            numOfChomperKilled = PlayerPrefs.GetInt(PREF_NUMOFCHOMPERKILLED, DEFAULT_NUMOFCHOMPERKILLED);
            numOfSpitterKilled = PlayerPrefs.GetInt(PREF_NUMOFSPITTERKILLED, DEFAULT_NUMOFSPITTERKILLED);
            numOfGunnerKilled = PlayerPrefs.GetInt(PREF_NUMOFGUNNERKILLED, DEFAULT_NUMOFGUNNERKILLED);
            currentScene = PlayerPrefs.GetString(PREF_CURRENTSCENE, DEFAULT_CURRENTSCENE.ToString());
        }
    }


    //public void DeleteChangeSceneData() {
    //    numOfKeys = 0;
    
    //}
    #endregion
}