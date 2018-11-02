using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class Tilt: MonoBehaviour {
    [SerializeField]
    ToggleEvent onToggleNextS;
    float speed = 3F;
	Rigidbody rb;
    private float minX, maxX, minY, maxY,currentScore;
    public GameObject score;
	public GameObject target;


	void Start(){
        currentScore = 0;
  
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = true;

//        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
//        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
//        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
//
//        minX = bottomCorner.x;
//        maxX = topCorner.x;
//        minY = bottomCorner.y;
//        maxY = topCorner.y;
    }

	void Update (){
		Vector3 acc = Input.acceleration;
        Vector3 pos = transform.position; //verify code
//        if(pos.x > minX&& pos.x< maxX&& pos.y> minY&& pos.y <maxY)
            //rb.AddForce(acc.x * speed, acc.y * speed, 0);
		transform.localPosition=new Vector3(acc.x * speed* Time.deltaTime, acc.y * speed* Time.deltaTime, 0);
        

		// Horizontal contraint
        //if (pos.x < minX) pos.x = minX;
        //if (pos.x > maxX) pos.x = maxX;

        // vertical contraint
        //if (pos.y < minY) pos.y = minY;
        //if (pos.y > maxY) pos.y = maxY;

        // Update position
        //transform.position = pos;


		if (transform.position.x>target.transform.position.x-0.5&& transform.position.x<target.transform.position.x+0.5&& transform.position.y>target.transform.position.y-0.5&& transform.position.y < target.transform.position.y+0.5)
        {
            currentScore++;
            score.GetComponent<Text>().text = currentScore.ToString();
        }
        if(currentScore>=5) onToggleNextS.Invoke(true);

    }
   

	}

