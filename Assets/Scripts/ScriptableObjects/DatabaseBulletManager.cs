using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseBulletManager")]
public class DatabaseBulletManager : ScriptableObject {
    [Header("DATA")]
    #region Attributes and properties
    [SerializeField]
    [Range(0, 15)]
    [Tooltip("Number of bullets in the pool")]
    private int numOfBullet = 0;
    public int NumOfBullet {
        get { return numOfBullet; }
        set { numOfBullet = value; }
    }


    [SerializeField]
    [Tooltip("Prefab that will be used for the creation of the bullets")]
    public Bullet prefabBullet = null;
    #endregion
}