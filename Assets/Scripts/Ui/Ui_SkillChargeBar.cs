using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_SkillChargeBar : MonoBehaviour {
    #region Private enum
    [SerializeField]
    private DatabasePlayer databasePlayer = null;

    [SerializeField]
    private GameObject skillChargeBar = null;


    //private float BarLimit {
    //    get { return BarLimit; }
    //    set {
    //        BarLimit = value > databasePlayer.ReloadSkillCounter ? 
    //                  databasePlayer.ReloadSkillCounter : value < 0 ? 0 : BarLimit;
    //    }
    //}

    private float CurrentCharge {
        get { return databasePlayer.skillCounter; }
    }
    #endregion 
    #region Enum variable
    #endregion
    #region Attributes
    #endregion
    #region Attributes and properties
    #endregion



    void Awake() {

    }
    #region Awake methods
    #endregion



    void Start() {


    }
    #region Start methods
    #endregion



    void Update() {
        SetSkillChargeBar();
    }
    #region Update methods
    private void SetSkillChargeBar() {
        skillChargeBar.transform.localScale = new Vector2(CurrentCharge * -1, skillChargeBar.transform.localScale.y);
    }
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
    #endregion 
}
