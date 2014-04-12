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
    public float fadeOutSpeed = 0.4f;
    public Texture2D fadeTexture;

    private Rect TitlePos;
    private float alpha = 0.001f;

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
            alpha = MenuFade.FadeOut(fadeOutSpeed, fadeTexture, alpha);
            if (alpha >= 1)
                Application.LoadLevel(1);
        }
    }

    bool NoOtherButtonsPushed()
    {
        return !pushedNewGame;
    }





}
