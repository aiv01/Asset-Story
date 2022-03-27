using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseRecoveryPoint")]
public class DatabaseRecoveryPoint : ScriptableObject {
    [Header("RECOVERY POINT DATA")]
    #region Attributes and properties
    [SerializeField]
    [Range(0.05f, 100f)]
    [Tooltip("Value that will be added to the player's life")]
    private float lifeAmount = 0.05f;
    public float LifeAmount {
        get { return lifeAmount; }
    }


    public float TimedLifeAmount {
        get { return LifeAmount * Time.fixedDeltaTime; }
    }
    #endregion
    [Header("SPRITE RENDERER PARAMETERS")]
    #region Sprite Renderer attributes
    [SerializeField]
    [Tooltip("Sprites of the recovery point")]
    private Sprite[] sprites = new Sprite[(int)EnvironmentSpriteType.Last];


    public Sprite StartingSprite {
        get { return sprites[(int)EnvironmentSpriteType.Off]; }
    }
    #endregion
    #region Methods
    public Sprite GetSprite(int _index) {
        return sprites[_index];
    }
    #endregion
}