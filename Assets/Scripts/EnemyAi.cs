using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {
    public GameObject player;
    public float speed;
    public float maxSpeed;
    private Rigidbody2D playerRb;
    private Rigidbody2D enemyRb;
    // Use this for initialization
    void Start () {
        enemyRb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        enemyRb.AddForce(playerRb.position - enemyRb.position);
        if (enemyRb.velocity.magnitude > maxSpeed)
        {
            enemyRb.velocity = Vector3.ClampMagnitude(enemyRb.velocity, maxSpeed);
        }
    }
}
