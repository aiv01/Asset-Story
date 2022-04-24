using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class EnemyManager : MonoBehaviour {
    [SerializeField]
    private Enemy owner = null;

    public List<Enemy> myEnemies = new List<Enemy>();
    [SerializeField]
    public Enemy enemyPrefab = null;

    [SerializeField]
    private int numOfEnemies = 5;

    #region Singleton
    public static EnemyManager Instance {
        get;
        private set;
    } = null; 
    #endregion



    private void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
        Instance = this;
    } 
    #endregion



    private void Start() {
        VariablesAssignment();
    }
    #region Start methods
    private void VariablesAssignment() {
        for (int i = 0; i < numOfEnemies; i++) {
            myEnemies[i] = CreateEnemy();
        }

        for (int i = 0; i < myEnemies.Count; i++) {
            myEnemies[i].playerTransform = owner.playerTransform;
            myEnemies[i].playerHealth = owner.playerHealth;
        }
    }
    private Enemy CreateEnemy() {
        Enemy instance = Instantiate<Enemy>(enemyPrefab);
        instance.transform.SetParent(transform);
        instance.gameObject.SetActive(false);
        myEnemies.Add(instance);
        return instance;
    }
    #endregion



    #region Public methods
    public void GetEnemy(Vector2 _startPosition) {
        for (int i = 0; i < myEnemies.Count; i++) {
            if (!myEnemies[i].gameObject.activeSelf) {
                myEnemies[i].gameObject.transform.position = _startPosition;
                myEnemies[i].gameObject.SetActive(true);
                break;
            }
        }
    } 
    #endregion
}