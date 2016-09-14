using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int hp = 1;
    public bool isEnemy = true; 
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet projectile = collider.gameObject.GetComponent<Bullet>();
        Debug.Log("trigger");
        if (projectile != null)
        {
            Debug.Log("Hej");
            if (projectile.isEnemyShoot != isEnemy)
            {
                Debug.Log("träff");
                hp -= projectile.damadge;
                Destroy(projectile.gameObject);
                if(hp == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
