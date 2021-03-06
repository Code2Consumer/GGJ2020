﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis; //If you need this, use it
    private Vector3 _randomPosition;
    private Vector3[] spawnPositions = {
            new Vector3(-132, 7, 37),
            new Vector3(-43, 7, 153),
            new Vector3(64, 7, 23)
        };
    public bool spawner;
    private int nbSpawner = 3;

    public int smashCount = 10;

    private int t = 0;

    private bool isFirering = false;

    public string textUiString = "Bravos ! Sa n'avait rien à faire ici !";

    private GameObject player ;
    private GameObject textUI ;
    // Start is called before the first frame update
    private void Start()
    {
        textUI = GameObject.Find("user_message_text");
        SetRanges();
        InvokeRepeating("InstantiateRandomObjects", 1.0f, 5.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);
    }
    //Here put the ranges where your object will appear, or put it in the inspector.
    private void SetRanges()
    {
        Min = new Vector3(30, 0, -30); //Random value.
        Max = new Vector3(-7, 0, 3); //Another ramdon value, just for the example.
    }
    private void InstantiateRandomObjects()
    {
        if (spawner)
        {
           // Instantiate(gameObject, spawnPositions[Random.Range(0, spawnPositions.Count)], Quaternion.identity);
        }

    }

    void OnMouseDown()
    {
        InstantiateRandomObjects();
    }

    void OnTriggerStay(Collider other)
    {

        if (!isFirering && other.gameObject.tag == "Player" && Input.GetButton("Fire1"))
        {
            isFirering = true;
            if (gameObject.tag == "Type 2")
            {
                t++;
                Debug.Log("T =" + t + "%");
                if (t >= smashCount) {

                    Destroy(gameObject, 2);
                    Debug.Log("Smash Complete!");
                    t = 0;
                    player = other.gameObject;
                    if(player != null){
                        player.GetComponent<PlayerScript>().addScore();
                    }
                };

            }
            else if (gameObject.tag == "Art")
            {
                Debug.Log("colision");
                afficheText();
                Destroy(gameObject, 2);
                //cacherText();
                player = other.gameObject;
                if (player != null) player.GetComponent<PlayerScript>().addScore();
                Debug.Log("Destruction");
            }
            else
            {
                Debug.Log("colision");
                afficheText();
                Destroy(gameObject, 2);
                //cacherText();
                player = other.gameObject;
                if (player != null) player.GetComponent<PlayerScript>().addScore();
                Debug.Log("Destruction");
            }
            
        } else if ( isFirering && !(other.gameObject.tag == "Player" && Input.GetButton("Fire1")) ){
            isFirering = false;
        }
    }

    void afficheText() {
        textUI
        .GetComponent<UnityEngine.UI.Text>()
        .text = textUiString;
    }

    void cacherText() {
        textUI
        .GetComponent<UnityEngine.UI.Text>()
        .text = "";
    }

    void OnDestroy()
    {
        cacherText();
    }
}
