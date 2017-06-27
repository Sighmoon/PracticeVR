using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float Speed;

    private float yaw = 0.0f;
    private float pitch = 45.0f;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        yaw += Speed * Input.GetAxis("Mouse X");
        pitch -= Speed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
