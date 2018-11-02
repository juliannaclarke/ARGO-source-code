using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour {

	public GameObject scaleObject;
	private float scaleSize;

	// Use this for initialization
	void Start () {
		scaleSize = 0.05f;
		
	}
	
	// Update is called once per frame
	void Update () {
		scaleObject.transform.localScale += new Vector3 (scaleSize * Time.deltaTime, scaleSize* Time.deltaTime, 1f);
	}
}
