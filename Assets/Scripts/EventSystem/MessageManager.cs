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


    public delegate void OpenTheDoor();
    public static event OpenTheDoor OnOpenTheDoor;
    public static void CallOnOpenTheDoor() {
        OnOpenTheDoor?.Invoke();
    }


    public delegate void TakeTheHealth();
    public static event TakeTheHealth OnTakeTheHealth;
    public static void CallOnTakeTheHealth() {
        OnTakeTheHealth?.Invoke();
    }


    public delegate void ClickCustomButton();
    public static event ClickCustomButton OnClickCustomButton;
    public static void CallOnClickCustomButton() {
        OnClickCustomButton?.Invoke();
    }


    public delegate void ChomperHitted();
    public static event ChomperHitted OnChomperHitted;
    public static void CallOnChomperHitted() {
        OnChomperHitted?.Invoke();
    }


    public delegate void SpitterHitted();
    public static event SpitterHitted OnSpitterHitted;
    public static void CallOnSpitterHitted() {
        OnSpitterHitted?.Invoke();
    }


    public delegate void GunnerHitted();
    public static event GunnerHitted OnGunnerHitted;
    public static void CallOnGunnerHitted() {
        OnGunnerHitted?.Invoke();
    }


    public delegate void SpitterDead();
    public static event SpitterDead OnSpitterDead;
    public static void CallOnSpitterDead() {
        OnSpitterDead?.Invoke();
    }


    public delegate void ChomperDead();
    public static event ChomperDead OnChomperDead;
    public static void CallOnChomperDead() {
        OnChomperDead?.Invoke();
    }


    public delegate void GunnerDead();
    public static event GunnerDead OnGunnerDead;
    public static void CallOnGunnerDead() {
        OnGunnerDead?.Invoke();
    }



    public delegate void GunnerShoot();
    public static event GunnerShoot OnGunnerShoot;
    public static void CallOnGunnerShoot() {
        OnGunnerShoot?.Invoke();
    }


    public delegate void GunnerWalk();
    public static event GunnerWalk OnGunnerWalk;
    public static void CallOnGunnerWalk() {
        OnGunnerWalk?.Invoke();
    }


    public delegate void GunnerDash();
    public static event GunnerDash OnGunnerDash;
    public static void CallOnGunnerDash() {
        OnGunnerDash?.Invoke();
    }


    public delegate void PlayerShoot();
    public static event PlayerShoot OnPlayerShoot;
    public static void CallOnPlayerShoot() {
        OnPlayerShoot?.Invoke();
    }


    public delegate void PlayerHit();
    public static event PlayerHit OnPlayerHit;
    public static void CallOnPlayerHit() {
        OnPlayerHit?.Invoke();
    }


    public delegate void PlayerWalk();
    public static event PlayerWalk OnPlayerWalk;
    public static void CallOnPlayerWalk() {
        OnPlayerWalk?.Invoke();
    }
    #endregion
}