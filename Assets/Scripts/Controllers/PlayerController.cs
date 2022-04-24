using UnityEngine;

[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour {
    private GameObject player = null;

    [SerializeField]
    private AnimatorOverrideController[] overrideControllers = new AnimatorOverrideController[(int)SkillType.Last];

    [SerializeField]
    private Animator playerAnimator = null;

    [SerializeField]
    private DatabasePlayer[] myDatabasePlayers = new DatabasePlayer[(int)SkillType.Last];

    [SerializeField]
    private DatabaseInput databaseInput = null;


    [SerializeField]
    private DatabaseKey databaseKey = null;

    [SerializeField]
    DatabaseHealth databaseHealth = null;
    [SerializeField]
    private Sprite shield = null;

    [SerializeField]
    private GameObject club = null;

    [SerializeField]
    private Movement[] playerPrefabs = new Movement[(int)SkillType.Last];

    [SerializeField]
    private FollowTarget playerCamera = null;

    [SerializeField]
    private Ui_LifeBar playerLifeBar = null;

    [SerializeField]
    private NpcManager npcManager = null;

    [SerializeField]
    private GameLogic gameLogic = null;

    public Transform startPosition = null;


    public static PlayerController Instance {
        get;
        private set;
    } = null;


    private void Awake() {
    }



    private void Start() {
        BuildThePlayer();
        Movement.Instance.transform.position = startPosition.position;
        LoadPlayerData();
    }
    private void BuildThePlayer() {
        switch (Save.Instance.skillType) {
            case SkillType.Shield:
                PlayerWithShieldMovement playerWithShieldMovement = Instantiate<PlayerWithShieldMovement>((PlayerWithShieldMovement)playerPrefabs[(int)SkillType.Shield]);              
                playerCamera.playerTransform = playerWithShieldMovement.transform;
                playerCamera.playerSpriteRenderer = playerWithShieldMovement.mySpriteRenderer;
                playerLifeBar.healthModule = playerWithShieldMovement.myHealtModule;
                if (npcManager != null) {
                    npcManager.playerTransform = playerWithShieldMovement.transform;
                }
                gameLogic.playerPosition = playerWithShieldMovement.transform;
                gameLogic.healthModule = playerWithShieldMovement.myHealtModule;
                playerWithShieldMovement.transform.position = transform.position;
                player = playerWithShieldMovement.gameObject;
                break;
            case SkillType.Dash:
                PlayerWithDashMovement playerWithDashMovement = Instantiate<PlayerWithDashMovement>((PlayerWithDashMovement)playerPrefabs[(int)SkillType.Dash]);
                playerCamera.playerTransform = playerWithDashMovement.transform;
                playerCamera.playerSpriteRenderer = playerWithDashMovement.mySpriteRenderer;
                playerLifeBar.healthModule = playerWithDashMovement.myHealtModule;
                if (npcManager != null) {
                    npcManager.playerTransform = playerWithDashMovement.transform;
                }
                gameLogic.playerPosition = playerWithDashMovement.transform;
                gameLogic.healthModule = playerWithDashMovement.myHealtModule;
                playerWithDashMovement.transform.position = transform.position;
                player = playerWithDashMovement.gameObject;



                break;
            case SkillType.Invincibilty:
                PlayerWithInvincibility playerWithInvincibility = Instantiate<PlayerWithInvincibility>((PlayerWithInvincibility)playerPrefabs[(int)SkillType.Invincibilty]);
                playerCamera.playerTransform = playerWithInvincibility.transform;
                playerCamera.playerSpriteRenderer = playerWithInvincibility.mySpriteRenderer;
                playerLifeBar.healthModule = playerWithInvincibility.myHealtModule;
                if (npcManager != null) {
                    npcManager.playerTransform = playerWithInvincibility.transform;
                }
                gameLogic.playerPosition = playerWithInvincibility.transform;
                gameLogic.healthModule = playerWithInvincibility.myHealtModule;
                playerWithInvincibility.transform.position = transform.position;
                player = playerWithInvincibility.gameObject;
                break;
        }
    }
    private void LoadPlayerData() {
        player.transform.position = Save.Instance.playerPosition;
        databaseKey.numOfKeys = Save.Instance.numOfKeys;
    }
    private void SetPlayerComponents(Movement _movement, DatabasePlayer _databasePlayer,
                                     DatabaseInput _databaseInput,
                                     AnimatorOverrideController _animatorOverrideController) {
        _movement.databasePlayer = _databasePlayer;
        _movement.databaseInput = _databaseInput;
        _animatorOverrideController.runtimeAnimatorController = _animatorOverrideController;
    }


    private void Update() {
    }
    private void SavePlayerData() {
        Save.Instance.playerPosition = player.transform.position;
    }


    private void FixedUpdate() {
        
    }
}
