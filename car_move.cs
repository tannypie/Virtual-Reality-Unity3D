using System.Collections;
using UnityEngine;

public class car_move : MonoBehaviour
{
	public Transform[] target;
	public float speed;
	private int current;
	private float desiredRot;
	public float rotSpeed = 250;
	public float damping = 10;

	void Update() {
		desiredRot += rotSpeed * Time.deltaTime;
		if(transform.position != target[current].position)
		{
			Vector3 pos = Vector3.MoveTowards (transform.position, target [current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody>().MovePosition(pos);
			

}
		else{
			//transform.Rotate(0, 90 , 0);
			//transform.Rotate(Vector3.up, 500*Time.deltaTime);


			StartCoroutine( Rotate(Vector3.up, 90, 1.0f) );
			current = (current+1)%target.Length;
//			var desiredRotQ = Quaternion.Euler(0,90, 0);
//			transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
	}



}


	IEnumerator Rotate( Vector3 axis, float angle, float duration = 1.0f)
	{
		Quaternion from = transform.rotation;
		Quaternion to = transform.rotation;
		to *= Quaternion.Euler( axis * angle );

		float elapsed = 0.0f;
		while( elapsed < duration )
		{
			transform.rotation = Quaternion.Slerp(from, to, elapsed / duration );
			elapsed += Time.deltaTime;
			yield return null;
		}
		transform.rotation = to;
	}
}



//
//private float desiredRot;
//public float rotSpeed = 250;
//public float damping = 10;
//
//private void OnEnable() {
//	desiredRot = transform.eulerAngles.z;
//}
//
//private void Update() {
//	if (Input.GetMouseButton(0)) {
//		if (Input.mousePosition.x > Screen.width / 2) desiredRot -= rotSpeed * Time.deltaTime;
//		else desiredRot += rotSpeed * Time.deltaTime;
//	}
//
//	var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, desiredRot);
//	transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
//}
