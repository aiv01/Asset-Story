using UnityEngine;

public class PlatinumSun : Enemy {

    public DatabaseDamage platinumSunDamage = null;

    public GameObject bar = null;
    public CircleCollider2D circleCollider = null;

    private float redOffset = 0f;
    private float greenOffset = 0f;
    private float blueOffset = 0f;


    public float redThreshold = 0.99f;

    protected override void Start() {
        base.Start();

        mySpriteRenderer.color = new Vector4(redOffset, greenOffset, blueOffset, 1);
        bar.SetActive(false);
        myCollider.enabled = false;
        //playerTransform = Movement.Instance.transform;
    }
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        redOffset = 0f;
        greenOffset = 1f;
        blueOffset = 1f;
    }


    protected override void Update() {
        if (mySpriteRenderer.color.r >= redThreshold) {
            bar.SetActive(true);
        }

        //playerTransform = Movement.Instance.transform;

    }



    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Bullet")) {
            if (mySpriteRenderer.color.r >= 0.99f) {

                myHealthModule.TakeDamage(1);
            }
            mySpriteRenderer.color = new Vector4(redOffset += 0.005f, greenOffset -= 0.005f, blueOffset -= 0.005f, 1);
        }

        if (collision.collider.CompareTag("Player")) {
            playerHealth.TakeDamage(platinumSunDamage.meleeDamage);
        }
    }
}