using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptBarToResolution : MonoBehaviour {

    public Camera m_Camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float ratio = (float)Screen.width / Screen.height;
        transform.position = Vector2.up * m_Camera.orthographicSize * ratio;
	}
}
