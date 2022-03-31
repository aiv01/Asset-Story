using UnityEngine;
using System.Collections;

public class SpitterAttack : State {
    #region Attributes
    [SerializeField]
    private Enemy enemy = null;

    [SerializeField]
    private State nextState = null;

    [SerializeField]
    private float minDist = 5f;

    private float counter = 0f;

    [SerializeField]
    private float reloadCounter = 3f;

    [SerializeField]
    private BulletManagerNS bulletManagerNS = null;


    private Vector3 bulletFlippedPosition = new Vector3(-1, 1, 0);
    private Vector3 bulletPosition = new Vector3(1, 1, 0);
    #endregion



    protected override void Awake() {
        base.Awake();
        this.enabled = false;
    }
    protected override void TakeTheReferences() {
        base.TakeTheReferences();
        enemy = GetComponent<Enemy>();
    }



    protected override void Start() {
        base.Start();

        counter = 0;
    }



    public override void Update() {
        base.Update();

        counter -= Time.deltaTime;

        if (ExitCondition()) {
            this.enabled = false;
            nextState.enabled = true;
        }

        myAnimator.SetBool("IsAttacking", true);

        if (counter <= 0) {
            StartCoroutine(ActivateShoot());
            counter = reloadCounter;
        }
        else {
            myAnimator.SetBool("IsAttacking", false);
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        return Mathf.Abs(transform.position.x - playerTransform.position.x) >= minDist; 
    }


    private IEnumerator ActivateShoot() {
        yield return new WaitForSeconds(0.8f);

        if (Enemy.IsFlipped) {
            bulletManagerNS.GetBullet(transform.position + bulletFlippedPosition);
        }
        else {
            bulletManagerNS.GetBullet(transform.position + bulletPosition);
        }
    }
    #endregion
}