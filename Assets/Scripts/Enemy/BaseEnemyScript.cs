using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyScript : MonoBehaviour
{
    private Quaternion MyRotation;
    private float Speed;
    private bool attack = false;

    public Rigidbody myRigid;
    public Transform turret;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        Speed = 0.05f;
        MyRotation = transform.rotation;
        myRigid = gameObject.GetComponent<Rigidbody>();

        //Checking for turret
        if (GameObject.FindGameObjectWithTag("Turret") != null)
        {
            turret = GameObject.FindGameObjectWithTag("Turret").transform;
            attack = true;
            Debug.Log("Attack " + turret.GetComponent<BaseTurret>().Life);
        }
    }

    private void Update()
    {
        if (attack == true)
        {
            AttactTurret();
        }
    }

    private void AttactTurret()
    {
        transform.LookAt(turret);
        transform.position += transform.forward * Speed;
    }

    private void Rest()
    {
        // Debug.Log("No player on the scene");
    }

    public void OnTurretSpawned(object source, TurretSpawnedEventArgs e)
    {
        if (GameObject.FindGameObjectWithTag("Turret") != null)
        {
            turret = GameObject.FindGameObjectWithTag("Turret").transform;
        }
        Debug.Log("Attack " + e.Life);
        attack = true;
    }
}
