using UnityEngine;
using System.Collections;



public class IntroMenuGUI : MonoBehaviour {

    const int FIRST_LEVEL = 1;
    bool pushedNewGame = false;

    public Texture2D title;
    public float buttonWidthPercent = .20f;
    public float buttonHeightPercent = .05f;
    public float spacing = 4f;
    public float TitleHeight = .03f;
    public float TitleScale = 1f;

    private Rect TitlePos;

    void OnGUI()
    {
        //Title
        TitlePos.width = title.width * TitleScale;
        TitlePos.height = title.height * TitleScale;
        TitlePos.x = Screen.width/2 - TitlePos.width/2;
        TitlePos.y = TitleHeight;
        GUI.DrawTexture(TitlePos,title);

        float buttonWidth = Screen.width * buttonWidthPercent;
        float buttonHeight = Screen.height * buttonHeightPercent;

        if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth/2, buttonHeight * 4, buttonWidth , buttonHeight), "New Game"))
        {
            if (NoOtherButtonsPushed())
                pushedNewGame = true;
            Debug.Log("buttonPushed");
        }

        if (pushedNewGame)
        {
            if (FadeOut())
                Debug.Log("FistLevelGo");
            //load FirstLevel
        }
    }

    bool NoOtherButtonsPushed()
    {
        return !pushedNewGame;
    }



    //Fade Screen, based on Griffo's answer
    //http://answers.unity3d.com/questions/341350/how-to-fade-out-a-scene.html
    public Texture2D fadeTexture;
    float fadeSpeed = 0.2f;
    float drawDepth = -1000;
 
    private float alpha = 0.001f; 
    private float fadeDir = 1;

    bool FadeOut(){
 
        alpha += fadeDir * fadeSpeed * Time.deltaTime;  
        alpha = Mathf.Clamp01(alpha);

        Color temp = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.color = temp;
 
        GUI.depth = (int)drawDepth;
 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

        return alpha == .000f || alpha == 1.00;
    }

}
