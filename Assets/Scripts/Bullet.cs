using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private int damadge = 1;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10);
	}
	
}
