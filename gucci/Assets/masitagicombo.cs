using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.Shared.Game;
using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Game;
using Opsive.UltimateCharacterController.Traits;
using Opsive.UltimateCharacterController.Utility;


public class masitagicombo : MonoBehaviour
{
    [Tooltip("The delay until the damage is started to be applied.")]
    [SerializeField] protected float m_InitialDamageDelay = 0.5f;
    [Tooltip("The amount of damage to apply during each damage event.")]
    [SerializeField] protected float m_DamageAmount = 10;
    [Tooltip("The interval between damage events.")]
    [SerializeField] protected float m_DamageInterval = 0.2f;

    private Health m_Health;
    private Transform m_HealthTransform;
    private ScheduledEventBase m_ScheduledDamageEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    


    private void Damage()
    {
        m_Health.Damage(m_DamageAmount, m_HealthTransform.position + Random.insideUnitSphere, Vector3.zero, 0);

        // Apply the damage again if the object still has health remaining.
        //if (m_Health.Value > 0)
        //{
        //    m_ScheduledDamageEvent = Scheduler.Schedule(m_DamageInterval, Damage);
        //}
    }
      void OnTriggerStay(Collider other)
    {

        if (m_Health != null)
        {
            return;
        }

        // A main character collider is required.
        if (!MathUtility.InLayerMask(other.gameObject.layer, 1 << LayerManager.Character))
        {
            return;
        }

        // The object must be a character.
        var characterLocomotion = other.GetComponentInParent<UltimateCharacterLocomotion>();
        if (characterLocomotion == null)
        {
            return;
        }

        // With a health component.
        var health = characterLocomotion.GetComponent<Health>();
        if (health == null)
        {
            return;
        }

        m_Health = health;
        m_HealthTransform = health.transform;
        m_ScheduledDamageEvent = Scheduler.Schedule(m_InitialDamageDelay, Damage);
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
}
