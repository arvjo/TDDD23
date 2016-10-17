using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {
    public GameObject player;
    public float speed;
    public float maxSpeed;
    private Rigidbody2D playerRb;
    private Rigidbody2D enemyRb;
    public GameObject bullet;
    public float shootRate;
    private Vector3 direction;
    private bool dSwitchUp = true;
    public bool dSwitch;
    public int force;
    public int turnTime;

    // Use this for initialization
    void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        enemyRb = GetComponent<Rigidbody2D>();
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
            InvokeRepeating("shoot", 1.5F, shootRate);
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

          
            
            if (dir.magnitude < 5)
            {
                enemyRb.velocity = enemyRb.velocity / 1.05f;
            }
                   
            enemyRb.AddForce(playerRb.position - enemyRb.position);
            if (dSwitch == true)
            {
                if (dSwitchUp == true)
                {
                    direction = playerRb.transform.up * force;
                    dSwitchUp = false;
                }
                else
                {
                    direction = playerRb.transform.up * -force;
                }
                StartCoroutine(altBehaviour(direction));

            }
        }
        if (enemyRb.velocity.magnitude > maxSpeed)
        {
            enemyRb.velocity = Vector3.ClampMagnitude(enemyRb.velocity, maxSpeed);
        }
     
    }
    IEnumerator altBehaviour(Vector3 direction)
    {
        enemyRb.AddForce(direction);
        yield return new WaitForSeconds(turnTime);
    }
    void shoot()
    {
        Instantiate(bullet, enemyRb.position, transform.rotation);
    }
}
