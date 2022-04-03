#region Public enums
public enum MovementType : byte {
    TransformBased,
    RigidbodyBased,
    CharacterControllerBased
}


public enum PlatformMovementType : byte {
    UpDown,
    LeftRight,
    Last
}


public enum SkillType : byte {
    Shield,
    Dash,
    Invincibilty,
    Last
}


public enum EnemyType : byte {
    chomper,
    Spitter,
    Gunner,
    Last
}


public enum EnvironmentSpriteType : byte { 
    Off,
    On,
    Last
}


public enum CheckPointSwitch : byte { 
    On, 
    Off,
    Last
}


public enum DoorSpriteType : byte { 
    Deactivate,
    OnePieceActive,
    TwoPieceActive,
    Active,
    Last
}


public enum SceneType : byte {
    StartScene,
    PlayerSelectionScene,
    GameScene,
    MapBeta,
    Last
}


public enum NpcSpritesType : byte {
    OffDialogue,
    OnDialogue,
    Last
}


public enum PhrasesType : byte {
    Plot,
    Plot_2,
    Plot_3,
    Plot_4,
    Plot_5,
    Plot_6,
    Plot_7,
    Plot_8,
    Troll,
    Troll_2,
    Troll_3,
    Last
}


public enum AchievementType : byte { 
    ChomperKiller,
    SpitterKiller,
    GunnerKiller,
    LoverOfInformation,
    Immortal,
    Last
}
#endregion
