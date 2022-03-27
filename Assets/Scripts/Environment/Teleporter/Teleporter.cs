using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Teleporter : MonoBehaviour {
    #region Attributes
    private BoxCollider2D myCollider = null;
    private SpriteRenderer mySpriteRenderer = null;
    private Animator myAnimator = null;
    #endregion
    #region Constant
    private const int TELEPORTER_SORTINGORDER = -1;
    #endregion



    void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }
    #endregion



    void Start() {
        VariablesAssignment();
    }
    #region Start methods
    private void VariablesAssignment() {
        myCollider.isTrigger = true;
        mySpriteRenderer.sortingOrder = TELEPORTER_SORTINGORDER;
        myAnimator.speed = 1;
    }
    #endregion



    void Update() {

    }
    #region Update methods
    #endregion

   
    
    void FixedUpdate() {

    }
    #region FixedUpdate methods
    #endregion



    #region Public methods
    #endregion



    #region Private methods
    #endregion



    #region OnCollision methods
    #endregion



    #region OnTrigger methods
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            SceneManager.LoadScene(SceneType.StartScene.ToString());
        }
    }
    #endregion 
}
