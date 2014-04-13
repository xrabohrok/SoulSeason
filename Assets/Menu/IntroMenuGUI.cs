using UnityEngine;
using System.Collections;

public class IntroMenuGUI : MonoBehaviour {

    const int FIRST_LEVEL = 1;
    bool pushedNewGame = false;
    bool pushedQuit = false;
    bool creditsPushed = false;

    public Texture2D title;
    public float buttonWidthPercent = .20f;
    public float buttonHeightPercent = .05f;
    public float spacing = 10f;
    public float TitleHeight = .03f;
    public float TitleScale = 1f;
    public float fadeOutSpeed = 0.4f;
    public float verticalButtonDisp = .6f;
    public float horizontalButtonDisp = .5f;

    public int newGameIndex = 4;
    public int creditsIndex = 2;

    public Texture2D fadeTexture;

    private Rect TitlePos;
    private float alpha = 0.001f;

    void OnGUI()
    {
        //Title
        if (title != null)
        {
            TitlePos.width = title.width * TitleScale;
            TitlePos.height = title.height * TitleScale;
            TitlePos.x = Screen.width / 2 - TitlePos.width / 2;
            TitlePos.y = TitleHeight;
            GUI.DrawTexture(TitlePos, title);
        }

        float buttonWidth = Screen.width * buttonWidthPercent;
        float buttonHeight = Screen.height * buttonHeightPercent;

        if (GUI.Button(new Rect(Screen.width * horizontalButtonDisp - buttonWidth/2, Screen.height * verticalButtonDisp + buttonHeight * 1 + spacing, buttonWidth , buttonHeight), "New Game"))
        {
            if (NoOtherButtonsPushed())
                pushedNewGame = true;
        }

        if (GUI.Button(new Rect(Screen.width * horizontalButtonDisp - buttonWidth / 2, Screen.height * verticalButtonDisp + buttonHeight * 2 + 2 * spacing, buttonWidth, buttonHeight), "Credits"))
        {
            if (NoOtherButtonsPushed())
                creditsPushed = true;
        }

        if (GUI.Button(new Rect(Screen.width * horizontalButtonDisp - buttonWidth / 2, Screen.height * verticalButtonDisp + buttonHeight * 3 + 3 * spacing, buttonWidth, buttonHeight), "Quit"))
        {
            if (NoOtherButtonsPushed())
                pushedQuit = true;
        }

        if (pushedNewGame)
        {
            alpha = MenuFade.FadeOut(fadeOutSpeed, fadeTexture, alpha);
            if (alpha >= 1)
                Application.LoadLevel(newGameIndex);
        }

        if (creditsPushed)
        {
            alpha = MenuFade.FadeOut(fadeOutSpeed, fadeTexture, alpha);
            if (alpha >= 1)
                Application.LoadLevel(creditsIndex);
        }

        if (pushedQuit)
        {
            Application.Quit();
            pushedQuit = false;
        }
    }

    bool NoOtherButtonsPushed()
    {
        return !pushedNewGame && !pushedQuit && !creditsPushed;
    }





}
