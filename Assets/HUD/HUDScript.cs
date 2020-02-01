﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{

	private GameObject GameOverText;
	private GameObject RetryTextButton;
	private GameObject ScoreText;

	private int scoreTotal 			     = 0;
	
	// public float val = 0;

    // Start is called before the first frame update
    void Start()
    {
		GameOverText 			= GameObject.Find("GameOverText");
		RetryTextButton 		= GameObject.Find("RetryTextButton");
    	ScoreText 				= GameObject.Find("ScoreText");

    	GameOverText.GetComponent<UnityEngine.UI.Text>().enabled = false;
    	RetryTextButton.GetComponent<UnityEngine.UI.Text>().enabled = false;

    	updateRageBar(0);
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
    	// updateRageBar(0.3f);
    }

    public void updateLifePoints(int lifePoint){

    }

    public void addPointsToScore(int points){
    	scoreTotal = scoreTotal + points;
    	updateScore();
    }

    public void updateScore(){
    	float score = GameObject.Find("player").GetComponent<PlayerScript>().getScore();
    	ScoreText.GetComponent<UnityEngine.UI.Text>().text = score+"";

        // float scoreDejaUtilisee = GameObject.Find("Chevalier").GetComponent<Chevalier_Deplacement>().scoreDejaUtilise;
    	// float scorePercenage = ( (score-scoreDejaUtilisee) / GameObject.Find("Chevalier").GetComponent<Chevalier_Deplacement>().scorePerEnemyKilled ) / 
    	// GameObject.Find("Chevalier").GetComponent<Chevalier_Deplacement>().enemyNecessairePourFullRage;
    	// updateRageBar(scorePercenage);
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

    public void updateRageBar(float ragePercentage){
    //	ragePercentage  		= ragePercentage > 1 ? 1 : ragePercentage;
    // RageBarScrollBarUI.GetComponent<UnityEngine.UI.Scrollbar>().size = ragePercentage;
	}
}
