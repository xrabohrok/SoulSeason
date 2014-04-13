using UnityEngine;
using System.Collections;

public class HealthTracker : MonoBehaviour {

    public int maxHealth = 5;
    public Texture2D haveHeart;
    public Texture2D missingHeart;
    public float heartScale = 1;
    public Texture2D GameOverTexture;
    public float spacing = 3f;
    public float vAlignment = .15f;
    public float vspacing = 3f;
	public bool winner = false;
    public int currentHealth;

	// Use this for initialization

	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(currentHealth <= 0)
		{
			Application.LoadLevel(2);
		}
	}

    void OnGUI()
    {
        Rect carrotPlace = new Rect(spacing, vspacing, haveHeart.width * heartScale, haveHeart.height * heartScale);
        for(int i = 0; i < maxHealth; i++)
        {
            carrotPlace = new Rect(carrotPlace.xMin + carrotPlace.width + spacing, vAlignment * Screen.height, carrotPlace.width, carrotPlace.height);
            
            if(i < currentHealth)
            GUI.DrawTexture(carrotPlace, haveHeart);
            else
            GUI.DrawTexture(carrotPlace, missingHeart);

        }
    }

    public int ChangeHealth(int healthChange)
	{
		if (healthChange > 0)
		{
			if (currentHealth < maxHealth){
			currentHealth += healthChange;
		}
		}
		if (healthChange < 0)
		{
			currentHealth += healthChange;
		}
		return currentHealth;
	}
}

