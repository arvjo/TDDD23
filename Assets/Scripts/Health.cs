using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int hp = 1;
    public bool isEnemy = true;
    private GameController gameController;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet projectile = collider.gameObject.GetComponent<Bullet>();
        
       
        if (projectile != null)
        {
       
            if (projectile.isEnemyShoot != isEnemy)
            {
               
                hp -= projectile.damadge;
                Destroy(projectile.gameObject);
                if(hp == 0)
                {
                    if (gameObject.tag == "Player")
                    {
                         Debug.Log("HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
                         //gameController.GameOver();
                    }
                    Destroy(gameObject);
                   
                }
            }
        }
    }
}
