using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    Enemy enemy = null;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        healthBar.value = 1f;
        //healthBar.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //float healthPercentage = enemy.healthAsPercentage;
        healthBar.value = enemy.healthAsPercentage;
        //float healthRatio = Health / maxHp;
        //healthbar.rectTransform.localScale = new Vector3(xValue, 1, 1);
        //healthbar = new Rect(xValue, 0f, 0.5f, 1f);
    }
}
