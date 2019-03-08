using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damageCaused;
    public float projectileSpeed;
    GameObject player = null;

    public void SetDamage(float damage)
    {
        damageCaused = damage;
    }

    //[SerializeField] float projectileSpeed;
    //float damageCaused = 10f;
    //private void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //}

    //private void Update()
    //{
    //    transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
    //}

    private void OnTriggerEnter(Collider other)
    {
        Component damagableComponent = other.gameObject.GetComponent(typeof(IDamageable));
        if (damagableComponent)
        {
            (damagableComponent as IDamageable).TakeDamage(damageCaused);
        }
        Destroy(gameObject, 10f);
    }
}
