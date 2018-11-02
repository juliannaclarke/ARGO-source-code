using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camGyro: MonoBehaviour {
	GameObject camParent;
	private bool isTrigger;
	private float direction;
	// Use this for initialization
	void Start () {
		isTrigger = false;
		camParent=new GameObject("CamParent");
		camParent.transform.position = this.transform.position;
		this.transform.parent = camParent.transform;
		Input.gyro.enabled = true;
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="boundry")
			isTrigger = true;
		Debug.Log ("trigger!");
	}
	// Update is called once per frame
	void Update () {
		if (!isTrigger) {
			camParent.transform.Translate (-Input.gyro.rotationRateUnbiased.y,0, 0);
			direction = Input.gyro.rotationRateUnbiased.y;
//			this.GetComponent<BoxCollider2D> ().offset =new Vector2 (camParent.transform.position.x,camParent.transform.position.y);
			this.transform.Rotate (0, 0, 0);

		}else 
		{
			isTrigger = false;
			if(Input.gyro.rotationRateUnbiased.y*direction>0)
				camParent.transform.Translate (Input.gyro.rotationRateUnbiased.y*5,0, 0);
			else
				camParent.transform.Translate (-Input.gyro.rotationRateUnbiased.y,0, 0);
			
		}

	}
}
