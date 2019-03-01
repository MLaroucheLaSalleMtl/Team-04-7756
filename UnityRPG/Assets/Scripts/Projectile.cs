using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damageCaused;
    public float projectileSpeed;

    public void SetDamage(float damage)
    {
        damageCaused = damage;
    }

    //[SerializeField] float projectileSpeed;
    //float damageCaused = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Component damagableComponent = other.gameObject.GetComponent(typeof(IDamageable));
        if (damagableComponent)
        {
            (damagableComponent as IDamageable).TakeDamage(damageCaused);
        }
    }
}
