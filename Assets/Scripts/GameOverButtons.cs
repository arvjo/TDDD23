using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {

	public void RestartButton(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void MenuButton(string menu)
    {
        SceneManager.LoadScene(menu);
    }
}
