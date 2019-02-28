using System.Collections;
using UnityEngine;

public class balloon_move : MonoBehaviour
{
	public Transform[] pumpkintarget;
	public float speed;
	private int current;
	private float desiredRot;
	public float rotSpeed = 250;
	public float damping = 10;

	void Update() {
		desiredRot += rotSpeed * Time.deltaTime;
		if(transform.position != pumpkintarget[current].position)
		{
			Vector3 pos = Vector3.MoveTowards (transform.position, pumpkintarget [current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody>().MovePosition(pos);


		}
		else{
			//transform.Rotate(0, 90, 0);
			current = (current+1)%pumpkintarget.Length;
		}
	}
}
