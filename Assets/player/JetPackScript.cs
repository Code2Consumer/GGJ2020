using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackScript : MonoBehaviour
{  
    private Vector3 direction;
    private Vector3 rotation;
    private float h;
    private float v;	
    private float speed = 3;

    void Start()
    {
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
		v = Input.GetAxisRaw("Vertical");

		if(h!=0 || v != 0){
			direction = (new Vector3(h*speed, 0, v*speed) * Time.deltaTime * speed ) + transform.position;
		   	transform.position = Vector3.MoveTowards(transform.position, direction, speed );

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