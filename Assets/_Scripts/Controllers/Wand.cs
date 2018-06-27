using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CastWand();
	}

    void CastWand()
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo) && hitInfo.transform.tag == "Spirit")
        {
            Debug.Log("HIT: " + hitInfo.transform.name);
            Spirit spirit = hitInfo.transform.GetComponent<Spirit>();
            spirit.CaptureSpirit();
        }
        else
        {
            Debug.Log("NO HITS");
        }
    }
}
