using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TallentTree : MonoBehaviour {

    private int bullets = 1;
    private bool created;
	// Use this for initialization
    
	void Awake () {
        Debug.Log(created);
        if (!created)
        {
            DontDestroyOnLoad(transform.gameObject);
            created = true;
        }else
        {
            Destroy(this.gameObject);
        }

    }
	
    public void setExtraBullets(string name)
    {
        ++bullets;
        Debug.Log(bullets);
    }

    public void MenuButton(string menu)
    {
        SceneManager.LoadScene(menu);
    }
    public int getExtraBullets()
    {
        return bullets;
    }
	
}
