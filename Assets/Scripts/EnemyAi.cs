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
        GameObject player = GameObject.FindWithTag("Player");
        enemyRb = GetComponent<Rigidbody2D>();
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
            InvokeRepeating("shoot", 2, 0.5F);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (playerRb != null)
        {
            //turning the enemy towards the player
            Vector2 dir = playerRb.position - enemyRb.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

          
            
            if (dir.magnitude < 3)
            {
                enemyRb.velocity = enemyRb.velocity / 1.05f;
            }
            /*if (enemyRb.transform.rotation == Quaternion.AngleAxis(-angle, Vector3.forward))
            {
                dir = playerRb.position - enemyRb.position;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }*/
            enemyRb.AddForce(playerRb.position - enemyRb.position);
        }
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
