using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float eventReward = 12; 
    private float scrore = 0;

    public float startingPlanetHP = 100;
    private float planetHP = 100;
    public float nextActionTime = 5.0f;
    public float period = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playMusique();
        GameObject.Find("CustumSoundManager").GetComponent<CustumSoundManagerScript>().playStart();
        planetHP = startingPlanetHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            planetHP--;
        }
    }

    public float getScore(){
    	return scrore;
    }

    public void addScore(){
        scrore += eventReward;
    }
    public float getPlanetHp(){
        return planetHP;
    }
    public float getStartingPlanetHp(){
        return startingPlanetHP;
    }
}
