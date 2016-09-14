using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {


    public GameObject bullet;
    public float speed;// = new Vector2(10, 10);
    public float reverseSpeed;
    public float maxSpeed = 10f;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();      

    }

    // Update is called once per frame
    void FixedUpdate() {
        float inputX = Input.GetAxis("Horizontal");
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
        /*
        if (inputX > 0)
        {
            rb.AddForce(transform.up * inputX * speed);
        }
        if (inputX < 0)
        {
            rb.AddForce(transform.up * inputX *speed);
        }
        */
        //Limit the speed - nullifing constant acceleration
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        //Creating bullets
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, rb.position, transform.rotation);
        }

    }
}
