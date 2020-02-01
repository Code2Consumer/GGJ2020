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

    void Start()
    {
    	
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
		v = Input.GetAxisRaw("Vertical");

    	speed = 0 ;

		if(h!=0 || v != 0){
			if(h!=0 && v!=0){
				speed = mainSpeed * 0.75f;
			} else {
				speed = mainSpeed ;
			} 
		}

		if(speed != 0){
			direction = (new Vector3(h*speed, 0, v*speed) * Time.deltaTime * speed ) + transform.position;
		   	transform.position = Vector3.MoveTowards(transform.position, direction, speed );
		    //Vector3 position = Vector3.Lerp(transform.position, new Vector3(direction.x*2, transform.position.y, direction.z*2), Time.deltaTime * 0.5f);
		    
			rotation = new Vector3(
					h + transform.position.x,
					transform.position.y,
					v + transform.position.z
				);

			transform.LookAt(rotation);
		}
	 

    }

    void FixedUpdate()
    {

        // if (isMoving)
        // {
        //     // when the cube has moved for 10 seconds, report its position
        //     time = time + Time.fixedDeltaTime;
        //     if (time > 10.0f)
        //     {
        //         Debug.Log(gameObject.transform.position.y + " : " + time);
        //         time = 0.0f;
        //     }
        // }
    }
}