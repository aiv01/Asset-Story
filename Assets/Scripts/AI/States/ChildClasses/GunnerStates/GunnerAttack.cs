using UnityEngine;
using System.Collections;

public class GunnerAttack : State {
    #region Private enum
    private enum AttackType : byte { 
        GrenadeAttack,
        BeamAttack,
        LightingAttack,
        DashAttack,
        Last
    }
    #endregion

    private bool[] attacks = new bool[(int)AttackType.Last];


    [SerializeField]
    private BulletManagerNS bulletManagerNS = null;

    private Gunner owner = null;

    private float counter = 0f;
    [SerializeField]
    private float reloadCounter = 1.5f;

    protected override void Awake() {
        base.Awake();

        this.enabled = false;
    }

    private int index = 0;

    private int attackedTimes = 3;

    [SerializeField]
    private State nextState = null;


    private const float BULLETPOSITION_OFFSET_Y = 0.8f;


    private float dashForce = 50f;

    private Vector2 startPosition = Vector2.zero;

    private float diff = 0f;

    public bool isDash = false;

    [SerializeField]
    private float dashThreshold = 20f;

    #region OnEnable methods
    protected override void OnEnterState() {
        base.OnEnterState();

        SetFlags();
        ActiveRandomFlag();
    }
    private void SetFlags() {
        for (int i = 0; i < attacks.Length; i++) {
            attacks[i] = false;
        }
    }
    private void ActiveRandomFlag() {
        attacks[Random.Range((int)AttackType.GrenadeAttack, (int)AttackType.DashAttack)] = true;
    }
    #endregion

    protected override void TakeTheReferences() {
        base.TakeTheReferences();

        owner = GetComponent<Gunner>();
    }



    protected override void Start() {
        base.Start();

        counter = reloadCounter;
        startPosition = transform.position;
        attacks[(int)AttackType.DashAttack] = true;
        isDash = attacks[(int)AttackType.DashAttack];
    }


    protected override void OnExitState() {
        base.OnExitState();

        index = 0;
        myAnimator.SetBool("IsGunnerGrenadeAttack", false);
        myAnimator.SetBool("IsDashAttack", false);
    }


    public override void Update() {
        //if (attacks[(int)AttackType.GrenadeAttack]) {
        //    counter -= Time.deltaTime;
        //}


        //ATTACK
        //myAnimator.SetBool("IsGunnerGrenadeAttack", true);
        //counter -= Time.deltaTime;

        //if (counter <= 0) {
        //    GrenadeAttack();
        //    counter = reloadCounter;
        //    index += 1;
        //}

        //if (index == attackedTimes) {
        //    this.enabled = false;
        //    nextState.enabled = true;
        //}


        //DASH
        if (isDash) {
            myAnimator.SetBool("IsDashAttack", isDash);
            DashAttack();
        }
        else {

            //this.enabled = false;
            //nextState.enabled = true;
            StartCoroutine(GoToTheNextState());
        }

        //if (diff >= dashThreshold) {
        //    isDash = false;
        //}
        //else {
        //    this.enabled = false;
        //    nextState.enabled = true;
        //}



    }
    #region Update methods
    protected override bool ExitCondition() {
        return false;
    }
    #endregion
    private IEnumerator GoToTheNextState() {
        yield return new WaitForSeconds(2f);
        this.enabled = false;
        nextState.enabled = true;
    }



    public override void FixedUpdate() {
        base.FixedUpdate();

    }


    #region Attack methods
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


    private void DashAttack() {
        #region Variables assignment
        Vector2 force = !owner.IsFlipped ? -transform.right * dashForce :
                        transform.right * dashForce;

        Vector2 flat = FlattenVector(transform.position);

        diff += Mathf.Abs(flat.x - startPosition.x); 
        #endregion

        myRigidbody.AddForce(force, ForceMode2D.Impulse);


        if (diff >= dashThreshold) {
            isDash = false;
            diff = 0f;
            //databasePlayer.skillCounter = databasePlayer.ReloadSkillCounter;
        }
    }
    #endregion
}