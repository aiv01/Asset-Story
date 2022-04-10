using UnityEngine;

public class GameLogic : MonoBehaviour {
    //[SerializeField]
    //private BulletManager bulletManager = null;

    [SerializeField]
    private BulletManagerNS bulletManagerNS = null;

    [SerializeField]
    private BulletManagerNS bulletManagerNS_2 = null;

    /*[S*//*erializeField]*/
    public Enemy[] enemies;

    [HideInInspector]
    public HealthModule healthModule = null;

    [HideInInspector]
    public Transform playerPosition = null;

    [SerializeField]
    private TrapManager[] spikes = null;

    [SerializeField]
    private EnemyManager ghostyManager = null;

    [SerializeField]
    private RecoveryPoint[] recoveryPoints = null;


    //[SerializeField]
    //private State[] states = null;


    private Trap[] traps = null;


    private void Start() {
        VariablesAssignement();
    }
    private void VariablesAssignement() {
        for (int i = 0; i < bulletManagerNS.myBullets.Count; i++) {
            bulletManagerNS.myBullets[i].playerHealth = healthModule;
        }

        for (int i = 0; i < bulletManagerNS_2.myBullets.Count; i++) {
            bulletManagerNS_2.myBullets[i].playerHealth = healthModule;
        }

        for (int i = 0; i < enemies.Length; i++) {
            enemies[i].playerHealth = healthModule;
            enemies[i].playerTransform = playerPosition;
        }

        for (int i = 0; i < ghostyManager.myEnemies.Count; i++) {
            ghostyManager.myEnemies[i].playerHealth = healthModule;
        }

        for (int i = 0; i < recoveryPoints.Length; i++) {
            recoveryPoints[i].playerHealth = healthModule;
        }


        for (int i = 0; i < spikes.Length; i++) {
            for (int j = 0; j < spikes[i].myTraps.Length; j++) {
                spikes[i].myTraps[j].GetComponent<Trap>().playerHealth = healthModule;
            }
        }
        //for (int i = 0; i < states.Length; i++) {
        //    states[i].playerTransform = playerPosition;
        //}
       
        //for (int i = 0; i < ; i++) {

        //}
        //for (int i = 0; i < spikes.Length; i++) {
        //    for (int i = 0; i < spikes[i].gameObject.c; i++) {

        //    }
        //}
        //for (int i = 0; i < spikes.Length; i++) {
        //    spikes[i].playerHealth = healthModule;
        //}
    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha7)) {

            //Camera.main.
        }
    }
}
