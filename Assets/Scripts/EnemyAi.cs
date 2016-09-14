using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {
    public GameObject player;
    public float speed;
    public float maxSpeed;
    private Rigidbody2D playerRb;
    private Rigidbody2D enemyRb;
    public GameObject bullet;
   // public float shootrate = 100f;

    // Use this for initialization
    void Start () {
        enemyRb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
        //InvokeRepeating("shoot", 2, 0.5F);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Vector2.Angle(enemyRb.position, playerRb.position);
        //enemyRb.rotation = Vector2.Angle(enemyRb.position, playerRb.position);
        //enemyRb.transform
        Debug.Log(enemyRb.rotation);
        //enemyRb.MoveRotation();
        //enemyRb.AddForce(playerRb.position - enemyRb.position);
        if (enemyRb.velocity.magnitude > maxSpeed)
        {
            enemyRb.velocity = Vector3.ClampMagnitude(enemyRb.velocity, maxSpeed);
        }
     
    }
    void shoot()
    {
        Instantiate(bullet, enemyRb.position, transform.rotation);
    }
}
