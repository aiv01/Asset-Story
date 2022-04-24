using UnityEngine;
using UnityEngine.UI;

public class Ui_EnemyLifeBar : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private EnemyHealthModule ownerHealthModule = null;
    [SerializeField]
    private GameObject lifeBar = null;
    private Image image = null;
    #endregion
    #region Constant
    private const float LIFE_HALF = 0.5f;
    private const float LIFE_LOW = 0.3f;
    #endregion


    void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        image = lifeBar.GetComponent<Image>();
    }
    #endregion



    private void Start() {
        ChangeColor();
    }



    private void Update() {
        InitHealthBar();
        ChangeColor();

        if (lifeBar.transform.localScale.x <= 0f) {
            gameObject.SetActive(false);
        }
    }



    #region Reusable methods
    private void InitHealthBar() {
        lifeBar.transform.localScale = new Vector2(ownerHealthModule.CurrentHealthPercentage, transform.localScale.y);
    }


    private void ChangeColor() {
        image.color = Color.green;
        if (ownerHealthModule.CurrentHealthPercentage >= LIFE_LOW && ownerHealthModule.CurrentHealthPercentage <= LIFE_HALF) {
            image.color = Color.yellow;
        }
        else if (ownerHealthModule.CurrentHealthPercentage <= LIFE_LOW) {
            image.color = Color.red;
        }
    }
    #endregion
}