using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_EnemyLifeBar : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private EnemyHealthModule ownerHealthModule = null;
    [SerializeField]
    private GameObject bar = null;
    [SerializeField]
    private GameObject lifeBar = null;
    [SerializeField]
    private SpriteRenderer enemyFace = null;
    [SerializeField]
    private Sprite[] faceSprites = null;

    private Gunner enemy = null;
    #endregion
    #region Constant
    private const float LIFE_HALF = 0.5f;
    private const float LIFE_LOW = 0.3f;
    #endregion


    void Awake() {
        enemy = GetComponent<Gunner>();
    }
    #region Awake methods
    #endregion



    void Start() {
        //InitHealthBar();
        ChangeColor();
    }
    #region Start methods
    #endregion



    void Update() {

        InitHealthBar();
        ChangeFace();
        ChangeColor();
    }
    #region Update methods
    #endregion




    #region Reusable methods
    private void InitHealthBar() {
        lifeBar.transform.localScale = new Vector2(ownerHealthModule.CurrentHealthPercentage, transform.localScale.y);
    }


    private void ChangeColor() {
        lifeBar.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        if (ownerHealthModule.CurrentHealthPercentage >= LIFE_LOW && ownerHealthModule.CurrentHealthPercentage <= LIFE_HALF) {
            lifeBar.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        }
        else if (/*ownerHealthModule.CurrentHealthPercentage <= LIFE_HALF*/
                ownerHealthModule.CurrentHealthPercentage <= LIFE_LOW) {
            lifeBar.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }

    private void ChangeFace() {
        //if (enemy.IsConfuse) {
        //    enemyFace.color = Color.red;
        //}
        //else {
        //    enemyFace.color = Color.white;
        //}
    }
    #endregion
}
