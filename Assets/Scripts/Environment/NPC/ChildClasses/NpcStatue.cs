public class NpcStatue : Npc {
    protected override void Start() {
        base.Start();

        phrase = randomDialogue ? databaseNPC.RandomPhrase : databaseNPC.GetPhrase((int)phrasesType);
    }
    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();

        mySpriteRenderer.sprite = databaseNPC.RandomSprite;
    } 
    #endregion
}