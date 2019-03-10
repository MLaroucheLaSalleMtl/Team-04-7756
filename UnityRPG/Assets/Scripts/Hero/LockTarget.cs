using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;

public class LockTarget : MonoBehaviour
{
    public float minRange = 0f;
    public float maxRange = 100f;
    public float rightAngle = 45f;
    public float leftAngle = 45f;
    public float UpAngle = 45f;
    public float DownAngle = 45f;

    public bool isTargeting = false;
    public Color color = new Color(0f, 1f, 0f, 0.04f);

    //public Transform[] targets;
    private GameObject[] targets;
    public Dictionary<Transform, float> rank = new Dictionary<Transform, float>();
    private Transform get;
    private Ray ray;
    private Vector3 targetMarkOffset;
    
    //private Image reticle;
    private GameObject targetMark;

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        targetMark = GameObject.Find("TargetMark");
        targetMark.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        LockingRange();
        targetMark.transform.position = GetTargetPositionWithUI(get.transform.position + targetMarkOffset);
    }

    void LockingRange()
    {
        foreach (GameObject i in targets)
        {
            float distance = (i.transform.position - transform.position).magnitude;
            if (distance >= minRange && distance <= maxRange)
            {
                if (!rank.ContainsKey(i.transform))
                {
                    rank.Add(i.transform, distance);
                }
                else
                {
                    rank[i.transform] = distance;
                }

            }
        }
        GetRange();
    }

    void GetRange()
    {
        List<float> list_distance = new List<float>();
        List<Transform> list_obj = new List<Transform>();
        float b = 0;
        if (rank.Count > 0) //if there are any enemies (rank is Dictionary that store enemies)
        {
            foreach (Transform tra1 in rank.Keys)   //if tran1 is not in the Dictionary
            {
                list_distance.Add(rank[tra1]);      //add the distance to player into Dictionary (float)
            }
            b = list_distance.Min();

            foreach (Transform tra2 in rank.Keys)   
            {
                if (rank[tra2] == b)
                {
                    list_obj.Add(tra2);             //Add the object into Dictionary (Transform)
                }
            }
            get = list_obj[0];

            //Debug.Log("get is " + get + "...distance is " + b);
            Debug.Log($"Number of gameobject: {list_obj.Count}");

            if (Input.GetButtonDown("Targeting"))
            {
                isTargeting = true;
                targetMark.SetActive(true);
                
            }
            //if (Input.GetButtonUp("Targeting"))
            //{
            //    isTargeting = false;
            //    targetMark.SetActive(false);
            //}

        }
    }

    private Vector3 GetTargetPositionWithUI(Vector3 targetPos)
    {
        var temp = Camera.main.WorldToScreenPoint(targetPos);
        temp.z = 0;
        return temp;
    }

    private void OnDrawGizmos()
    {
        if (isTargeting)
        {
            DrawRange();
        }
    }

    void DrawRange()
    {
        Handles.color = color;
        //绘制扇形视野范围，第一个参数圆的中心点，第二参数圆的法线方向，第三个参数扇形开始点，第四个参数扇形的弧度，第五个参数扇形半径
        Handles.DrawSolidArc(transform.position, transform.up, transform.forward, -leftAngle, maxRange);
        Handles.DrawSolidArc(transform.position, transform.up, transform.forward, rightAngle, maxRange);

        Handles.DrawSolidArc(transform.position, transform.right, transform.forward, -UpAngle, maxRange);
        Handles.DrawSolidArc(transform.position, transform.right, transform.forward, DownAngle, maxRange);

        Handles.color = new Color(1, 0, 0, color.a);
        Handles.DrawSolidArc(transform.position, transform.up, transform.forward, -leftAngle, minRange);
        Handles.DrawSolidArc(transform.position, transform.up, transform.forward, rightAngle, minRange);

        Handles.DrawSolidArc(transform.position, transform.right, transform.forward, -UpAngle, minRange);
        Handles.DrawSolidArc(transform.position, transform.right, transform.forward, DownAngle, minRange);

        //绘制扇形的弧线，第一个参数圆的中心点，第二个参数圆的法线，第三个参数弧线起始点，第四个参数弧度，第五个参数圆弧半径
        Handles.color = new Color(color.r, color.g, color.b);
        Handles.DrawWireArc(transform.position, transform.up, transform.forward, -leftAngle, maxRange);
        Handles.DrawWireArc(transform.position, transform.up, transform.forward, rightAngle, maxRange);
        Handles.DrawWireArc(transform.position, transform.right, transform.forward, -UpAngle, maxRange);
        Handles.DrawWireArc(transform.position, transform.right, transform.forward, DownAngle, maxRange);

        Handles.DrawWireArc(transform.position, transform.up, transform.forward, -leftAngle, minRange);
        Handles.DrawWireArc(transform.position, transform.up, transform.forward, rightAngle, minRange);
        Handles.DrawWireArc(transform.position, transform.right, transform.forward, -UpAngle, minRange);
        Handles.DrawWireArc(transform.position, transform.right, transform.forward, DownAngle, minRange);

    }
}
