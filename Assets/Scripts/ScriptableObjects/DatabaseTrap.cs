using UnityEngine;
using System.Collections.Generic;

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
    [Header("WRAPPING OF SPRITE RENDERER PARAMETERS")]
    #region Sprite Renderer attributes and properties
    [SerializeField]
    [Tooltip("Sprite array from which a sprite will be randomly chosen and assigned to the trap")]
    private Sprite[] sprites = null;
    public Sprite SpriteRandom {
        get { return sprites[Random.Range(0, sprites.Length - 1)]; }
    }
    #endregion
    #region Methods
    public Sprite GetSprite(int _index) {
        return sprites[_index];
    }
    #endregion
}
