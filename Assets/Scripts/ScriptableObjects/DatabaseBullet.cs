using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseBullet")]
public class DatabaseBullet : ScriptableObject {
    [Header("DATA")]
    #region Enum variable
    [SerializeField]
    [Tooltip("Movement mode of the bullet that will be used to understand how to behave" +
             "with certain values ​​(ex: Time.deltaTime, Time.fixedDeltaTime)")]
    private MovementType movementType = MovementType.RigidbodyBased;
    #endregion
    #region Attributes and properties
    [SerializeField]
    [Range(10f, 200f)]
    [Tooltip("Scalar which will be multiplied to the velocity vector of the rigidbody")]
    private float speed = 10f;
    public float Speed {
        get {
            return movementType == MovementType.RigidbodyBased ||
                   movementType == MovementType.CharacterControllerBased ?
                   speed * Time.fixedDeltaTime : speed * Time.deltaTime;
        }
    }


    [SerializeField]
    [Tooltip("Sprite (bullet)")]
    private Sprite sprite = null;
    public Sprite Sprite {
        get { return sprite; }
    }


    //[HideInInspector]
    //public float lifeCounter = 0f;


    [SerializeField]
    [Range(1f, 15f)]
    [Tooltip("Life time of the bullet")]
    private float reloadLifeCounter = 0f;
    public float ReloadLifeCounter {
        get { return reloadLifeCounter; }
    }
    #endregion
    #region Methods
    //public void SetLifeCounter() {
    //    lifeCounter = reloadLifeCounter;
    //}
    #endregion
}
