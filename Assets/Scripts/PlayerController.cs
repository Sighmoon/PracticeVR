using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public Text CountText;
    public Text WinText;
    public Camera MainCamera;

    private Rigidbody rb;
    private int count;
    

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Ray ray = new Ray(MainCamera.transform.position, MainCamera.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            moveHorizontal = hit.point.x - transform.position.x;
            moveVertical = hit.point.z - transform.position.z;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        GameObject obj = GameObject.FindGameObjectWithTag("Active Wall");
        if(obj!=null)
        {
            movement += (obj.transform.position - rb.transform.position);
        }

        rb.velocity = movement * Speed;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            WinText.text = "You Win!";
        }
    }
}
