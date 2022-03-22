using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabasePlatform")]
public class DatabasePlatform : ScriptableObject {
    [Header("PLATFORM DATA")]
    #region Enum variable
    [SerializeField]
    [Tooltip("Type of platform movement")]
    private PlatformMovementType movementType = PlatformMovementType.LeftRight;
    public PlatformMovementType MovementType {
        get { return movementType; }
    }
    #endregion
    #region Attributes
    [SerializeField]
    [Range(0f, 10f)]
    [Tooltip("Platform speed")]
    private float speed = 0f;
    public float Speed {
        get { return speed; }
    }


    [SerializeField]
    [Range(0f, 10f)]
    [Tooltip("Space traveled by the platform")]
    private float distance = 0f;
    public float Distance {
        get { return distance; }
    }


    [SerializeField]
    [Range(0f, 10f)]
    [Tooltip("Offset that acts as a multiplier of the sine of time")]
    private float sinMultiplier = 0f;
    public float SinMultiplier {
        get { return sinMultiplier; }
    }
    #endregion
}