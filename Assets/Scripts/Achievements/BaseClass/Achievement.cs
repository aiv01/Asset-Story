using UnityEngine;

[DisallowMultipleComponent]
public abstract class Achievement : MonoBehaviour {
    #region Private attributes
    private SpriteRenderer mySpirteRenderer = null;
    #endregion


    protected abstract void UnlockCondition();
}
