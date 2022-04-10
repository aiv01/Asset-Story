using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseDamage")]
public class DatabaseDamage : ScriptableObject {
    public float bulletDamage = 0f;
    public float meleeDamage = 0f;
    public float contactDamage = 0f; 
    private float timedDamage = 0f;
    public float TimedDamage {
        get { return timedDamage * Time.fixedDeltaTime; }
    }
}