using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackScript : MonoBehaviour
{  
    private Vector3 direction;
    private Vector3 rotation;
    private float h;
    private float v;	
    private float mainSpeed = 6;
    private float speed = 6;

    private float y  ;
    private bool activateParticle = false  ;

    void Start()
    {
    	
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
		v = Input.GetAxisRaw("Vertical");


        speed = 0 ;
            activateParticle = false;

        if(h!=0 || v != 0){
            Debug.Log("h : " + h );
            Debug.Log("v : " + v );
            if(h!=0 && v!=0){
                speed = mainSpeed * 0.75f;
            } else {
                speed = mainSpeed ;
            } 
        }

        y = 0;
        if (Input.GetButton("Jump"))
        {
            if(h!=0 && v!=0){
                speed = mainSpeed * 0.75f;
            } else {
                speed = mainSpeed ;
            } 

            Debug.Log("up");
            y = 1;
            activateParticle = true;

        }

        if (Input.GetKey("i"))
        {
            if(h!=0 && v!=0){
                speed = mainSpeed * 0.75f;
            } else {
                speed = mainSpeed ;
            } 

            Debug.Log("down");
            y = -1;        }

		if(speed != 0 || y != 0){
			direction = (new Vector3(h*speed, y*speed, v*speed) * Time.deltaTime * speed ) + transform.position;
		   	transform.position = Vector3.MoveTowards(transform.position, direction, speed );
		    
			rotation = new Vector3(
					h + transform.position.x,
					transform.position.y,
					v + transform.position.z
				);

			transform.LookAt(rotation);
        }

        if(y != 0){
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
        } else {
        }
    	
            GetComponent<ParticleSystem>().enableEmission = activateParticle;
        // if(activateParticle){
        //     GetComponent<ParticleSystem>().Play();
        // } else {
        //     GetComponent<ParticleSystem>().Stop();
        // }

    }
}