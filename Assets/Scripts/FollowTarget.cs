using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class FollowTarget : MonoBehaviour {
    #region Private attributes
    private Camera myCamera = null;

    public Transform playerTransform = null;

    public SpriteRenderer playerSpriteRenderer = null;

    [SerializeField]
    private float maxDistY = 0f;
    [SerializeField]
    private float maxDistX = 0f;


    [SerializeField]
    private float smoothOffsetY = 3f;
    private float smoothOffsetX = 1f;
    public float StartPositionY = 0f;
    #endregion
    #region Constant
    private const int CAMERA_DEPTH = -5;
    #endregion
    #region Singleton
    public static FollowTarget Instance {
        get;
        private set;
    } = null;
    #endregion



    void Awake() {
        TakeTheReferences();
        Instance = this;
    }
    #region Awake methods
    private void TakeTheReferences() {
        myCamera = GetComponent<Camera>();
    }
    #endregion



    private void Start() {
        myCamera.depth = CAMERA_DEPTH;
    }


    void Update() {
        Move();
    }
    #region Update methods
    private void Move() {
        #region Variables assignment
        float positionX = Mathf.Lerp(myCamera.transform.position.x, playerTransform.position.x, smoothOffsetX * Time.deltaTime);
        float positionY = Mathf.Lerp(myCamera.transform.position.y, playerTransform.position.y +
                                     playerSpriteRenderer.size.y, smoothOffsetY * Time.deltaTime);
        bool playerIsJumping = Movement.Instance.myAnimator.GetBool("IsJumping");
        #endregion

        if (playerIsJumping) {
            transform.position = new Vector3(positionX, myCamera.transform.position.y, myCamera.depth);
        }
        else { 
            transform.position = new Vector3(positionX, positionY, myCamera.depth);
        }
    }
    #endregion
}