using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    Player player = null;

    // Start is called before the first frame update
    //[SerializeField] private Image healthBar;
    private Image healthBar;
    private Image manaBar;
    private Image staminaBar;


    [SerializeField] private Player Maria;
    [SerializeField] private Image Manabar;
    [SerializeField] private Image Healthbar;
    [SerializeField] private Text Manatxt;
    [SerializeField] private Image Staminabar;
    [SerializeField] private Text Staminatxt;
    [SerializeField] private Text Healthtxt;

    void Start()
    {
        // player = GetComponent<Player>();

        // healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        // manaBar = GameObject.Find("ManaBar").GetComponent<Image>();
        // staminaBar = GameObject.Find("StaminaBar").GetComponent<Image>();

        // healthBar.fillAmount = 1f;
        //manaBar.fillAmount = 1f;
        //staminaBar.fillAmount = 1f;


        Maria = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        UpdateManaBar();
        UpdateStaminaBar();
       // healthBar.fillAmount = player.healthAsPercentage;
       // manaBar.fillAmount = player.manaAsPercentage;
       // staminaBar.fillAmount = player.staminaAsPercentage;
        
    }

    private void UpdateHealthBar()
    {
        float healthRatio = Maria.Health / Maria.maxHp;
        Healthbar.rectTransform.localScale = new Vector3(healthRatio, 1, 1);
        Healthtxt.text = (healthRatio * Maria.maxHp).ToString("0") + '/' + Maria.maxHp;
    }

    private void UpdateManaBar()
    {
        float manaRatio = Maria.Mana / Maria.maxMana;
        Manabar.rectTransform.localScale = new Vector3(manaRatio, 1, 1);
        Manatxt.text = (manaRatio * Maria.maxMana).ToString("0") + "/ " + Maria.maxMana;
    }

    private void UpdateStaminaBar()
    {
        float stamRatio = Maria.Stamina / Maria.maxStamina;
        Staminabar.rectTransform.localScale = new Vector3(stamRatio, 1, 1);
        Staminatxt.text = (stamRatio * Maria.maxStamina).ToString("0") + '/' + Maria.maxStamina;
    }
}
