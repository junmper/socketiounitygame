﻿
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool isLocalPlayer = true; //TODO: switch with networking 
    public bool isGrounded = true;
    public float speed = 3.0f;
    public float rotationSpeed = 450.0f;


    Vector3 oldPosition;
    Vector3 currentPosition;
    Quaternion oldRotation;
    Quaternion currentRotation;

    private void Start()
    {
        oldPosition = transform.position;
        currentPosition = oldPosition;
        oldRotation = transform.rotation;

        currentRotation = oldRotation;
    }

    // Update is called once per frame
    void Update () {

        if (!isLocalPlayer){
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var rx = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;

        //print(x);

        Rotate(new Vector3(0, rx, 0));
        Move(new Vector3(x, 0, z));


        currentPosition = transform.position;
        currentRotation = transform.rotation;

        if(currentPosition != oldPosition) {
            //TODO networking
            oldPosition = currentPosition;
        }

        if(currentRotation != oldRotation) {
            //TODO networking
            oldRotation = currentRotation;
        }

        /*if(currentPosition.y <= 1.0f && currentPosition.y > 0.9f)
        {
            print("tierra");
            isGrounded = true;
        }
        else
        {
            print("no tierra");
            isGrounded = false;
        }

        print("posicion en y = " + currentPosition.y);*/

        if(Input.GetMouseButtonDown(0))
        {
            //TODO networking
            //n.CommandShott();
            CmdFire();
        }

    }

    public void CmdFire()
    {
        var bullet = Instantiate(bulletPrefab,
                                    bulletSpawn.position,
                                    bulletSpawn.rotation) as GameObject;

        Bullet b = bullet.GetComponent<Bullet>();
        b.playerFrom = this.gameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 6;

        Destroy(bullet, 2.0f);
    }

    public void Move(Vector3 vec)
    {
        transform.Translate(vec);
    }

    public void Rotate(Vector3 vec)
    {
        transform.Rotate(vec);
    }
}
    