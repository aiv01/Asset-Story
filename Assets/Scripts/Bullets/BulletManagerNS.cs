using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class BulletManagerNS : MonoBehaviour {
    #region Attributes
    public DatabaseBulletManager databaseBulletManager = null;
    private int numOfBullet = 3;
    public Bullet prefabBullet = null;

    public List<Bullet> myBullets = new List<Bullet>();
    #endregion


    public bool IsFree = false;


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
    public void GetBullet(Vector2 _startPosition, Vector2 _direction) { 
        for (int i = 0; i < myBullets.Count; i++) {
            if (!myBullets[i].gameObject.activeSelf) {
                myBullets[i].gameObject.transform.position = _startPosition;
                myBullets[i].direction = _direction;
                myBullets[i].gameObject.SetActive(true);
                break; 
            }
        }
    }
    #endregion
}
