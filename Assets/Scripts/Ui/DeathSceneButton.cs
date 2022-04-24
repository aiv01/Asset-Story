using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneButton : MonoBehaviour {
    public void Restart() {
        SceneManager.LoadScene(SceneType.PlayerSelectionScene.ToString());
    }

    public void Exit() {
        Application.Quit();
    }
}