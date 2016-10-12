using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TallentTree : MonoBehaviour {

    private int bullets = 1;
    // Use this for initialization
    private static TallentTree tallentTreeInstance;
    private bool showButton = true;
    private int currentScene;
    private int previousScene;
    private int tPoints = 0;
    private int newTPoints = 0;
    private bool bulletSkillUsed = false;

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

    
    void OnGUI()
    {
        const int buttonWidth = 200;
        const int buttonHeight = 100;
       
        if (showButton && currentScene == 6)
        {
            if (tPoints == 0 || bulletSkillUsed == true)
            {
                GUI.enabled = false;
            }else
            {
                GUI.enabled = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 4) - (buttonHeight / 2), buttonWidth, buttonHeight), "3 bullets!"))
            {
                bullets = 3;
                --tPoints;
                bulletSkillUsed = true;
            }

            GUI.enabled = true;
            if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3 + 50) - (buttonHeight / 2), buttonWidth, buttonHeight), "Menu"))
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
    public void addTPoints()
    {
        ++newTPoints;
        if(newTPoints != tPoints)
        {
            tPoints = newTPoints;
        }
        newTPoints = 0;
    }
}
