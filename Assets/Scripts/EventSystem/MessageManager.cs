public static class MessageManager {
    #region Events
    public delegate void TakeTheKey();
    public static event TakeTheKey OnTakeTheKey;
    public static void CallOnTakeTheKey() {
        OnTakeTheKey?.Invoke();
    }


    public delegate void TouchedTheCheckPoint();
    public static event TouchedTheCheckPoint OnTouchedTheCheckPoint;
    public static void CallOnTouchedTheCheckPoint() {
        OnTouchedTheCheckPoint?.Invoke();
    }


    public delegate void ChangeScene();
    public static event ChangeScene OnChangeScene;
    public static void CallOnChangeScene() {
        OnChangeScene?.Invoke();
    }


    public delegate void TouchedTheTrap();
    public static event TouchedTheTrap OnTouchedTheTrap;
    public static void CallOnTouchedTheTrap() {
        OnTouchedTheTrap?.Invoke();
    }


    public delegate int KeysRecovered();
    public static event KeysRecovered OnKeysRecovered;
    public static void CallOnKeysRecovered() {
        OnKeysRecovered?.Invoke();
    }


    public delegate void NewGame();
    public static event NewGame OnNewGame;
    public static void CallOnNewGame() {
        OnNewGame?.Invoke();
    }


    public delegate void ChomperColllision();
    public static event ChomperColllision OnChomperCollision;
    public static void CallOnChomperCollision() {
        OnChomperCollision?.Invoke();
    }



    public delegate void NpcInteraction();
    public static event NpcInteraction OnNpcInteraction;
    public static void CallOnNpcInteraction() {
        OnNpcInteraction?.Invoke();
    }


    public delegate void TurnOffVignette();
    public static event TurnOffVignette OnTurnOffVignette;
    public static void CallOnTurnOffVignette() {
        OnTurnOffVignette?.Invoke();
    }


    public delegate void EscDialogue();
    public static event EscDialogue OnEscDialogue;
    public static void CallOnEscDialogue() {
        OnEscDialogue?.Invoke();
    }
    #endregion
}
