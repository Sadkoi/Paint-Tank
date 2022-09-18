using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimTank : MonoBehaviour
{
    public GameObject cameraHolder;
    public GameObject turret;
    public GameObject spinnyBod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinnyBod.transform.localEulerAngles = new Vector3(spinnyBod.transform.localEulerAngles.x, cameraHolder.transform.localEulerAngles.y,spinnyBod.transform.localEulerAngles.z);
        turret.transform.eulerAngles = new Vector3(cameraHolder.transform.eulerAngles.x,turret.transform.eulerAngles.y,turret.transform.eulerAngles.z);

        Cursor.visible = false;
    }
}
