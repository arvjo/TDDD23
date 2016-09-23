using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    void OnGUI()
    {
        const int buttonWidth = 200;
        const int buttonHeight = 100;
        if(GUI.Button(new Rect( Screen.width/2 -(buttonWidth/2), (2*Screen.height/4)- (buttonHeight/2), buttonWidth, buttonHeight), "Start!"))
        {
            SceneManager.LoadScene("scene1");
        }


        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3 +50) - (buttonHeight / 2), buttonWidth, buttonHeight), "Tallents"))
        {
            SceneManager.LoadScene("Tallents");
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	

}
