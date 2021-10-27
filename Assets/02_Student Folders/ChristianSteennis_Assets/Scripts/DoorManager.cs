using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Health), typeof(Actor))]
public class DoorManager : MonoBehaviour
{
    [System.Serializable]
    public struct RendererIndexData
    {
        public Renderer renderer;
        public int materialIndex;

        public RendererIndexData(Renderer renderer, int index)
        {
            this.renderer = renderer;
            this.materialIndex = index;
        }
    }

    [Header("Flash on hit")]
    [Tooltip("The material used for the body of the hoverbot")]
    public Material bodyMaterial;
    [Tooltip("The gradient representing the color of the flash on hit")]
    [GradientUsageAttribute(true)]
    public Gradient onHitBodyGradient;
    [Tooltip("The duration of the flash on hit")]
    public float flashOnHitDuration = 0.5f;

    [Header("Sounds")]
    [Tooltip("Sound played when recieving damages")]
    public AudioClip damageTick;

    public WeaponController doorDestroyer;
    public DisplayMessage message;
    public Objective objective;

    public UnityAction onDamaged;
    public UnityAction onDie;

    ActorsManager m_ActorsManager;
    Health m_Health;
    Actor m_Actor;
    Collider[] m_SelfColliders;
    GameFlowManager m_GameFlowManager;
    PlayerWeaponsManager m_weaponsManager;
    bool m_WasDamagedThisFrame;
    bool dead = false;

    void Start()
    {
        m_ActorsManager = FindObjectOfType<ActorsManager>();
        DebugUtility.HandleErrorIfNullFindObject<ActorsManager, SkeletonController>(m_ActorsManager, this);

        m_Health = GetComponent<Health>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, SkeletonController>(m_Health, this, gameObject);

        m_Actor = GetComponent<Actor>();
        DebugUtility.HandleErrorIfNullGetComponent<Actor, SkeletonController>(m_Actor, this, gameObject);

        m_SelfColliders = GetComponentsInChildren<Collider>();

        m_GameFlowManager = FindObjectOfType<GameFlowManager>();
        DebugUtility.HandleErrorIfNullFindObject<GameFlowManager, SkeletonController>(m_GameFlowManager, this);

        m_weaponsManager = FindObjectOfType<PlayerWeaponsManager>();

        // Subscribe to damage & death actions
        m_Health.onDie += OnDie;
        m_Health.onDamaged += OnDamaged;
        m_Health.invincible = true;
    }

    void Update()
    {
        m_WasDamagedThisFrame = false;
        if (m_weaponsManager.GetActiveWeapon().sourcePrefab == doorDestroyer.gameObject) {
            m_Health.invincible = false;
        }
    }

    void OnDamaged(float damage, GameObject damageSource)
    {
        // test if the damage source is the player
        if (damageSource && damageSource.GetComponent<PlayerCharacterController>())
        {
            if (onDamaged != null)
            {
                onDamaged.Invoke();
            }

            // play the damage tick sound
            if (damageTick && !m_WasDamagedThisFrame)
                AudioUtility.CreateSFX(damageTick, transform.position, AudioUtility.AudioGroups.DamageTick, 0f);

            m_WasDamagedThisFrame = true;
        }
    }

    void OnDie()
    {   
        dead = true;
        m_weaponsManager.RemoveWeapon(m_weaponsManager.GetActiveWeapon());
        if (onDie != null)
        {
            onDie.Invoke();
        }

        // this will call the OnDestroy function
        Destroy(gameObject, 0f);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<PlayerCharacterController>()) {
            message.enabled = true;
            objective.enabled = true;
        }
    }
}
