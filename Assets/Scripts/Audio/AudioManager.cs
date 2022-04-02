using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
    #region Attributes
    private AudioSource myAudioSource = null;

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
    }
    #endregion
}