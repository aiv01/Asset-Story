using UnityEngine;

[CreateAssetMenu(menuName = "Creates Scriptable Object/DatabasePlayer")]
public class DatabasePlayer : ScriptableObject {
    [Header("DATA")]
    #region Enum variable
    [SerializeField]
    [Tooltip("Movement mode of the player that will be used to understand how to behave" +
             "with certain values ​​(ex: Time.deltaTime, Time.fixedDeltaTime)")]
    private MovementType movementType = MovementType.RigidbodyBased;
    #endregion
    #region Attributes and properties
    [SerializeField]
    [Range(15f, 150f)]
    [Tooltip("Scalar which will be multiplied to the velocity vector of the rigidbody")]
    private float speed = 15f;
    public float Speed {
        get {
            return movementType == MovementType.RigidbodyBased ||
                   movementType == MovementType.CharacterControllerBased ?
                   (speed * Time.fixedDeltaTime) * RunMultiplier : 
                   (speed * Time.deltaTime) * RunMultiplier;
        }
    }


    [SerializeField]
    [Range(1f, 10f)]
    [Tooltip("Multiplier that will be multiplied at speed when the player is in a running state")]
    private float runMultiplier = 1f;
    private float RunMultiplier {
        get { return run ? runMultiplier : 1f; }
    }


    [HideInInspector]
    public bool run = false;


    [SerializeField]
    [Range(0f, 250f)]
    [Tooltip("Value that will determine the strength of the impulse that will be assigned to the jump")]
    private float jumpForce = 0f;
    public float JumpForce {
        get { return jumpForce; }
    }
    #endregion
    [Header("WRAPPING OF SPRITE RENDERER PARAMETERS")]
    #region Sprite Renderer attributes and properties
    [SerializeField]
    [Tooltip("Starting sprite (player idle)")]
    private Sprite startingSprite = null;
    public Sprite StartingSprite {
        get { return startingSprite; }
    }
    #endregion
    [Header("WRAPPING OF ANIMATOR PARAMETERS")]
    #region Animator attributes and properties
    [SerializeField]
    [Range(1f, 200f)]
    [Tooltip("Value that will be divided by the physical speed to obtain the animation speed")]
    private float speedAnimationDivider = 1f;
    public float SpeedAnimation {
        get {
            return speed / speedAnimationDivider;
        }
    } 
    #endregion
    [Header("WRAPPING OF RIGIDBODY PARAMETERS")]
    #region Rigidbody attributes and properties
    [SerializeField]
    [Tooltip("Type of rigidbody")]
    private RigidbodyType2D rigidbodyType = RigidbodyType2D.Dynamic;
    public RigidbodyType2D RigidbodyType {
        get { return rigidbodyType; }
    }


    [SerializeField]
    [Tooltip("Physical material")]
    private PhysicsMaterial2D physicMaterial = null;
    public PhysicsMaterial2D PhysicMaterial {
        get { return physicMaterial; }
    }


    [SerializeField]
    [Range(1f, 100f)]
    [Tooltip("Mass of the rigidbody")]
    private float mass = 1f;
    public float Mass {
        get { return mass; }
    }


    [SerializeField]
    [Range(0f, 10f)]
    [Tooltip("Linear Drag")]
    private float linearDrag = 0f;
    public float LinearDrag {
        get { return linearDrag; }
    }


    [SerializeField]
    [Range(0.05f, 10f)]
    [Tooltip("Angular Drag")]
    private float angularDrag = 0.05f;
    public float AngularDrag {
        get { return angularDrag; }
    }


    [SerializeField]
    [Range(0f, 100f)]
    [Tooltip("How much gravity affects this body")]
    private float gravityScale = 1f;
    public float GravityScale {
        get { return gravityScale; }
    }


    [SerializeField]
    [Tooltip("Rigidbody constraints")]
    private RigidbodyConstraints2D rigidbodyConstraints = RigidbodyConstraints2D.None;
    public RigidbodyConstraints2D RigidbodyConstraints {
        get { return rigidbodyConstraints; }
    }
    #endregion
    [Header("WRAPPING OF HEAD COLLIDER (BOX COLLIDER 2D) PARAMETERS")]
    #region Head collider attributes and properties
    [SerializeField]
    [Tooltip("Collider material")]
    private PhysicsMaterial2D headPhysicsMaterial = null;
    public PhysicsMaterial2D HeadPhysicsMaterial {
        get { return headPhysicsMaterial; }
    }


    [SerializeField]
    [Tooltip("If the collider is trigger")]
    private bool headIsTrigger = false;
    public bool HeadIsTrigger {
        get { return headIsTrigger; }
    }


    [SerializeField]
    [Tooltip("If it works with an effector")]
    private bool headUsedByEffector = false;
    public bool HeadUsedByEffector {
        get { return headUsedByEffector; }
    }


    [SerializeField]
    [Tooltip("If it works with other colliders")]
    private bool headUsedByComposite = false;
    public bool HeadUsedByComposite {
        get { return headUsedByComposite; }
    }


    [SerializeField]
    [Tooltip("Fits the Spriterenderer's tiling properties")]
    private bool headAutoTiling = false;
    public bool HeadAutoTiling {
        get { return headAutoTiling; }
    }


    [SerializeField]
    [Range(0f, 0.3f)]
    [Tooltip("The radius of the edge(s)")]
    private float headEdgeRadius = 0.05f;
    public float HeadEdgeRadius {
        get { return headEdgeRadius; }
    }
    #endregion
    [Header("WRAPPING OF BODY COLLIDER (CAPSULE COLLIDER 2D) PARAMETERS")]
    #region Body collider attributes and properties
    [SerializeField]
    [Tooltip("Collider material")]
    private PhysicsMaterial2D bodyPhysicsMaterial = null;
    public PhysicsMaterial2D BodyPhysicsMaterial {
        get { return bodyPhysicsMaterial; }
    }


    [SerializeField]
    [Tooltip("If the collider is trigger")]
    private bool bodyIsTrigger = false;
    public bool BodyIsTrigger {
        get { return bodyIsTrigger; }
    }


    [SerializeField]
    [Tooltip("If it works with an effector")]
    private bool bodyUsedByEffector = false;
    public bool BodyUsedByEffector {
        get { return bodyUsedByEffector; }
    }


    [SerializeField]
    [Tooltip("If it works with other colliders")]
    private bool bodyUsedByComposite = false;
    public bool BodyUsedByComposite {
        get { return bodyUsedByComposite; }
    }


    [SerializeField]
    [Tooltip("The direction of Capsule collider")]
    private CapsuleDirection2D capsuleDirection = CapsuleDirection2D.Vertical;
    public CapsuleDirection2D CapsuleDirection {
        get { return capsuleDirection; }
    }
    #endregion
    #region Methods
    public Vector2 Gravity(float _gravity) {
        return _gravity * Vector2.up;
    }
    #endregion
}