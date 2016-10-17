using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

    public float hp = 1;
    public bool isEnemy = true;
    protected GameController gameController;
    private int enemyCount;
    protected Slider healthBar;
    private float lastDmgTaken;
    private float tmp;
    private float maxHp;
    public SpecialEffects effects;
    public SoundEffects soundEffects;
    // Use this for initialization
    void Start()
    {
        maxHp = hp;
        healthBar = GameObject.FindWithTag("Healthbar").GetComponent<Slider>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        effects = GameObject.FindWithTag("Script").GetComponent<SpecialEffects>();
        soundEffects = GameObject.FindWithTag("Script").GetComponent<SoundEffects>();
        lastDmgTaken = 0;
       
    }
    void Update()
    {
        if (gameObject.tag == "Player")
        { 
            if (Time.time - lastDmgTaken > 5)
            {
                hp = maxHp;
                healthBar.value = hp;
            }
        }
    }
 
    void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet projectile = collider.gameObject.GetComponent<Bullet>();
        
        
        if (projectile != null)
        {
       
            if (projectile.isEnemyShoot != isEnemy)
            {
               
                hp -= projectile.damadge;
                
                Destroy(projectile.gameObject);
                if (gameObject.tag == "Player")
                {
                    healthBar.value = hp;
                    lastDmgTaken = Time.time;
                }

                if (hp <= 0)
                {
                   
                    if(gameObject.tag == "Player")
                    {
                        gameController.GameOver();                    
                    }
                    else
                    {         
                        gameController.setECount();
                        
                    }
                    effects.Explosion(transform.position);
                    soundEffects.MakeExplosionSound(transform.position);
                    Destroy(gameObject);
                   
                }
            }
        }
    }
}
