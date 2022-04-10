using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabaseHealth")]
public class DatabaseHealth : ScriptableObject {
    [Header("HEALTH DATA")]
    #region Attributes and properties
    //[SerializeField]
    //[Range(1f, 100f)]
    //[Tooltip("Maximum value of life")]
    [HideInInspector]
    public float maxHealth = 1f;
    //public float MaxHealth {
    //    get { return maxHealth; }
    //}


    //private float health;
    //public float Health {
    //    get { return health; }
    //    set {
    //        health = value > maxHealth ? health = maxHealth :
    //                 value < 0 ? health = 0 : health = value;
    //    }
    //}


    //public float CurrentHealthPercentage {
    //    get { return (health / MaxHealth); }
    //}
    #endregion
    #region Methods
    //public void LifeAssign() {
    //    health = maxHealth;
    //}
    //public void TakeDamage(float _damage) {
    //    Health -= _damage;
    //}
    //public void TakeHealth(float _health) {
    //    Health += _health;
    //}
    #endregion
}