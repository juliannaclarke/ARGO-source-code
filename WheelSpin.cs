using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WheelSpin : MonoBehaviour
{
	public List<int> prize;
	public List<AnimationCurve> animationCurves;

	private bool spinning;
	private float anglePerItem;
	private int randomTime;
	private int itemNumber;

	public Vector2 startPos;
	public Vector2 direction;

	void Start()
	{
		spinning = false;
		anglePerItem = 360 / prize.Count;
	}

    IEnumerator SpinTheWheel(float time, float maxAngle)
    {
        spinning = true;

        float timer = 0.0f;
        float startAngle = transform.eulerAngles.z;
        maxAngle = maxAngle - startAngle;

        int animationCurveNumber = Random.Range(0, animationCurves.Count);
        Debug.Log("Animation Curve No. : " + animationCurveNumber);

        while (timer < time)
        {
            //to calculate rotation
            float angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return 0;
        }

        transform.eulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);
        spinning = false;

        Debug.Log("Prize: " + prize[itemNumber]);
    }

    void Update()
    {
        Touch touch = Input.GetTouch(0);


        if (Input.touchCount > 0)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began: //when the touch is first detected, position is recorded
                    startPos = touch.position;
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;

                    if (!spinning && direction.y < startPos.y) //not spinning and has been swiped down
                    {

                        randomTime = Random.Range(1, 4);
                        itemNumber = Random.Range(0, prize.Count);
                        float maxAngle = 360 * randomTime + (itemNumber * anglePerItem);

                        StartCoroutine(SpinTheWheel(5 * randomTime, maxAngle));
                    }
                    break;
            }
        }

    }
}