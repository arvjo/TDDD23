﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {


    public GameObject bullet;
    public GameObject superBullet;
    private GameObject activeBullet;
    private bool sBullet;
    public float speed;
    public float reverseSpeed;
    public float maxSpeed = 10f;
    private Rigidbody2D rb;
    private int extraBullets = 1;
    private TallentTree tallentTree;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    private float jumpRate = 1.0F;
    private float nextJump = 0.0F;
    private Vector3 oldPos;
    private int jumpDist = 3;

    // Use this for initialization
    void Awake()
    {
        tallentTree = GameObject.FindWithTag("TallentTree").GetComponent<TallentTree>();
    }
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        extraBullets = tallentTree.getExtraBullets();
        sBullet = tallentTree.getSuperBullet();
        if(sBullet == false)
        {
            activeBullet = bullet;
        }else
        {
            activeBullet = superBullet;
            Debug.Log(activeBullet);
        }
        
    }
 

    // Update is called once per frame
    void FixedUpdate() {
        float inputY = Input.GetAxis("Vertical");
        //Go forward
        if (inputY > 0)
        {
            rb.AddForce(transform.right * inputY * speed);
        }
        //Go backwards
        if(inputY < 0)
        {
            rb.AddForce(transform.right * inputY * reverseSpeed);
        }
    
        //Limit the speed - nullifing constant acceleration
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        if (Input.GetAxis("right_trigger") == 1 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            for (int i = 0; i < extraBullets; ++i)
            {
                Quaternion rotationAmount = Quaternion.Euler(0, 0, (extraBullets - 1) * -2 + (4 * i));
                Instantiate(activeBullet, rb.position, transform.rotation * rotationAmount);

                
            }

        }
      
       if (Input.GetButtonUp("y-button")&& Time.time > nextJump)
        {
            nextJump = Time.time + jumpRate;
            oldPos = rb.transform.position;
          
            if ((rb.transform.position += transform.right * jumpDist).x > 80 || (rb.transform.position += transform.right * jumpDist).x < -80
                || (rb.transform.position += transform.right * jumpDist).y > 40 || (rb.transform.position += transform.right * jumpDist).y < -40)
            {                         
                rb.transform.position = oldPos;
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                rb.AddForce(transform.right * 500); 
            }
            
        }
        


    }

    void Update()
    {

        //Creating bullets
       
       
        
    }
 
}
