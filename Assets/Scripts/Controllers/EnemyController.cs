using UnityEngine;

[DisallowMultipleComponent]
public class EnemyController : MonoBehaviour {
    [SerializeField]
    private GameObject[] enemies = new GameObject[0];

    [SerializeField]
    private State[] states = new State[0];



    private void Start() {
        AddStatesToEnemies();
    }
    private void AddStatesToEnemies() {
        for (int i = 0; i < enemies.Length; i++) {
            for (int j = 0; j < states.Length; j++) {
                enemies[i].AddComponent(states[j].GetType());
            }
        }
    }
}
