using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float damadge = 1;
    public float lifeTime;
    public float fireRate;
    // Use this for initialization
    public bool isEnemyShoot = false;
	void Start () {
        Destroy(gameObject, lifeTime);
	}
}
