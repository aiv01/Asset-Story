using UnityEngine;
using Rewired;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseInput")]
public class DatabaseInput : ScriptableObject {
    #region Rewired reference
    private Player player = null;
    public Player Player {
        get { return player; }
    }
    #endregion
    [Header("REWIRED DATA")]
    #region Rewired attributes
    [SerializeField]
    [Tooltip("Player ID defined in rewired")]
    private int playerID = 0;


    [SerializeField]
    [Tooltip("Axis name defined in rewired for the movement on the 'X axis'")]
    private string xAxis = null;


    [SerializeField]
    [ActionIdProperty(typeof(RewiredConsts.Action))]
    private int inputA = -1;



    [SerializeField]
    [Tooltip("Axis name defined in rewired for the movement on the 'Y axis'")]
    private string yAxis = null;


    [SerializeField]
    [Tooltip("Button name defined in rewired for the 'run'")]
    private string runButton = null;
    public string RunButton {
        get { return runButton; }
    }


    [SerializeField]
    [Tooltip("Button name defined in rewired for the 'run'")]
    private string crouchButton = null;
    public string CrouchButton {
        get { return crouchButton; }
    }


    [SerializeField]
    [Tooltip("Button name defined in rewired for the 'jump'")]
    private string jumpButton = null;
    public string JumpButton {
        get { return jumpButton; }
    }


    [SerializeField]
    [Tooltip("Button name defined in rewired for the 'hit'")]
    private string hitButton = null;
    public string HitButton {
        get { return hitButton; }
    }


    [SerializeField]
    [Tooltip("Button name defined in rewired for the 'shoot'")]
    private string shootButton = null;
    public string ShootButton {
        get { return shootButton; }
    }


    [SerializeField]
    [Tooltip("Button name defined in rewired for the 'special skill'")]
    private string specialSkillButton = null;
    public string SpecialSkillButton {
        get { return specialSkillButton; }
    }
    #endregion
    #region Attributes
    [HideInInspector]
    public float horizontal = 0f;


    [HideInInspector]
    public float vertical = 0f;
    #endregion
    #region Methods
    public void AssignRewiredPlayer() {
        player = ReInput.players.GetPlayer(playerID);
    }


    public void TakeTheInputs() {
        horizontal = Player.GetAxis(xAxis);
        vertical = Player.GetAxis(yAxis);
    }
    #endregion
}
