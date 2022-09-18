using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankBehaviour : MonoBehaviour
{

    public Rigidbody rb;
    public Material mymat;
    public GameObject tank;
    public GameObject turret;
    public GameObject cameraHolder;

    public float thrust;
    public float torque;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        thrust = 7000f;
        torque = 100f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TankController(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical") );
        checkForRespawn();
    }

    void TankController(float x, float y){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.2f)){
            rb.AddForce(transform.forward * y * thrust);
            transform.Rotate(0f, torque * x * Time.deltaTime, 0f, Space.Self);
            if(y < 0){
                mymat.SetColor("_EmissionColor", Color.red);
            }else{
                mymat.SetColor("_EmissionColor", Color.black);
            }
        }else{
            transform.Rotate(torque * y * Time.deltaTime, 0f, torque * x * Time.deltaTime);
        }

    }

    void checkForRespawn(){
        if(tank.transform.position.y < 0){
            tank.transform.position = new Vector3(-4.3f,0.18f,-10.4f);
            tank.transform.eulerAngles = new Vector3(0f,tank.transform.eulerAngles.y,0f);
            turret.transform.eulerAngles = tank.transform.eulerAngles;
            cameraHolder.transform.eulerAngles = tank.transform.eulerAngles;
        }
    }

}
