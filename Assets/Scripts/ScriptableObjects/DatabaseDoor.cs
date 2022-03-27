using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseDoor")]
public class DatabaseDoor : ScriptableObject {
    [Header("DOOR DATA")]
    #region Attributes and properties
    [SerializeField]
    [Range(1, 10)]
    [Tooltip("Number of keys needed to open the door")]
    private int keysNeeded = 1;
    public int KeysNeeded {
        get { return keysNeeded; }
    }


    [SerializeField]
    [Range(1f, 150f)]
    [Tooltip("Door opening speed")]
    private float openingSpeed = 1f;
    public float OpeningSpeed {
        get { return openingSpeed * Time.deltaTime; }
    }


    [SerializeField]
    [Range(-5f, 5f)]
    [Tooltip("Value beyond which the door will be deactivated")]
    private float deactivationOffset = -5f;
    public float DeactivationOffset {
        get { return deactivationOffset; }
    }
    #endregion
    [Header("SPRITE RENDERER PARAMETERS")]
    #region Sprite Renderer attributes and properties
    [SerializeField]
    [Tooltip("Door sprites")]
    private Sprite[] sprites = new Sprite[(int)DoorSpriteType.Last];


    public Sprite StartingSprite {
        get { return sprites[(int)DoorSpriteType.Deactivate]; }
    }
    #endregion
    #region Methods
    public Sprite GetSprite(int _index) {
        return sprites[_index];
    }
    #endregion
}
