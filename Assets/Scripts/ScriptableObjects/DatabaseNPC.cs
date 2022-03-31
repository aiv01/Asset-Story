using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseNPC")]
public class DatabaseNPC : ScriptableObject {
    [Header("NPC DATAs")]
    #region Attributes and properties
    [SerializeField]
    [Tooltip("Phrases of the NPCs")]
    private string[] npcsPhrases = new string[(int)PhrasesType.Last];


    public string RandomPhrase {
        get { return npcsPhrases[Random.Range(0, npcsPhrases.Length)]; }
    }
    #endregion
    [Header("SPRITE RENDERER PARAMETERS")]
    #region Sprite Renderer parameters
    [SerializeField]
    [Tooltip("Sprites of the NPC")]
    private Sprite[] sprites = new Sprite[(int)NpcSpritesType.Last];


    public Sprite RandomSprite {
        get { return sprites[Random.Range(0, sprites.Length)]; }
    }
    #endregion
    #region Methods
    public string GetPhrase(int _index) {
        return npcsPhrases[_index];
    }

    public Sprite GetSprite(int _index) {
        return sprites[_index];
    }
    #endregion
}