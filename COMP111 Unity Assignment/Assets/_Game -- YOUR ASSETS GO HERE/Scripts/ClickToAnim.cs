using UnityEngine;
using System.Collections;

public class ClickToAnim : MonoBehaviour {

	public Animator animator;
	public string lookAtTriggerName = "LookAt";
	public string lookAwayTriggerName = "LookAway";
	public string lookingAtBoolName = "LookingAt";

	public string mouseDownTriggerName = "MouseDown";
	public string mouseUpTriggerName = "MouseUp";
	public string mouseDragBoolName = "MouseDrag";
	private bool isMouseOver = false;
	private bool isMouseDrag = false;
	private new Camera camera;

	void Update () {

		 RaycastHit hitInfo;

		 Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
 		if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject == gameObject) {
 			if (!isMouseOver) {
				animator.SetTrigger(lookAtTriggerName);
	 			isMouseOver = true;
 			}

 			if (Input.GetMouseButtonDown(0)) {
				animator.SetTrigger(mouseDownTriggerName);
				isMouseDrag = true;
 			}


 		}
 		else {
 			if (isMouseOver) {
				animator.SetTrigger(lookAwayTriggerName);
	 			isMouseOver = false;
 			}
 		}

		if (Input.GetMouseButtonUp(0) && isMouseDrag) {
			animator.SetTrigger(mouseUpTriggerName);
			isMouseDrag = false;
 		}

		animator.SetBool(lookingAtBoolName, isMouseOver);
		animator.SetBool(mouseDragBoolName, isMouseDrag);

	}

}
