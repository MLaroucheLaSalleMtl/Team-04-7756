using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 fairyPosition;
    private float speed;
    private Vector3 oldPos;
    private float radian = 0f;
    private float perRadian = 0.03f;
    private float radius = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PetPosition");
        speed = 3f;
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Fairy follow the player
        if(Vector3.Distance(player.transform.position, transform.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * speed);
        }

        //Fairy only rotate on y axis
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime + speed);
    }
}
