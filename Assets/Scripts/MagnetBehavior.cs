using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MagnetBehavior : MonoBehaviour {

    public float Frequency;
    public Material ActiveMaterial;
    public Material DeactiveMaterial;
    public GameObject Player;

    private System.Random rand;
    private float timer;
    private int activeWall;
    private Rigidbody playerRB;

    // Use this for initialization
    void Start ()
    {
        activeWall = -1;
        rand = new System.Random();
        playerRB = Player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= 10*Frequency)//change the float value here to change how long it takes to switch.
        {
            timer = 0;
            GameObject obj = null;
            activeWall = rand.Next(3);
            obj = FindWallById(activeWall);
            obj.tag = "Active Wall";
            Renderer rend = obj.GetComponent<Renderer>();
            rend.material = ActiveMaterial;
        }
        else if (timer >= 9*Frequency&&activeWall != -1)
        {
            GameObject obj = FindWallById(activeWall);
            Renderer rend = obj.GetComponent<Renderer>();
            rend.material = DeactiveMaterial;
            activeWall = -1;
            obj.tag = "Deactive Wall";
        }
    }

    private GameObject FindWallById(int id)
    {
        GameObject obj = null;
        switch (activeWall)
        {
            case 0:
                obj = transform.Find("Top Wall").gameObject;
                break;
            case 1:
                obj = transform.Find("Right Wall").gameObject;
                break;
            case 2:
                obj = transform.Find("Bottom Wall").gameObject;
                break;
            case 3:
                obj = transform.Find("Bottom Wall").gameObject;
                break;
        }
        return obj;
    }
}
