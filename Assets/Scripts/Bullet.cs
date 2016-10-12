using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public int damadge = 1;
    public int lifeTime;
    // Use this for initialization
    public bool isEnemyShoot = false;
	void Start () {
        Destroy(gameObject, lifeTime);
	}
}
