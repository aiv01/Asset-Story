using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseVignette")]
public class DatabaseVignette : ScriptableObject {
    [Header("VIGNETTE DATA")]
    #region Attributes and properties
    [SerializeField]
    [Range(1f, 10f)]
    [Tooltip("Time beyond which the vignette will go out")]
    private float reloadCounter = 1f;
    public float ReloadCounter {
        get { return reloadCounter; }
    }
    #endregion
}