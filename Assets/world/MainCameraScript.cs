using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
	private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    	player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
    	if(player != null){
	    	transform.position = new Vector3(
	    			player.transform.position.x,
	    			player.transform.position.y+50,
	    			player.transform.position.z
	    		); 
    	} else if(player == null){
    		Debug.Log("////// WARNING //////");
    		Debug.Log("The player GameObject name was not set properly in MainCameraScript.");
    		Debug.Log("////// WARNING //////");    	
    	}
    }
}
