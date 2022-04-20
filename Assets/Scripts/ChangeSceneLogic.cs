using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class ChangeSceneLogic : MonoBehaviour {
    #region Enum variable
    private SceneType sceneType = SceneType.GameScene;
    #endregion
    #region Serialized attributes
    [SerializeField]
    private SceneType nextScene = SceneType.Last;
    #endregion


    #region Public methods
    public void ChangeSceneWithShieldType() {
        PlayerPrefs.DeleteAll();
        Save.Instance.skillType = SkillType.Shield;
        SceneManager.LoadScene(SceneType.Map1.ToString());
        Save.isNewGame = true;

    }
    public void ChangeSceneWithDashType() {
        PlayerPrefs.DeleteAll();
        Save.Instance.skillType = SkillType.Dash;
        SceneManager.LoadScene(SceneType.Map1.ToString());
        Save.isNewGame = true;

    }
    public void ChangeSceneWithInvincibilityType() {
        PlayerPrefs.DeleteAll();
        Save.Instance.skillType = SkillType.Invincibilty;
        SceneManager.LoadScene(SceneType.Map1.ToString());
        Save.isNewGame = true;

    }


    public void Continue() {
        SceneManager.LoadScene(Save.Instance.currentScene);
        Save.isNewGame = false;
    }


    public void ChangeSceneNextScene() {
        SceneManager.LoadScene(nextScene.ToString().ToLower());
    }


    public void ChangeSceneNullScene() {
        //SceneManager.LoadScene(SceneType.Null.ToString().ToLower());
        Application.Quit();
    }
    #endregion
}
