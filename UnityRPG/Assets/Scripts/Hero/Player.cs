using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealthPoints = 100f;
    [SerializeField] private float currentHealthPoints = 100f;
    [SerializeField] private float maxManaPoints = 100f;
    private float currentManaPoints;
    [SerializeField] private float staminaPoints = 100f;
    private float currentStaminaPoints;

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
            return currentManaPoints / maxHealthPoints;
        }
    }

    public float staminaAsPercentage
    {
        get
        {
            return currentStaminaPoints / maxHealthPoints;
        }
    }

    public void TakeDamage(float damage)
    {
        //Health = Mathf.Clamp(Health - damage, 0f, Health);
        currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);
        //Debug.Log("Take Damage : " + damage);
        //Debug.Log("Current HP : " + currentHealthPoints);
    }

    //TODO Camera Locking to a target
    //TODO Cannot rotate during attack
    //TODO Impact animation
}
