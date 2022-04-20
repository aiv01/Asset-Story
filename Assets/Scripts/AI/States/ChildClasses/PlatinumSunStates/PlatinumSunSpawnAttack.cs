using UnityEngine;
using System.Collections;

public class PlatinumSunSpawnAttack : State {
    private PlatinumSun owner = null;

    [SerializeField]
    private State nextState = null;

    [SerializeField]
    private EnemyManager enemyManager = null;

    private float attackCounter = 0f;
    [SerializeField]
    private float reloadAttackCounter = 10f;

    [SerializeField]
    private float randomSpawnPosOffset = 5f;


    //[SerializeField]
    //private Ghosty myGhosties = null;

    #region Awake methods
    protected override void TakeTheReferences() {
        base.TakeTheReferences();

        owner = GetComponent<PlatinumSun>();
    }
    #endregion



    protected override void Start() {
        base.Start();

        attackCounter = reloadAttackCounter;

        for (int i = 0; i < enemyManager.myEnemies.Count; i++) {
            enemyManager.myEnemies[i].playerTransform = owner.playerTransform;
            enemyManager.myEnemies[i].playerHealth = owner.playerHealth;

        }
    }


    protected override void OnEnterState() {
        base.OnEnterState();

        owner.myRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

    }
    protected override void OnExitState() {
        base.OnExitState();

        owner.myRigidbody.constraints = RigidbodyConstraints2D.None;
        owner.myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }



    public override void Update() {
        base.Update();

        attackCounter -= Time.deltaTime;

        if (ExitCondition()) {
            this.enabled = false;
            nextState.enabled = true;
        }

        if (attackCounter <= 0f) {
            SpawnEnemies();
            StartCoroutine(ResetCounter());
        }
    }
    #region Update methods
    protected override bool ExitCondition() {
        return owner.mySpriteRenderer.color.r >= owner.redThreshold;
    }


    private void SpawnEnemies() {
        enemyManager.GetEnemy((Vector2)transform.position + (Random.insideUnitCircle * randomSpawnPosOffset));
    }
    private IEnumerator ResetCounter() {
        yield return new WaitForSeconds(3f);
        attackCounter = reloadAttackCounter;
    }
    #endregion
}