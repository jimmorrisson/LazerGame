﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LazerScript : MonoBehaviour
{
	float dist = 1000.0f; //max distance for beam to travel
	LineRenderer lr;
	int limit = 100; //max reflection
	int verti = 1; //segment handler
	bool iactive;
	Vector3 currot;
	Vector3 curpos;
	public GameObject endPanel; //UI panel that shows while end
	public GameObject turret;
	public int lengthOfLineRenderer = 20;

	void Start () 
	{
		endPanel.SetActive (false);
		lr = gameObject.GetComponent<LineRenderer> ();
		lr.enabled = false;
	}
		
	void Update () 
	{
		lr.enabled = Input.GetMouseButton (0);
		if(Input.GetMouseButton(0))
		{
			DrawLaser();
		}
	}

	void DrawLaser()
	{
		verti = 1;
		iactive = true;
		curpos = transform.position;
		currot = transform.forward;
		lr.SetVertexCount (1);
		lr.SetPosition (0, transform.position);

		while (iactive) 
		{
			verti++;
			RaycastHit hit;
			lr.SetVertexCount (verti);
			if (Physics.Raycast (curpos, currot, out hit, dist)) 
			{
				//verti++
				curpos = hit.point;
				currot = Vector3.Reflect (currot, hit.normal);
				lr.SetPosition (verti - 1, hit.point);
				if(hit.collider.name == "EndGameTrigger")
				{
					EndGame ();
				}
				if (hit.collider.tag == "reflect") 
				{
					Debug.Log ("Działa");
					GameObject mirror = hit.collider.gameObject;
					LineRenderer refLR = mirror.GetComponent<LineRenderer> ();
					refLR.SetPosition (0, mirror.transform.position);
					refLR.enabled = true;
					RaycastHit refRayHit;
					Vector3 mirrorRot = new Vector3 (0, currot.y - 90, 0);
					if(Physics.Raycast(mirror.transform.position, mirrorRot, out refRayHit, dist))
					{
						mirror.transform.position = refRayHit.point;
						refLR.SetPosition (verti - 1, refRayHit.point);
					}
				}
			}

			else
			{
				iactive = false;
				lr.SetPosition (verti - 1, curpos + 100 * currot);
			}

			if (verti > limit) 
			{
				iactive = false;
			}
		}
	}
	public void EndGame()
	{
		GameObject.DestroyObject (turret);

		endPanel.SetActive (true);
	}
}
