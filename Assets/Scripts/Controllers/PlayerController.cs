using UnityEngine;

[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    [Tooltip("Object that represents the player")]
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


    private void Awake() {
        //Questa operazione verrà eseguita nella scena precedente e 
        //quindi all'interno della variabile sarà già salvato un valore utilizzabile.

        //Save.Instance.skillType = SkillType.Shield;
    }



    private void Start() {
        BuildThePlayer();
        LoadPlayerData();
    }
    private void BuildThePlayer() {
        switch (Save.Instance.skillType) {
            case SkillType.Shield:
                PlayerWithShieldMovement playerWithShieldMovement = player.AddComponent<PlayerWithShieldMovement>();
                playerWithShieldMovement.databasePlayer = myDatabasePlayers[(int)SkillType.Shield];
                playerWithShieldMovement.databaseInput = databaseInput;
                playerWithShieldMovement.shieldSprite = shield;
                //playerAnimator.runtimeAnimatorController = overrideControllers[(int)SkillType.Shield];
                //player.AddComponent<> //gli attacchiamo come componente la classe figlia di Movement.
                //player.AddComponent<> //gli assegnamo all'animator del player (in caso non fosse il tipo standard), il suo override controller.
                break;
            case SkillType.Dash:
                PlayerWithDashMovement playerWithDashMovement = player.AddComponent<PlayerWithDashMovement>();
                playerWithDashMovement.databasePlayer = myDatabasePlayers[(int)SkillType.Dash];
                playerWithDashMovement.databaseInput = databaseInput;
                playerAnimator.runtimeAnimatorController = overrideControllers[(int)SkillType.Dash];
                //playerWithDashMovement.shieldSprite = shield;
                //playerWithDashMovement
                break;
            case SkillType.Invincibilty:
                PlayerWithInvincibility playerWithInvincibility = player.AddComponent<PlayerWithInvincibility>();
                playerWithInvincibility.databasePlayer = myDatabasePlayers[(int)SkillType.Invincibilty];
                playerWithInvincibility.databaseInput = databaseInput;
                playerAnimator.runtimeAnimatorController = overrideControllers[(int)SkillType.Invincibilty];
                break;
        }
    }
    private void LoadPlayerData() {
        player.transform.position = Save.Instance.playerPosition;
        databaseKey.numOfKeys = Save.Instance.numOfKeys;
       // databaseHealth.Health = Save.Instance.playerHealth;
    }
    private void SetPlayerComponents(Movement _movement, DatabasePlayer _databasePlayer,
                                     DatabaseInput _databaseInput,
                                     AnimatorOverrideController _animatorOverrideController) {
        _movement.databasePlayer = _databasePlayer;
        _movement.databaseInput = _databaseInput;
        _animatorOverrideController.runtimeAnimatorController = _animatorOverrideController;
    }


    private void Update() {
        //SavePlayerData();
    }
    private void SavePlayerData() {
        //IN UN EVENTO QUANDO PREMERò IL TASTO 'SALVA' ESEGUIRò TUTTE QUESTE OPERAZIONI
        //Debug.Log(Save.Instance.playerPosition);
        Save.Instance.playerPosition = player.transform.position;
    }


    private void FixedUpdate() {
        
    }
}
