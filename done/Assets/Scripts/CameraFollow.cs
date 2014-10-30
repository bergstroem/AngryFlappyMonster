using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.position;
		position.x = target.transform.position.x;
		this.transform.position = position;
	}
}