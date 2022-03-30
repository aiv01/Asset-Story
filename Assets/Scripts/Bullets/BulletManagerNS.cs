using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BulletManagerNS : MonoBehaviour {
    #region Attributes
    public DatabaseBulletManager databaseBulletManager = null;
    private int numOfBullet = 3;
    public SpitterBullet prefabBullet = null;

    private List<SpitterBullet> myBullets = new List<SpitterBullet>();
    #endregion
    #region Singleton
    //public static BulletManager Instance {
    //    get;
    //    private set;
    //} = null;
    #endregion

    //rivedibile
    public bool IsFree = false;

    private void Awake() {
        //SetSingleton();
    }
    #region Awake methods
    //private void SetSingleton() {
    //    Instance = this;
    //}
    #endregion



    private void Start() {
        for (int i = 0; i < databaseBulletManager.NumOfBullet; i++) {
            CreateBullet();
        }
    }
    #region Start methods
    private SpitterBullet CreateBullet() {
        SpitterBullet instance = Instantiate<SpitterBullet>(prefabBullet);
        instance.transform.SetParent(transform);
        instance.gameObject.SetActive(false);
        myBullets.Add(instance);
        return instance;
    }
    #endregion



    #region Public methods
    //public void GetBullet(Vector2 startPosition) {
    //    Debug.Log("SONO DENTRO");
    //    for (int i = 0; i < myBullets.Count; i++) {
    //        if (!myBullets[i].gameObject.activeSelf) {
    //            myBullets[i].gameObject.SetActive(true);

    //            return;
    //        }
    //    }
    //}

    public void GetBullet(Vector2 _startPosition) {
        //Debug.Log("SONO DENTRO");
        for (int i = 0; i < myBullets.Count; i++) {
            if (!myBullets[i].gameObject.activeSelf) {
                //rivedibile 
                IsFree = true;
                if (i > -1) {
                    IsFree = true;
                }

                myBullets[i].gameObject.transform.position = _startPosition;
                myBullets[i].gameObject.SetActive(true);
                break;
            }
            //rivedibile
            else {
                IsFree = false;
            }
        }
    }
    #endregion
}
