using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;


public class taskSwitch : MonoBehaviour {
    public GameObject timer;
    [SerializeField] ToggleEvent onToggleNext;

	
	// Update is called once per frame
	void Update () {
        if (timer.GetComponent<Text>().text == "00:00")
        {
            onToggleNext.Invoke(true);
        }
    }
}
