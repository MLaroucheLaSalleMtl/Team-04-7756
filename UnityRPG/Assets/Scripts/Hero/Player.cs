using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    //[SerializeField] private float maxHealthPoints = 100f;
    //[SerializeField] private float currentHealthPoints = 100f;
    //[SerializeField] private float maxManaPoints = 100f;
   // private float currentManaPoints;
   // [SerializeField] private float staminaPoints = 100f;
  //  private float currentStaminaPoints;

 

    public float Health = 200.0f;
    public float Mana = 200.0f;
    public float Stamina = 100.0f;

    public float maxStamina = 100.0f;
    private float stamRegenTimer;

    public float MaxHealth;
    public bool alive = true;

    public float maxHp;
    private float hpRegenTimer;

    public float maxMana;
    private float mpRegenTimer;
    public bool gameover = false;
   // private gamemanager gm;

    public float regenIntervalMana = 0.5f;
    public float hpRegenRate = 1.0f;

   // private Animator m_Aminator;

    void Start()
    {
        mpRegenTimer = Time.deltaTime;
        hpRegenTimer = Time.deltaTime;
        stamRegenTimer = Time.deltaTime;

        maxHp = Health;
        maxMana = Mana;
    }

    void Update()
    {
        PlayerStillAlive();

    }

    private void PlayerStillAlive()
    {
        if (Health <= 0.0f && alive == true)
        {
            alive = false;
            Die();
            //Debug.Log("Wizard right now is = " + alive);
        }
        if (alive == true)
        {
            //UpdateHealthBar();
            //UpdateManaBar();
            //UpdateStaminaBar();
            mpRegenTimer += Time.deltaTime;
            hpRegenTimer += Time.deltaTime;
            stamRegenTimer += Time.deltaTime;

            if (Mana < maxMana)
            {
                if (mpRegenTimer > regenIntervalMana)//Regen when mana less than max.
                {
                    ManaRegen();
                }
            }

            if (Health < maxHp)
            {
                if (hpRegenTimer > hpRegenRate)//Regen when hp less than max.
                {
                    HealthRegen();
                }
            }
            if (Stamina < maxStamina)
            {
                if (stamRegenTimer > 1.0f)//Regen stamina when less than max.
                {
                    StaminaRegen();
                }
            }

        }
    }

  

    private void Die()
    {
        if (alive == false)
        {
            Health = 0.0f;
            Mana = 0.0f;
            Stamina = 0.0f;

            //finalscore = totalTime;
            //totalTime = 0;
            // TimeSpenttxt.text = "Time stayed alive : " + totalTime + " Sec";
            // currTimeText.text = "Time stayed alive : " + totalTime + " Sec";


            //UpdateHealthBar();
           // UpdateManaBar();
           // UpdateStaminaBar();
        }
    }


    private void HealthRegen()
    {
        hpRegenTimer = 0.0f;
        if (Health < maxHp && alive)
        {
            Health = Health + (maxHp / 100);
        }
        if (Health >= maxHp)
        {
            Health = maxHp;
        }

    }

    private void ManaRegen()
    {
        mpRegenTimer = 0.0f;

        if (Mana < maxMana)
        {
            Mana = Mana + (maxMana / 50);
        }
        if (Mana >= maxMana)
        {
            Mana = maxMana;
        }

    }

    private void StaminaRegen()
    {
        stamRegenTimer = 0.0f;
        if (Stamina < maxStamina)
        {
            Stamina = Stamina + 15;
        }
        if (Stamina >= maxStamina)
        {
            Stamina = maxStamina;
        }

    }

    /*
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
    */


    public void TakeDamage(float damage)
    {
        Health = Mathf.Clamp(Health - damage, 0f, maxHp);
        //currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);
        //Debug.Log("Take Damage : " + damage);
        Debug.Log("Current HP : " + Health);
    }

    //TODO Camera Locking to a target
    //TODO Cannot rotate during attack
    //TODO Impact animation
}
