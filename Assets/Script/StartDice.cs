using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDice : MonoBehaviour {
    public GameObject cv;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clickBtn()
    {
        Time.timeScale = 1;
        cv.SetActive(false);
        
    }
}
