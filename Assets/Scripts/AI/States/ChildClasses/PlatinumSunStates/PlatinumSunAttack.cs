using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatinumSunAttack : State {
    private PlatinumSun owner = null;

    [SerializeField]
    private float attackSpeed = 0f;
    private float AttackSpeed {
        get { return attackSpeed * Time.fixedDeltaTime; }
    }


    protected override void Awake() {
        base.Awake();

        this.enabled = false;
    }



    protected override void TakeTheReferences() {
        base.TakeTheReferences();

        owner = GetComponent<PlatinumSun>();
    }



    public override void Update() {
        base.Update();

        if (ExitCondition()) {
            this.enabled = false;
        }
    }
    protected override bool ExitCondition() {
        return owner.myHealthModule.Health <= 0f;
    }

    Vector2 direction = -Vector2.right + Vector2.up;

    public override void FixedUpdate() {
        base.FixedUpdate();

        Attack();
    }
    private void Attack() {

        myRigidbody.velocity = direction.normalized * (AttackSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 0) {

            direction = Random.insideUnitCircle;
        }
    }
}