using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed;// = new Vector2(10, 10);
    public float torque;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();      

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

   
        Vector3 movement = new Vector3(speed * inputX , speed * inputY, 0);
       
       /*
        if (inputY > 0)
        {
            rb.AddForce(movement);
        }*/

        rb.AddForce(movement);
        /*movement *= Time.deltaTime;
        transform.Translate(movement);*/
    }
}
