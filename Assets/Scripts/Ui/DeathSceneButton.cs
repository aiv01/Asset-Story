using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneButton : MonoBehaviour {
    //#region Public methods
    public void Restart() {
        SceneManager.LoadScene(SceneType.PlayerSelectionScene.ToString());
    }

    public void Exit() { 
        SceneManager.LoadScene(SceneType.StartScene.ToString());
    }
    //#endregion
}