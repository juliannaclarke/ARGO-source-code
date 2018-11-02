using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown : MonoBehaviour {
	public float speed = .1f; 
	public float addSpeed=0.005f;
//	public float countdown = 3.0f;
	public GameObject moveObject;

	void Update ()
	{
//		countdown -= Time.deltaTime;
//		if(countdown <= 0.0f)
//			light.enabled = true;

//		if(Input.GetKey(KeyCode.RightArrow))
		moveObject.transform.localPosition += new Vector3(0.0f, (-1f)*speed * Time.deltaTime, 0.0f);
		speed += addSpeed;
	
	}   
}
