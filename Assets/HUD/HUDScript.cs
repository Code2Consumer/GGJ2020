using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{

    private GameObject GameOverText;
	private GameObject planetHpScrollBarUI;
	private GameObject RetryTextButton;
	private GameObject ScoreText;

    private GameObject player;

	private int scoreTotal 			     = 0;
	
	// public float val = 0;

    // Start is called before the first frame update
    void Start()
    {
		GameOverText 			= GameObject.Find("GameOverText");
		RetryTextButton 		= GameObject.Find("RetryTextButton");
    	ScoreText 				= GameObject.Find("ScoreText");
        player                  = GameObject.Find("player");
        planetHpScrollBarUI     = GameObject.Find("planetHpScrollBarUI");
    	GameOverText.GetComponent<UnityEngine.UI.Text>().enabled = false;
    	RetryTextButton.GetComponent<UnityEngine.UI.Text>().enabled = false;

    	updatePlanetLife(1);
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
    }

    public void updateLifePoints(int lifePoint){

    }

    public void addPointsToScore(int points){
    	scoreTotal = scoreTotal + points;
    	updateScore();
    }

    public void updateScore(){
        if(player != null){
        	float score = player.GetComponent<PlayerScript>().getScore();
        	ScoreText.GetComponent<UnityEngine.UI.Text>().text = score+"";
            float planetHP          = player.GetComponent<PlayerScript>().getPlanetHp();
            float startingPlanetHp  = player.GetComponent<PlayerScript>().getStartingPlanetHp();
            updatePlanetLife(planetHP/startingPlanetHp);
            if(planetHP <= 0){
                gameOver();
            }
        } else {
            gameOver();
        }
    }

    public void gameOver(){
      //   GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playGameOver();

    	GameOverText.GetComponent<UnityEngine.UI.Text>().enabled = true;
    	RetryTextButton.GetComponent<UnityEngine.UI.Text>().enabled = true;
        Time.timeScale = 0.1f ;
    }

    public void retryAction(){
        Time.timeScale = 1;
    	Application.LoadLevel(Application.loadedLevel);
    }

    public void updatePlanetLife(float lifePercentage){
        lifePercentage  		= lifePercentage > 1 ? 1 : lifePercentage;
        planetHpScrollBarUI.GetComponent<UnityEngine.UI.Scrollbar>().size = lifePercentage;
	}
}
