using UnityEngine;

[DisallowMultipleComponent]
public abstract class Achievement : MonoBehaviour {
    #region Enum varible
    protected AchievementType achievementType = AchievementType.Last;
    #endregion
    #region Private attributes
    private SpriteRenderer mySpirteRenderer = null;
    #endregion



    private void Awake() {
        TakeTheReferences();
    }
    #region Awake methods
    private void TakeTheReferences() {
    }
    #endregion



    protected virtual void Start() {
        VariablesAssignment();
    }
    #region Start methods
    protected virtual void VariablesAssignment() {
        achievementType = AchievementType.Last;
        gameObject.SetActive(false);
    } 
    #endregion



    protected abstract bool UnlockCondition();
}
