using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float inputX = Input.GetAxis("Horizontal2");
       
       

        //transform.rotation = Quaternion.Euler(0,Angle,0);
        rb.MoveRotation(rb.rotation + speed * inputX);
    }
}
