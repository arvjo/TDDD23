using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TallentTree : MonoBehaviour {
    private int bullets = 1;
    private bool superBullet = false;
    private bool pMine = false;
    private bool revTeleport = false;
    // Use this for initialization
    private static TallentTree tallentTreeInstance;
    private bool showButton = true;
    private int currentScene;
    private int previousScene;
    private int tPoints = 0;
    private bool bulletSkillUsed = false;
    private bool superBulletSkillUsed = false;
    private bool mineSkillUsed = false;
    private bool teleSkillUsed = false;
    void Awake () {
        DontDestroyOnLoad(this.gameObject);
        

        if (tallentTreeInstance == null)
        {
            tallentTreeInstance = this;
        }else
        {
            tallentTreeInstance.currentScene = SceneManager.GetActiveScene().buildIndex;
            tallentTreeInstance.showButton = true;
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
       
    }
    void OnGUI()
    {
        const int buttonWidth = 200;
        const int buttonHeight = 100;


        if (showButton && currentScene == 7)
        {
            if (tPoints == 0 || bulletSkillUsed == true)
            {
                GUI.enabled = false;
            }else
            {
                GUI.enabled = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2 - Screen.width /12), (2 * Screen.height / 5) - (buttonHeight / 2), buttonWidth, buttonHeight), "Fire three bullets with\n half the dammadge per bullet\n simultaneously"))
            {          
                bullets = 3;
                --tPoints;
                bulletSkillUsed = true;
            }

            if (tPoints == 0 || teleSkillUsed == true)
            {
                GUI.enabled = false;
            }
            else
            {
                GUI.enabled = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth * 2 - Screen.width / 12), (2 * Screen.height / 5) - (buttonHeight / 2), buttonWidth, buttonHeight), "Teleport to the position\n you were at 2 seconds ago.\n The position is set\n at button press"))
            {
                revTeleport = true;
                --tPoints;
                teleSkillUsed = true;
            }


            if (tPoints < 2 || superBulletSkillUsed == true || mineSkillUsed == true)
            {
                GUI.enabled = false;               
            }
            else
            {
                GUI.enabled = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth /2 - Screen.width/12), (2 * Screen.height / 4 ) , buttonWidth, buttonHeight), "Your bullets travel faster\n and have higer damadge,\n but you cant shoot as often.\n can be combined with \nmultiple bullets skill"))
            {
                superBullet = true;
                tPoints -= 2;
                superBulletSkillUsed = true;
            }


            if (tPoints < 2 || mineSkillUsed == true || superBulletSkillUsed == true)
            {
                GUI.enabled = false;
            }
            else
            {
                GUI.enabled = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth * 2 - Screen.width/12), (2 * Screen.height / 4), buttonWidth, buttonHeight), "Place mines at your current\n position instead of shooting\n bulets, can be combined with \nmultiple bullets skill"))
            {
                pMine = true;
                --tPoints;
                mineSkillUsed = true;
            }


            GUI.enabled = true;
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3 + 100) - (buttonHeight / 2), buttonWidth, buttonHeight), "Menu"))
            {
                SceneManager.LoadScene("menu");
                showButton = false;
            }
        }
    }
	
    public int getExtraBullets()
    {
        return bullets;
    }

    public bool getSuperBullet()
    {
        return superBullet;
    }

    public bool getpMine()
    {
        return pMine;
    }

    public bool getRevTele()
    {
        return revTeleport;
    }

    public void addTPoints()
    {
        ++tPoints;          
    }
}
