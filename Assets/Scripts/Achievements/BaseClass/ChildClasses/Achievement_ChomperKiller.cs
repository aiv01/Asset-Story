public class Achievement_ChomperKiller : Achievement {
    private int unlockNumber = 3;


    protected override void VariablesAssignment() {
        base.VariablesAssignment();
    }


    private void Update() {
        if (UnlockCondition()) {
            gameObject.SetActive(true);
        }
    }
    protected override bool UnlockCondition() {
        return Ui_Bestiary.numOfChomperKilled == unlockNumber;
    }
}
