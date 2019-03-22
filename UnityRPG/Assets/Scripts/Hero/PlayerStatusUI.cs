using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    Player player = null;

    // Start is called before the first frame update
    //[SerializeField] private Image healthBar;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;
    [SerializeField] private Image staminaBar;

    void Start()
    {
        player = GetComponent<Player>();

        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        manaBar = GameObject.Find("ManaBar").GetComponent<Image>();
        staminaBar = GameObject.Find("StaminaBar").GetComponent<Image>();

        healthBar.fillAmount = 1f;
        manaBar.fillAmount = 1f;
        staminaBar.fillAmount = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = player.healthAsPercentage;
        manaBar.fillAmount = player.manaAsPercentage;
        staminaBar.fillAmount = player.staminaAsPercentage;
        
    }
}
