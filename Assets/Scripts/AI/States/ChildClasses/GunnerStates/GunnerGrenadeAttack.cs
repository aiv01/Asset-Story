using UnityEngine;
using System.Collections;

public class GunnerGrenadeAttack : State {
    #region Serialized attributes
    [SerializeField]
    private BulletManagerNS bulletManagerNS = null;
    [SerializeField]
    private float reloadCounter = 1.5f;
    [SerializeField]
    private State nextState = null;
    #endregion
    #region Private attributes
    private Enemy owner = null;
    private float counter = 0f;
    private int attackEnhancer = 0;
    private int attackedTimes = 5;
    #endregion
    #region Constant
    private const float BULLETPOSITION_OFFSET_Y = 0.8f;
    #endregion



    protected override void Awake() {
        base.Awake();

        this.enabled = false;
    }
    #region Awake methods
    protected override void TakeTheReferences() {
        base.TakeTheReferences();

        owner = GetComponent<Enemy>();
    } 
    #endregion



    #region OnEnable methods
    protected override void OnEnterState() {
        base.OnEnterState();

        myAnimator.SetBool("IsGunnerGrenadeAttack", true);
    }
    #endregion
    #region OnDisable methods
    protected override void OnExitState() {
        base.OnExitState();

        attackEnhancer = 0;
        myAnimator.SetBool("IsGunnerGrenadeAttack", false);
    }
    #endregion



    protected override void Start() {
        base.Start();

        counter = reloadCounter;
        AssignPlayerHealth();
    }
    private void AssignPlayerHealth() { 
        for (int i = 0; i < bulletManagerNS.myBullets.Count; i++) {
            bulletManagerNS.myBullets[i].playerHealth = owner.playerHealth;
        }
    }



    public override void Update() {
        counter -= Time.deltaTime;

        if (ExitCondition()) {
            this.enabled = false;
            nextState.enabled = true;
        }

        if (counter <= 0) {
            //GrenadeAttack();
            StartCoroutine(Attack());
            counter = reloadCounter;
            attackEnhancer += 1;
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        return attackEnhancer == attackedTimes;
    }
    #endregion



    #region Attack methods
    private IEnumerator Attack() {
        yield return new WaitForSeconds(0.25f);
        MessageManager.CallOnGunnerShoot();
        GrenadeAttack();
    }


    private void GrenadeAttack() {
        #region Variables assignment
        Vector3 flippedPosition = new Vector3(3, BULLETPOSITION_OFFSET_Y, 0);
        Vector3 notFLippedPosition = new Vector3(-3, BULLETPOSITION_OFFSET_Y, 0);
        #endregion

        if (owner.IsFlipped) {
            bulletManagerNS.GetBullet(transform.position + flippedPosition, Vector2.right);
        }
        else {
            bulletManagerNS.GetBullet(transform.position + notFLippedPosition, -Vector2.right);
        }
    }
    #endregion
}