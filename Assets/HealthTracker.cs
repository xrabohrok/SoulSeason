using UnityEngine;
using System.Collections;

public class HealthTracker : MonoBehaviour {

    public int maxHealth = 3;
    public Texture2D haveHeart;
    public Texture2D missingHeart;
    public float heartScale = 1;
    public Texture2D GameOverTexture;
    public float spacing = 3f;
    public float vspacing = 3f;

    private int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        Rect carrotPlace = new Rect(spacing, vspacing, haveHeart.width * heartScale, haveHeart.height * heartScale);
        for(int i = 0; i < maxHealth; i++)
        {
            carrotPlace = new Rect(carrotPlace.left + carrotPlace.width + spacing, carrotPlace.top, carrotPlace.width, carrotPlace.height);
            
            if(i < currentHealth)
            GUI.DrawTexture(carrotPlace, haveHeart);
            else
            GUI.DrawTexture(carrotPlace, missingHeart);

        }
    }
}
