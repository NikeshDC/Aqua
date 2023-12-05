using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunmanController : MonoBehaviour
{
    [HideInInspector] public Transform A;
    public Transform B;
    [HideInInspector] public LineRenderer lineRenderer;
    [HideInInspector] public GameObject rifle;

    [HideInInspector] public bool shootOnce = false;

    private GameObject projectilePath;
    private GameObject mixamorigHips;

    public bool shootBullet;
    public bool noEnemyInSight;

    private void Awake()
    {
        //Assign gameobjects in scene to respective fields

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject gameObject = transform.GetChild(i).gameObject;
            if (gameObject.name == "ProjectilePath")
            {
                projectilePath = gameObject;
                lineRenderer = projectilePath.GetComponent<LineRenderer>();
            }
            else if (gameObject.name == "mixamorig:Hips")
            {
                mixamorigHips = gameObject;
            }
        }
        for (int i = 0; i < mixamorigHips.transform.childCount; i++)
        {
            GameObject gameObject = mixamorigHips.transform.GetChild(i).gameObject;
            if (gameObject.name == "rifle")
            {
                rifle = gameObject;
            }
        }
        for (int i = 0; i < rifle.transform.childCount; i++)
        {
            GameObject gameObject = rifle.transform.GetChild(i).gameObject;
            if (gameObject.name == "StartPoint")
            {
                A = gameObject.transform;
            }
        }
    }
    private void Start()
    {
        shootBullet = true;
        noEnemyInSight = true;
        lineRenderer.enabled = false;
    }
    private void Update()
    {
        if (B != null)
        {
            transform.LookAt(B);//archer faces the ship       
        }
    }

    //Only during scene view, draw a line between points
    private void OnDrawGizmos()//Draw Straight line between start and end points
    {
        if (A == null || B == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Evaluate(0), Evaluate(1));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Evaluate(0), 0.01f);
        Gizmos.DrawWireSphere(Evaluate(1), 0.01f);
    }

    private Vector3 Evaluate(float t)
    {
        Vector3 ab = Vector3.Lerp(A.position, B.position, t);//Interpolate from point A to B
        return ab;
    }
}
