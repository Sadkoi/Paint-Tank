using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float splatRange;
    public float paintSpread;

    private bool shouldDie;
    public int offsetx;
    public int offsety;
    public Texture2D texture;
    public GameObject plane;
    public Color teamColor;
    // Start is called before the first frame update
    void Start()
    {
        splatRange = 0.2f;
        paintSpread = 10f;
        shouldDie = false;
        offsetx = 15;
        offsety = 15;
        teamColor = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        checkforSplat();
        apoptosis();
    }

    void checkforSplat(){
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, splatRange)){
            print("0");
            shouldDie = true;
            int UVxcoor = (int)(hit.textureCoord.x * texture.width);
            int UVycoor = (int)(hit.textureCoord.y * texture.height);
            for(int i = UVxcoor - offsetx; i < UVxcoor + offsetx; i++){
                for(int j = UVycoor - offsety; j < UVycoor + offsety; j++){
                    texture.SetPixel(i, j, teamColor);
                }
            }
            texture.Apply();
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, splatRange)){
            print("1");
            shouldDie = true;
            int UVxcoor = (int)(hit.textureCoord.x * texture.width);
            int UVycoor = (int)(hit.textureCoord.y * texture.height);
            for(int i = UVxcoor - offsetx; i < UVxcoor + offsetx; i++){
                for(int j = UVycoor - offsety; j < UVycoor + offsety; j++){
                    texture.SetPixel(i, j, teamColor);
                }
            }
            texture.Apply();
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, splatRange)){
            print("2");
            shouldDie = true;
            int UVxcoor = (int)(hit.textureCoord.x * texture.width);
            int UVycoor = (int)(hit.textureCoord.y * texture.height);
            for(int i = UVxcoor - offsetx; i < UVxcoor + offsetx; i++){
                for(int j = UVycoor - offsety; j < UVycoor + offsety; j++){
                    texture.SetPixel(i, j, teamColor);
                }
            }
            texture.Apply();
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, splatRange)){
            print("3");
            shouldDie = true;
            int UVxcoor = (int)(hit.textureCoord.x * texture.width);
            int UVycoor = (int)(hit.textureCoord.y * texture.height);
            for(int i = UVxcoor - offsetx; i < UVxcoor + offsetx; i++){
                for(int j = UVycoor - offsety; j < UVycoor + offsety; j++){
                    texture.SetPixel(i, j, teamColor);
                }
            }
            texture.Apply();
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, splatRange)){
            print("4");
            shouldDie = true;
            int UVxcoor = (int)(hit.textureCoord.x * texture.width);
            int UVycoor = (int)(hit.textureCoord.y * texture.height);
            for(int i = UVxcoor - offsetx; i < UVxcoor + offsetx; i++){
                for(int j = UVycoor - offsety; j < UVycoor + offsety; j++){
                    texture.SetPixel(i, j, teamColor);
                }
            }
            texture.Apply();
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, splatRange)){
            print("5");
            shouldDie = true;
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

    void apoptosis(){
        if(shouldDie){
            Destroy(gameObject);
        }
    }
}
