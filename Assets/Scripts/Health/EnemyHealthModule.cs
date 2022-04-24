using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class EnemyHealthModule : MonoBehaviour {
    #region Private attributes
    public float maxHealth = 0f;
    private float health = 0f;
    private Animator myAnimator = null;
    private Enemy owner = null;
    #endregion
    #region Public properties
    public float Health {
        get { return health; }
        set {
            health = value > maxHealth ? health = maxHealth :
                     value < 0 ? health = 0 : health = value;
        }
    }


    public float CurrentHealthPercentage {
        get { return Health / maxHealth; }
    }
    #endregion



    void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myAnimator = gameObject.GetComponent<Animator>();
        owner = GetComponent<Enemy>();
    }
    #endregion



    void Start() {
        VariablesAssignment();
    }
    #region Start methods
    private void VariablesAssignment() {
        health = maxHealth;
    }
    #endregion



    void Update() {
        if (Died()) {
            StartCoroutine(EnemyDeath());
        }
    }
    #region Update methods
    public bool Died() {
        return Health <= 0f;
    }


    private IEnumerator EnemyDeath() {
        if (owner is Gunner ownerGunner) {
            MessageManager.CallOnGunnerDead();
            ownerGunner.myAnimator.speed = 0.5f;
            ownerGunner.myAnimator.SetBool("IsDead", true);
            yield return new WaitForSeconds(4.5f);
            gameObject.SetActive(false);
        }
        else if (owner is Spitter ownerSpitter) {
            ownerSpitter.myRigidbody.simulated = false;
            myAnimator.SetBool("IsDead", true);
            MessageManager.CallOnSpitterDead();
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
        else if (owner is Chomper ownerChomper) {
            ownerChomper.myRigidbody.simulated = false;
            myAnimator.SetBool("IsDead", true);
            MessageManager.CallOnChomperDead();
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
        else if (owner is Ghosty ownerGhosty) {
            ownerGhosty.mySpriteRenderer.color = ownerGhosty.newColor;
            ownerGhosty.myCollider.enabled = false;
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }
        else if (owner is PlatinumSun ownerPlatinumSun) {
            ownerPlatinumSun.mySpriteRenderer.color = new Vector4(0f, 0f, 0f, 1f);
            Mathf.Lerp(ownerPlatinumSun.gameObject.transform.localScale.x, 0.2f, Time.deltaTime);
            Mathf.Lerp(ownerPlatinumSun.gameObject.transform.localScale.y, 0.2f, Time.deltaTime);
            yield return new WaitForSeconds(5f);
            gameObject.SetActive(false);
        }
    }
    #endregion



    #region Public methods
    public void TakeDamage(float _damage) {
        Health -= _damage;
    }
    public void TakeHealth(float _health) {
        Health += _health;
    }
    #endregion
}