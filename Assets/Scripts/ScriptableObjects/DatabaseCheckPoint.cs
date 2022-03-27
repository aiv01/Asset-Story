using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseCheckPoint")]
public class DatabaseCheckPoint : ScriptableObject {
    [Header("SPRITE RENDERER PARAMETERS")]
    #region Sprite Renderer attributes and properties
    [SerializeField]
    [Tooltip("Sprites of the checkpoint")]
    private Sprite[] sprites = new Sprite[(int)EnvironmentSpriteType.Last];


    public Sprite StartingSprite {
        get { return sprites[(int)EnvironmentSpriteType.Off]; }
    }
    #endregion
    #region Public methods
    public Sprite GetSprite(int _index) {
        return sprites[_index];
    }
    #endregion
}