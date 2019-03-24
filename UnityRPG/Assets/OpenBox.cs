using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private float interactiveDistance = 2f;
    [SerializeField] private GameObject openedBox;
    [SerializeField] private GameObject closedBox;
    [SerializeField] private GameObject playerWithSword;
    //[SerializeField] private GameObject playerWithoutSword;
    private bool canInteract;
    private bool canOpen;
    private bool canClose;

    AttackControl attackControl;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, interactiveDistance);
        attackControl = GetComponent<AttackControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canOpen = true;
        canClose = false;
        player = GameObject.FindGameObjectWithTag("Player");
        closedBox.SetActive(true);
        openedBox.SetActive(false);
        //playerWithSword.SetActive(false);
        //playerWithoutSword.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(distanceToPlayer <= interactiveDistance)
        {
            canInteract = true;
        }
        if (canInteract /*&& canOpen*/)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (canOpen)
                {
                    closedBox.SetActive(false);
                    openedBox.SetActive(true);
                    //attackControl.GetSword();
                    //playerWithoutSword.SetActive(false);
                    playerWithSword.SetActive(true);
                    //playerWithSword.transform.position = playerWithoutSword.transform.position;
                }
            }
        }
        //if(canInteract && !canOpen)
        //{
        //    if (Input.GetButtonDown("Interact"))
        //    {
        //        closedBox.SetActive(true);
        //        openedBox.SetActive(false);
        //    }
        //}
    }
}
