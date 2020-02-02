using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
	private GameObject player;
    public float damping = 1;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
    	player = GameObject.Find("player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    	if(player != null){
	    	transform.position = new Vector3(
	    			player.transform.position.x,
	    			player.transform.position.y+5,
	    			player.transform.position.z-5
	    		); 
		   // Vector3 desiredPosition = player.transform.position + offset;
	       // Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
	       // transform.position = position;
	 //
	        transform.LookAt(player.transform.position);
    	} else if(player == null){
    		Debug.Log("////// WARNING //////");
    		Debug.Log("The player GameObject name was not set properly in MainCameraScript.");
    		Debug.Log("////// WARNING //////");    	
    	}
    }
}
