using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int hp = 1;
    public bool isEnemy = true;
    private GameController gameController;
    private int enemyCount;
	// Use this for initialization

	void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet projectile = collider.gameObject.GetComponent<Bullet>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
     
        if (projectile != null)
        {
       
            if (projectile.isEnemyShoot != isEnemy)
            {
               
                hp -= projectile.damadge;
                Destroy(projectile.gameObject);
                if(hp == 0)
                {
                   
                    if(gameObject.tag == "Player")
                    {
                        gameController.GameOver();                    
                    }
                    else
                    {         
                        gameController.setECount();
                        
                    }
                    Destroy(gameObject);
                   
                }
            }
        }
    }

}
