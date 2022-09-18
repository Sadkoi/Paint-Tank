using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintBehaviour : MonoBehaviour
{
    public GameObject dispenser;
    public GameObject fire;
    public GameObject camera;
    public Texture2D texture;
    public Texture2D originalTexture;
    public GameObject bullet;

    public int offsetx;
    public int offsety;
    public int fireThrust;
    public Color teamColor;
    // Start is called before the first frame update
    void Start()
    {
        offsetx = 5;
        offsety = 5;
        fireThrust = 500;
        teamColor = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        Sweeper();
        fireInTheHole();
    }

    void Sweeper(){
         RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(dispenser.transform.position, transform.TransformDirection(Vector3.down), out hit, 5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            int UVxcoor = (int)(hit.textureCoord.x * texture.width);
            int UVycoor = (int)(hit.textureCoord.y * texture.height);
            for(int i = UVxcoor - offsetx; i < UVxcoor + offsetx; i++){
                for(int j = UVycoor - offsety; j < UVycoor + offsety; j++){
                    texture.SetPixel(i, j, teamColor);
                }
            }
            texture.Apply();
        }
    }

    void fireInTheHole(){
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0)){
            GameObject sphere = Instantiate(bullet, fire.transform.position, fire.transform.rotation);
            Rigidbody rb = sphere.AddComponent<Rigidbody>();
            rb.AddForce(fire.transform.forward * fireThrust);
        }
    }
}
