using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    [SerializeField] Tilemap terrainTilemap;

    void Start ()
    {
    body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        Vector3 pos = transform.position;
        

        if  (Input.GetKeyDown(("e"))){
            Debug.Log(terrainTilemap.GetTile(ConvertToVector3(pos)));
        }
    }

    void FixedUpdate()
    {
    if (horizontal != 0 && vertical != 0) // Check for diagonal movement
    {
        // limit movement speed diagonally, so you move at 70% speed
        horizontal *= moveLimiter;
        vertical *= moveLimiter;
    } 

    body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }   
    public static Vector3Int ConvertToVector3(Vector3 vec3){
        return new Vector3Int((int)vec3.x, (int)vec3.y, (int)vec3.z);
    }
}

