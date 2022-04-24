using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GhostyManager : MonoBehaviour {
    [SerializeField]
    private Ghosty[] ghosties = null;



    private void Awake() {
        
    }



    private void Start() {
        VariablesAssignment();
    }
    private void VariablesAssignment() {
        for (int i = 0; i < ghosties.Length; i++) {
            ghosties[i].playerHealth = Movement.Instance.myHealtModule;
            ghosties[i].playerTransform = Movement.Instance.transform;
        }
    }

    private void Update() {
        
    }
}