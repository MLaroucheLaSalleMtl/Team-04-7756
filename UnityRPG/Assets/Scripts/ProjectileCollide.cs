using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollide : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Collision enter has been triggered, now calling Hit");
        Hit(col);
    }

    void Hit(Collision col)
    {
        //Debug.Log("Called hit");
        // Make the projectile explode

        if (col.gameObject.tag == "Boss")
        {
            //Debug.Log("BOSS HAS BEEN HIT@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            //Debug.Log("BOSS HAS BEEN HIT@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            //Debug.Log("BOSS HAS BEEN HIT@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            //Debug.Log("BOSS HAS BEEN HIT@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

            col.gameObject.GetComponent<Boss>().currentHealthPoints -= 25;
        }
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log("ENEMY HAS BEEN HIT@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");


            //col.gameObject.GetComponent<Enemy>().currentHealthPoints -= 35;
        }

        Explode(col.contacts[0].point);

    }

    void Explode(Vector3 position)
    {
        //Debug.Log("Called explode");
        // Instantiate the explosion
        if (explosion != null)
        {
            Instantiate(explosion, position, Quaternion.identity);
        }

        
        

        // Destroy this projectile
        Destroy(gameObject);

        //Destroy(explosion, 4.0f);
    }
}
