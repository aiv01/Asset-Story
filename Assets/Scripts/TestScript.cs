using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
public class TestScript : MonoBehaviour {
    private Collider2D myCollider = null;
    private const string DEBUG_STRING = "BAU";
    private const string DEBUG_STRING = "MIAO";

    private void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myCollider = GetComponent<Collider2D>();
    }
    #endregion



    private void Start() {
        SetColliderParameters(false);
    }
    #region Start methods
    private void SetColliderParameters(bool _value) {
        myCollider.isTrigger = _value;
    }
    #endregion



    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Debug.Log(DEBUG_STRING);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log(DEBUG_STRING);
        }
    }
}
