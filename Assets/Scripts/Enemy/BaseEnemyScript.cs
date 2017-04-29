using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyScript : MonoBehaviour
{
    private Quaternion MyRotation;
    private float Speed;

    public Rigidbody myRigid;

    // public GameObject[] turrets = new GameObject[2];
    public Transform turret;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        Speed = 0.05f;
        MyRotation = transform.rotation;
        myRigid = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //transform.position += 0.1f*Vector3.left;
        if (GameObject.FindGameObjectWithTag("Turret") != null)
        {
            turret = GameObject.FindGameObjectWithTag("Turret").transform;
            AttactTurret();
        }
        else
            Rest();
        //if (turret != null)
        //Debug.Log(myRigid.velocity);
    }

    private void AttactTurret()
    {
        transform.LookAt(turret);
        // if(turret.position.z )
        transform.position += transform.forward * Speed;
    }

    private void Rest()
    {
        // Debug.Log("No player on the scene");
    }
}
