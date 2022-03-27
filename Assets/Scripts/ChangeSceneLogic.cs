using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class ChangeSceneLogic : MonoBehaviour {
    #region Private enum
    //private enum SceneType : byte {
    //    StartScene,
    //    CharacterChoiceScene,
    //    GameScene,
    //    Last
    //}
    #endregion
    #region Enum variable
    private SceneType sceneType = SceneType.GameScene;
    #endregion
    #region Attributes
    private Button[] buttons = new Button[3];
    #endregion



    #region Public methods
    public void ChangeSceneWithShieldType() {
        PlayerPrefs.DeleteAll();
        Save.Instance.skillType = SkillType.Shield;

        SceneManager.LoadScene("SampleScene");
        Save.isNewGame = true;

    }
    public void ChangeSceneWithDashType() {
        PlayerPrefs.DeleteAll();
        Save.Instance.skillType = SkillType.Dash;

        SceneManager.LoadScene("SampleScene");
        Save.isNewGame = true;

    }


    public void Continue() {
        SceneManager.LoadScene("SampleScene");
        Save.isNewGame = false;
    }
    #endregion
}
