using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class swipe : MonoBehaviour {
	public GameObject swipeObject;
	private Vector3 fp;   //First touch position
	private Vector3 lp;   //Last touch position
	public int speed;

	private float dragDistance;  //minimum distance for a swipe to be registered


	void Start()
	{
		speed = 800;
		dragDistance = Screen.height * 5 / 100; //dragDistance is 15% height of the screen
	}

	void Update()
	{
		
		if(Input.touchCount==1) // user is touching the screen with a single touch
		{
			
			Touch touch = Input.GetTouch(0); // get the touch
			if (touch.phase == TouchPhase.Began) //check for the first touch
			{
				fp = touch.position;
				lp = touch.position;


			}
			else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
			{
				lp = touch.position;
				//Check if drag distance is greater than 20% of the screen height
				if (Mathf.Abs(lp.y - fp.y) > dragDistance)
				{//It's a drag
					//check if the drag is vertical or horizontal
					if (Mathf.Abs(lp.x - fp.x) < Mathf.Abs(lp.y - fp.y)&&(lp.y - fp.y)>0)
					{  
						swipeObject.transform.localPosition+=new Vector3(0,(lp.y - fp.y)/speed,0);

					}


				}

			}
			else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
			{
				lp = touch.position;  //last touch position. Ommitted if you use list
				Debug.Log (lp.y - fp.y);

			}
		}
	}

}
