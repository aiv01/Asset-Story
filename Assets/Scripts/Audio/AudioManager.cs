using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
    #region Attributes
    [SerializeField]
    private AudioSource myAudioSource = null;

    [SerializeField]
    private AudioSource runAudioSource = null;

    [SerializeField]
    private AudioSource walkAudioSource = null;

    [SerializeField]
    private AudioClip myAudioClip = null;
    #endregion



    void Awake() {
        TakeTheReferences();
        VariablesAssignment();
    }
    #region Awake methods
    private void TakeTheReferences() {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void VariablesAssignment() {
        myAudioSource.clip = myAudioClip;
        myAudioSource.playOnAwake = true;
        myAudioSource.loop = true;
        myAudioSource.volume = 0.5f;
        myAudioSource.Play();

        //myAudioSource.playOnAwake = true;

        //walkAudioSource.loop = true;

    }
    #endregion


    private void Update() {
        //if (Movement.Instance.IsWalkiing) {
        //    walkAudioSource.Play();
        //}
        //else { 
        //    walkAudioSource.Stop();

        //}

        //if (Movement.Instance.IsRunning) {
        //    runAudioSource.Play();
        //}
        //else {
        //    runAudioSource.Stop();
        //}
    }
}