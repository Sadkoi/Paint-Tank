using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraHolderWork : MonoBehaviour
{
    public GameObject cameraHolder;
    public GameObject camera;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public LayerMask mask;

    private Vector3 originaldifferencePos;
    private Vector3 originaldifferenceEuler;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start(){
        mask = ~LayerMask.GetMask("Player");
        originaldifferencePos = camera.transform.position - transform.position; 
        originaldifferenceEuler = camera.transform.eulerAngles - transform.eulerAngles;
    }

    void Update () {
        Swivels();
        CameraClamp();
    }

    void Swivels(){
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void CameraClamp(){

    }
}
