using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damageCaused;
    public float projectileSpeed;

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
