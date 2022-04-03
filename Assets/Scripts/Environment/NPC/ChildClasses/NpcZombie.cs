public class NpcZombie : Npc {
    protected override void Start() {
        base.Start();

        AddListeners();
        phrase = randomDialogue ? databaseNPC.RandomPhrase : databaseNPC.GetPhrase((int)phrasesType);
    }
    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        mySpriteRenderer.sprite = databaseNPC.GetSprite((int)NpcSpritesType.OffDialogue);
    }


    private void AddListeners() {
        MessageManager.OnTurnOffVignette += ChangeSprite;
    }
    #endregion



    #region Events methods
    private void ChangeSprite() {
        mySpriteRenderer.sprite = databaseNPC.GetSprite((int)NpcSpritesType.OffDialogue);
    }
    #endregion



    private void OnDestroy() {
        RemoveListeners();
    }
    #region OnDestroy methods
    private void RemoveListeners() {
        MessageManager.OnTurnOffVignette -= ChangeSprite;
    } 
    #endregion
}