using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealthPoints = 100f;
    [SerializeField] private float currentHealthPoints = 100f;

    [SerializeField] private float maxManaPoints = 100f;
    [SerializeField] private float currentManaPoints = 100f;

    [SerializeField] private float maxStaminaPoints = 100f;
    [SerializeField] private float currentStaminaPoints = 100f;

    private Animator m_Aminator;
    
    public float healthAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }
    }

    public float manaAsPercentage
    {
        get
        {
            return currentManaPoints / maxManaPoints;
        }
    }

    public float staminaAsPercentage
    {
        get
        {
            return currentStaminaPoints / maxStaminaPoints;
        }
    }

    public void TakeDamage(float damage)
    {
        //Health = Mathf.Clamp(Health - damage, 0f, Health);
        currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);
    }

    public void UseStamina(float stamina)
    {
        currentStaminaPoints = Mathf.Clamp(currentStaminaPoints - stamina, 0f, maxStaminaPoints);
    }

    //TODO Camera Locking to a target
    //TODO Cannot rotate during attack
    //TODO Impact animation
}
