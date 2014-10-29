using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float jumpForce;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			this.rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
	}

	void FixedUpdate() {
		if (this.rigidbody2D.velocity.x < speed) {
			this.rigidbody2D.AddForce(Vector2.right * 100);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.tag == "Deadly") {
			Application.LoadLevel(0);
		}
	}
}
