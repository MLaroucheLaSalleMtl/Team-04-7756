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

    private float timer;
    private float manaMultiplier;
    private float staminaMultiplier;

    private void Start()
    {
        manaMultiplier = 1f;
        staminaMultiplier = 5f;
    }

    private void Update()
    {
        timer = Time.deltaTime;
        if (currentManaPoints < maxManaPoints)
        {
            currentManaPoints += timer;
        }
        if(currentStaminaPoints < maxStaminaPoints)
        {
            currentStaminaPoints += timer * staminaMultiplier;
        }
    }

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

    public void UseMana(float mana)
    {
        currentManaPoints = Mathf.Clamp(currentManaPoints - mana, 0f, maxManaPoints);
    }

    public void UseStamina(float stamina)
    {
        currentStaminaPoints = Mathf.Clamp(currentStaminaPoints - stamina, 0f, maxStaminaPoints);
        currentManaPoints += timer * 2f;
    }

    //TODO Camera Locking to a target
    //TODO Cannot rotate during attack
    //TODO Impact animation
}
