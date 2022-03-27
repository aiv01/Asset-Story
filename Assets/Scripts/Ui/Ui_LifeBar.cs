using UnityEngine;

[DisallowMultipleComponent]
public class Ui_LifeBar : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private DatabaseHealth databaseHealth = null;
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



    void Start() {
        InitHealthBar();
    }
    #region Start methods
    #endregion



    void Update() {

        InitHealthBar();
    }
    #region Update methods
    #endregion




    #region Reusable methods
    private void InitHealthBar() {
        lifeBar.transform.localScale = new Vector2(databaseHealth.CurrentHealthPercentage, transform.localScale.y);
    }
    #endregion
}
