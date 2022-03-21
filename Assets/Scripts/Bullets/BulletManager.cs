using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BulletManager : MonoBehaviour {
    #region Attributes
    public DatabaseBulletManager databaseBulletManager = null;
    private int numOfBullet = 3;
    public Bullet prefabBullet = null;

    private List<Bullet> myBullets = new List<Bullet>();
    #endregion
    #region Singleton
    public static BulletManager Instance {
        get;
        private set;
    } = null;
    #endregion

    //rivedibile
    public bool IsFree = false;

    private void Awake() {
        SetSingleton();
    }
    #region Awake methods
    private void SetSingleton() {
        Instance = this;
    }
    #endregion



    private void Start() {
        for (int i = 0; i < databaseBulletManager.NumOfBullet; i++) {
            CreateBullet();
        }
    }
    #region Start methods
    private Bullet CreateBullet() {
        Bullet instance = Instantiate<Bullet>(prefabBullet);
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
        Debug.Log("SONO DENTRO");
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
