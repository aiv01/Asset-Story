using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseTrap")]
public class DatabaseTrap : ScriptableObject {
    [Header("TRAP DATA")]
    #region Attributes and properties
    [SerializeField]
    [Range(0.1f, 10f)]
    [Tooltip("Value that indicates the damage that the trap will do to the player")]
    private float damage = 0.1f;
    public float Damage {
        get { return damage; }
    }
    #endregion
}