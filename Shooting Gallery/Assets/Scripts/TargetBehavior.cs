using System.Collections;
using UnityEngine;

public class TargetBehavior : MonoBehaviour {

	private bool beenHit = false;
	private Animator animator;
	private GameObject parent;
	private bool activated;
	private Vector3 originalPos;
	public bool isBonus = false;
	public int targetType = 1;


	public static float moveSpeed = 1.0f; //Speed in the X axis 
	public float frequency = 5.0f; //Speed of the Sine movement
	public float magnitude = 0.1f; //Size of the Sine movement

	void Start () {
		GameController._instance.targets.Add (this);

		parent = transform.parent.gameObject;
		animator = parent.GetComponent<Animator> ();
		//ShowTarget ();
		originalPos = parent.transform.position;

	}

	public void ShowTarget() {
		if(!activated) {
			activated = true;
			beenHit = false;
			animator.Play ("Idle");

			iTween.MoveBy (parent, iTween.Hash ("y", 1.6f, "easeType", "easeInOutExpo", "time", 0.5f,
				"oncomplete", "OnShown","onCompletetarget", gameObject));
		}
	}
		
	//The object must have a collider for the following to work.
<<<<<<< HEAD
	void OnMouseDown() {
		if(!beenHit && activated) {
=======
	void OnMouseDown(){
		if(!beenHit && activated) 
		{
>>>>>>> Sam-Branch
			GameController._instance.IncreaseScore ();

			if (isBonus == true) 
			{
				GameController._instance.IncreaseTime();
			}

			beenHit = true;
			if (targetType == 1) {
				animator.Play ("Flip");
			}

			else if (targetType == 2)
			{
				animator.Play ("Flip2");
			}

			else if (targetType == 3)
			{
				animator.Play ("Flip 3");
			}

			StopAllCoroutines ();
			StartCoroutine (HideTarget ());
			StopAllCoroutines ();
			StartCoroutine (HideTarget ());




		}
	}

	IEnumerator HideTarget() {
		yield return new WaitForSeconds (0.5f);

		//Move the target back to it's original spot.
		iTween.MoveBy (parent.gameObject, iTween.Hash ("y", (originalPos.y - parent.transform.position.y), 
			"easeType", "easeOutQuad", "loopType", "none", "time", 0.5f, "oncomplete", "OnHidden", "onCompletetarget", gameObject));
	}

	//After the tween finishes, make it show again using this method.
	void OnHidden() {
		parent.transform.position = originalPos;
		activated = false;
	}

	void OnShown() { 
		StartCoroutine ("MoveTarget");		
	}
		
	IEnumerator MoveTarget() {
		var relativeEndPos = parent.transform.position;

		//Is the target facing left or right?
		if (transform.eulerAngles == Vector3.zero) {
			//If going right, then its positive
			relativeEndPos.x = 8;
		} else {
			//going left, negative
			relativeEndPos.x = -8;
		}

		var movementTime = Vector3.Distance (parent.transform.position, relativeEndPos) * moveSpeed;
		var pos = parent.transform.position;
		var time = 0f;

		while (time < movementTime) {
			time += Time.deltaTime;

			pos += parent.transform.right * Time.deltaTime * moveSpeed;
			parent.transform.position = pos + (parent.transform.up * Mathf.Sin (Time.time * frequency) * magnitude);

			yield return new WaitForSeconds (0);
		}

		StartCoroutine (HideTarget ());
	}
		
}