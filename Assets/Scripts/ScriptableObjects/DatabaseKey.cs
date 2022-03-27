using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseKey")]
public class DatabaseKey : ScriptableObject {
    [Header("KEY DATA")]
    #region Attributes and properties
    [HideInInspector]
    public bool isTaken = false;


    [HideInInspector]
    public int numOfKeys = 0;
    #endregion
    [Header("SPRITE RENDERER PARAMETERS")]
    #region Sprite Renderer attributes and properties
    [SerializeField]
    [Tooltip("Sprite of the key")]
    private Sprite sprite = null;
    public Sprite Sprite {
        get { return sprite; }
    }
    #endregion
    [Header("ANIMATOR PARAMETERS")]
    #region Animator attributes and properties
    [SerializeField]
    [Range(0.1f, 10f)]
    [Tooltip("Speed at which the animation clip plays")]
    private float animatorSpeed = 1f;
    public float AnimatorSpeed {
        get { return animatorSpeed; }
    }
    #endregion


    public int keyID = 0;

    //private void SaveKeyID() {
    //    if (keyID == 0) {
    //        Save.Instance.keytag_1 = keyID;
    //    }

    //}
}