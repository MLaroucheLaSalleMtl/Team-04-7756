using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] public float hp = 100f;
    [SerializeField] private GameObject character;
    //[SerializeField] private GameObject fromWho;
    ThirdPersonCharacter player;
    public Slider hpBar;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<GameObject>();
        //fromWho = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "EnemyWeapon")
        {
            hpBar.value = (float)hp / 100;
            hp -= 20f;
            Debug.Log("Hero Take Damage");
        }
    }
}
