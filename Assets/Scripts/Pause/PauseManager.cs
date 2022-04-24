using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class PauseManager : MonoBehaviour {
    [SerializeField] 
    private GameObject pausePanel;
    [SerializeField] 
    private AudioSource source;
    [SerializeField] 
    private AudioClip[] myClips = new AudioClip[2];
    [SerializeField] 
    private KeyCode pauseButton;
    private AudioSource mySource;
    private bool isPaused;
    [SerializeField]
    private DatabaseInput databaseInput = null;


    private void Awake() {
        pausePanel.SetActive(false);
        isPaused = false;
        TakeTheReference();
    }
    #region AwakeMethods
    private void TakeTheReference() {
        mySource = GetComponent<AudioSource>();
    }
    #endregion



    private void Update() {
        if (!HealthModule.IsDead) {
            GoToPause();
        }
    }
    #region UpdateMethods
    private void GoToPause() {
        if (databaseInput.Player.GetButtonDown
            (databaseInput.PauseButton)) {
            isPaused = true;
            if (isPaused) {
                mySource.PlayOneShot(myClips[0]);
                Time.timeScale = 0;
                pausePanel.SetActive(isPaused);
                source.Pause();
            }
            else {
                mySource.PlayOneShot(myClips[1]);
                Time.timeScale = 1;
                pausePanel.SetActive(isPaused);
                source.Play();
            }
        }
    }
    #endregion



    #region Public methods
    public void Resume() {
        isPaused = false;
        mySource.PlayOneShot(myClips[1]);
        Time.timeScale = 1;
        pausePanel.SetActive(isPaused);
        source.Play();
    }
    public void Exit() {
        Application.Quit();
    }
    #endregion
}
