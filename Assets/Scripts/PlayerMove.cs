using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {


    public GameObject bullet;
    public float speed;// = new Vector2(10, 10);
    public float reverseSpeed;
    public float maxSpeed = 10f;
    private Rigidbody2D rb;
    private int extraBullets = 1;
    private TallentTree tallentTree;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
       
        extraBullets = tallentTree.getExtraBullets();
        Debug.Log(extraBullets);
    }
    void Awake()
    {
        tallentTree = GameObject.FindWithTag("TallentTree").GetComponent<TallentTree>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        //float inputX = Input.GetAxis("Horizontal");
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
            for (int i = 0; i < extraBullets; ++i)
            {
                
                Quaternion rotationAmount = Quaternion.Euler(0, 0, (extraBullets - 1)* -15 + (30 *i));
                Debug.Log(rotationAmount);
                Instantiate(bullet, rb.position, transform.rotation * rotationAmount);
            }
        }

    }
}
