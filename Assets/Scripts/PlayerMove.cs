using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {


    public GameObject bullet;
    public float speed;
    public float reverseSpeed;
    public float maxSpeed = 10f;
    private Rigidbody2D rb;
    private int extraBullets = 1;
    private TallentTree tallentTree;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        extraBullets = tallentTree.getExtraBullets();
    }
    void Awake()
    {
        tallentTree = GameObject.FindWithTag("TallentTree").GetComponent<TallentTree>();
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
                Quaternion rotationAmount = Quaternion.Euler(0, 0, (extraBullets - 1) * -15 + (30 * i));
                Instantiate(bullet, rb.position, transform.rotation * rotationAmount);

            }

        }


    }

    void Update()
    {

        //Creating bullets
       
       
        
    }
 
}
