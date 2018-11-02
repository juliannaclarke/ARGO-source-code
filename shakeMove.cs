using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeMove : MonoBehaviour {
		
	public float speed = 1f;
	private float scaleSize=0.8f;

		void Update() {
		Vector3 dir = Vector3.zero;
		dir.y = Input.acceleration.y;
		dir.x = Input.acceleration.x;
//			if (dir.sqrMagnitude > 1)
//				dir.Normalize();
			
		Debug.Log (dir.sqrMagnitude);
		if (dir.sqrMagnitude > 10f) {
			dir *= Time.deltaTime;
			transform.localPosition = dir * speed;
			if(scaleSize>0.1f)
				scaleSize -= 0.05f;
			if(transform.localScale.x>0)
				transform.localScale -= new Vector3 (scaleSize * Time.deltaTime, scaleSize * Time.deltaTime, 1f);
		}
	}
}