using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccShake : MonoBehaviour {
	
	public GameObject King;
	public GameObject bar;
    public Sprite myFirstImage; 
	public Sprite mySecondImage; 
	float m=0.1f;

	Vector2 accelerationDir;

	public void SetImage1(){
		King.GetComponent<SpriteRenderer>().sprite= myFirstImage;
	}
	public void SetImage2(){
		King.GetComponent<SpriteRenderer>().sprite= mySecondImage;
	}

	void Update(){
		accelerationDir = Input.acceleration;
		if (accelerationDir.sqrMagnitude < 30f && accelerationDir.sqrMagnitude > 15f) {
			SetImage1 ();
		}
		if (strengthBar.isWin==1) {
			SetImage2 ();	
		}
		//TODO:change isWin expression when we have more tasks
	}

}


