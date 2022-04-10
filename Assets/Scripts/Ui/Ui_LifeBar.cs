using UnityEngine;

[DisallowMultipleComponent]
public class Ui_LifeBar : MonoBehaviour {
    #region Attributes
    [HideInInspector]
    public HealthModule healthModule = null;
    [SerializeField]
    private GameObject bar = null;
    [SerializeField]
    private GameObject lifeBar = null;
    [SerializeField]
    private Sprite[] playerFaceSprites = null;
    #endregion

 

    void Awake() {

    }
    #region Awake methods
    #endregion



    private void Start() {
        InitHealthBar();
    }
    #region Start methods
    #endregion


    private void Update() {
        InitHealthBar();
    }


    #region Reusable methods
    private void InitHealthBar() {
        lifeBar.transform.localScale = new Vector2(healthModule.CurrentHealthPercentage, transform.localScale.y);
    }
    #endregion
}
