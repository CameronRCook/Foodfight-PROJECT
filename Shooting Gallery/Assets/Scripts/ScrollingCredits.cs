using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingCredits : MonoBehaviour {

	public float scrollSpeed = 1f;
	float posY = -691;


	void FixedUpdate () 
	{
		transform.position = new Vector3 (transform.position.x, posY + scrollSpeed, transform.position.z) ;

	}
}
