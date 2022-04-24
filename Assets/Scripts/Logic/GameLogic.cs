using UnityEngine;

public class GameLogic : MonoBehaviour {
    public Enemy[] enemies;

    [HideInInspector]
    public HealthModule healthModule = null;

    [HideInInspector]
    public Transform playerPosition = null;

    [SerializeField]
    private TrapManager[] spikes = null;


    [SerializeField]
    private RecoveryPoint[] recoveryPoints = null;


    private Trap[] traps = null;

    public static GameLogic Instance {
        get;
        set;
    } = null;

    private void Start() {
        VariablesAssignement();
    }
    private void VariablesAssignement() {

        for (int i = 0; i < enemies.Length; i++) {
            enemies[i].playerTransform = playerPosition;
            enemies[i].playerHealth = healthModule;
        }

        for (int i = 0; i < recoveryPoints.Length; i++) {
            recoveryPoints[i].playerHealth = healthModule;
        }
        if (spikes != null) {
            for (int i = 0; i < spikes.Length; i++) {
                for (int j = 0; j < spikes[i].myTraps.Length; j++) {
                    spikes[i].myTraps[j].GetComponent<Trap>().playerHealth = healthModule;
                }
            }
        }

    }
}