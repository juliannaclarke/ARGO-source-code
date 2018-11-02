using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Tap : MonoBehaviour
{
    [SerializeField]
    ToggleEvent onToggleNextS;
	public GameObject parent;
	public GameObject obj;
    public GameObject stats;
    public static Vector2 touchPos;
    private int randCounter = 0;
	private int randCSpeed=30;
    public int currentScore=0;
	private float opaque=1f;
	public GameObject view;
	Camera cam;

    void Start()
    {
		cam = view.GetComponent<Camera> ();
    }

    void moveRandom()
    {
		 obj.transform.localPosition = new Vector3(Random.Range(-1, 3), Random.Range(-3, 3), 0);
    }

    void Update()
    {
		if (obj == null) {
			obj = GameObject.FindWithTag ("kingFist");
			if(opaque>0)
				opaque -= 0.3f;
			obj.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, opaque);
			Debug.Log (obj.GetComponent<SpriteRenderer> ().color);
		}

       
		randCounter++;
		if (randCounter % randCSpeed == 0)
        moveRandom();
		
        int i = 0;
        while (i < Input.touchCount)
        {
            
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
//                if (preScore < currentScore)
//                {
//                    
//                    preScore++;
//                }
                touchPos = touch.position;
                //Vector3 p = new Vector3(touchPos.x, touchPos.y, 1);
				Vector3 p = cam.ScreenToWorldPoint(touchPos);
				//new Vector3(touchPos.x, touchPos.y, 1);

                Debug.Log(p);
				Debug.Log("obj:" +  obj.transform.position);

				if (p.x <  obj.transform.position.x + 0.4 && p.x >  obj.transform.position.x - 0.4 && p.y >  obj.transform.position.y - 0.4 && p.y <  obj.transform.position.y + 0.4)
                {
                   
					Destroy (obj);
					Instantiate (obj, new Vector3 (Random.Range (0, 3), Random.Range (-4,4), 0), Quaternion.identity, parent.GetComponent<Transform>());
					currentScore++;
					if (randCSpeed > 5)
						randCSpeed -= 8;
					else if (randCSpeed > 1)
						randCSpeed -= 2;
					stats.GetComponent<Text>().text = currentScore.ToString();
                }
            
            }
            ++i;
        }

        //if (currentScore == 1) onToggleNextS.Invoke(true);

    }
}
