using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image Healthbar;
    [SerializeField] private Text Healthtxt;
    [SerializeField] private Image Manabar;
    [SerializeField] private Text Manatxt;
    [SerializeField] private Image Staminabar;
    [SerializeField] private Text Staminatxt;

    public float Health = 200.0f;
    public float MaxHealth;

    private float maxHp;
    private float hpRegenTimer;

    [SerializeField] float hpRegenRate = 1.0f;

    public float Mana = 200.0f;
    public float Stamina = 100.0f;

    private float maxStamina = 100.0f;
    private float stamRegenTimer;
    
    public bool alive = true;
    //private Vector3 initPos;
    //private Transform myParent;

    private float maxMana;
    private float mpRegenTimer;

    [SerializeField] private float regenIntervalMana = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        mpRegenTimer = Time.deltaTime;
        hpRegenTimer = Time.deltaTime;
        stamRegenTimer = Time.deltaTime;

        maxHp = Health;
        maxMana = Mana;
        maxStamina = Stamina;
    }

    private void PlayerStillAlive()
    {
        if (Health <= 0.0f && alive == true)
        {
            alive = false;
            //Debug.Log("Wizard right now is = " + alive);
        }
        if (alive == true)
        {
            UpdateHealthBar();
            UpdateManaBar();
            UpdateStaminaBar();
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


            UpdateHealthBar();
            UpdateManaBar();
            UpdateStaminaBar();
        }
    }

    private void UpdateHealthBar()
    {
        float healthRatio = Health / maxHp;
        Healthbar.rectTransform.localScale = new Vector3(healthRatio, 1, 1);
        Healthtxt.text = (healthRatio * maxHp).ToString("0") + '/' + maxHp;


    }

    private void UpdateManaBar()
    {

        float manaRatio = Mana / maxMana;
        Manabar.rectTransform.localScale = new Vector3(manaRatio, 1, 1);
        Manatxt.text = (manaRatio * maxMana).ToString("0") + "/ " + maxMana;


    }

    private void UpdateStaminaBar()
    {
        float stamRatio = Stamina / maxStamina;
        Staminabar.rectTransform.localScale = new Vector3(stamRatio, 1, 1);
        Staminatxt.text = (stamRatio * maxStamina).ToString("0") + '/' + maxStamina;


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
            Stamina = Stamina + 5;
        }
        if (Stamina >= maxStamina)
        {
            Stamina = maxStamina;
        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerStillAlive();
    }
}
