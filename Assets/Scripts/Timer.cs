using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{

    private float jmpTimer;
    private float maxJmp;
    private bool jumpCd;
    private string text;
    // Update is called once per frame
    void Update()
    {

        if (jumpCd == true)
        {
            if (jmpTimer > 0)
            {             
                jmpTimer -= Time.deltaTime;
            }
            else
            {

                jumpCd = false;
            }

        }
        else
        {
            jmpTimer = maxJmp;
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width/2, Screen.height/2, 70, 40), text + "\n" + jmpTimer.ToString("F2"));    
    }
    public void setJmpCd(bool jCd)
    {
        jumpCd = jCd;
    }

    public void setJmpTime(float time)
    {
        maxJmp = time;    
        jmpTimer = time;
    }

    public void setText(string txt)
    {
        text = txt;
    }
}