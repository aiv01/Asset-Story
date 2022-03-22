using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlatformEffector2D))]
public class Platform : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private DatabasePlatform databasePlatform = null;
    private BoxCollider2D myBoxCollider = null;
    private PlatformEffector2D myPlatformEffector2D = null;
    [SerializeField]
    private SpriteRenderer[] mySpriteRenderers = null;


    private Vector2 startPosition = Vector2.zero;
    #endregion



    private void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myBoxCollider = GetComponent<BoxCollider2D>();
        myPlatformEffector2D = GetComponent<PlatformEffector2D>();
    } 
    #endregion



    private void Start() {
        VariablesAssignment();
    }
    #region Start methods
    private void VariablesAssignment() {
        startPosition = transform.position;
        myBoxCollider.usedByEffector = true;
        myPlatformEffector2D.useOneWay = true;
        myPlatformEffector2D.useSideBounce = true;

        for (int i = 0; i < mySpriteRenderers.Length; i++) {
            mySpriteRenderers[i].sortingOrder = 1;
        }
    } 
    #endregion



    private void Update() {
        Movement();
    }
    #region Update methods
    private void Movement() {
        #region Variables assignment
        float minClampValue = -1;
        float maxClampValue = 1;

        Vector2 direction = databasePlatform.MovementType == PlatformMovementType.UpDown ?
                            Vector2.up : Vector2.right;
        #endregion

        transform.position = startPosition + direction * Mathf.Clamp(Mathf.Sin(Time.time * databasePlatform.Speed) *
                             databasePlatform.SinMultiplier, minClampValue, maxClampValue) * databasePlatform.Distance;
    }
    #endregion



    #region OnCollision methods
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            collision.gameObject.transform.SetParent(null);
        }
    }
    #endregion
}