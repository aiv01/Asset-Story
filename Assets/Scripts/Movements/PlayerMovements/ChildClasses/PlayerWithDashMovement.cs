using UnityEngine;

public class PlayerWithDashMovement : Movement, IDashable {
    bool isDash = false;

    //private Vector2 direction = Vector2.zero;
    Vector2 startPosition;
    protected override void Update() {
        base.Update();
        if (databaseInput.Player.GetButtonDown
           (databaseInput.SpecialSkillButton)) {
            isDash = !isDash;
            startPosition = transform.position;
        }
    }



    protected override void FixedUpdate() {
        base.FixedUpdate();
        if (isDash) {
            Dash();
        }
        else {
            SetAnimatorParameters("IsInSpecialSkillMode", false);
            mySpriteRenderer.color = Color.white;
        }
    }



    float diff;

    public void Dash() {
        SetAnimatorParameters("IsInSpecialSkillMode", true);
        //Vector2 inputDirection = Vector2.SignedAngle(transform.forward, );


        //float dir = Mathf.DeltaAngle(databaseInput.horizontal,
        //                             databaseInput.vertical);
        mySpriteRenderer.color = new Color(1, 1, 1, 0.2f);
        Vector2 a = !mySpriteRenderer.flipX ? transform.right * 10 :
                   -transform.right * 10;
        myRigidbody.AddForce(a, ForceMode2D.Impulse);
        Vector2 flat = FlattenVector(transform.position);
        //Vector2 diff = flat - startPosition;
        //float diff = 0;
        diff += Mathf.Abs(flat.x - startPosition.x);

        if (diff > 10f) {
            isDash = false;
            diff = 0f;
            //Debug.Log(diff);
        }

        //Debug.Log($"STARTPOSITION {startPosition}");
        //Debug.Log(diff);
        //if (a.magnitude > 50) {
        //    isDash = false;
        //}
    }
}
