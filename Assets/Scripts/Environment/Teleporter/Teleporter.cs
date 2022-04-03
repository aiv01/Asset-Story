using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Teleporter : MonoBehaviour {
    #region Private attributes
    private BoxCollider2D myCollider = null;
    private SpriteRenderer mySpriteRenderer = null;
    private Animator myAnimator = null;

    [SerializeField]
    private SceneType nextScene = SceneType.Last;
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



    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            LoadNextScene();
        }
    }
    #region OnTrigger methods
    private void LoadNextScene() { 
        SceneManager.LoadScene(nextScene.ToString());
    }
    #endregion 
}