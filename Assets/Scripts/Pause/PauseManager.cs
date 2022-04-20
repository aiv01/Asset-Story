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

    //[SerializeField]
    //private GameObject resumeButton = null;



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
        //if (isPaused) {
        //    mySource.PlayOneShot(myClips[0]);
        //    Time.timeScale = 0;
        //    pausePanel.SetActive(isPaused);
        //    source.Pause();
        //}
        //else {
        //    mySource.PlayOneShot(myClips[1]);
        //    Time.timeScale = 1;
        //    pausePanel.SetActive(isPaused);
        //    source.Play();
        //}

        //if (Input.GetKeyDown(KeyCode.I)) {
        //    Time.timeScale = 0;
        //}
        Debug.Log($"ISPAUSED VALUE {isPaused}");

      
        Debug.Log($"TIMESCALE VALUE {  Time.timeScale}");

    }
    #region UpdateMethods
    private void GoToPause() {
        if (Input.GetKeyDown(pauseButton)) {
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
        SceneManager.LoadScene(SceneType.StartScene.ToString());
    }
    #endregion
}
