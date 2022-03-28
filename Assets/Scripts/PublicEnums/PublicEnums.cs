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
    CharacterChoiceScene,
    GameScene,
    Last
}
#endregion
