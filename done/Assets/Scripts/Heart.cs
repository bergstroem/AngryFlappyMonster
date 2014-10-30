using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]
public class Heart : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag.Equals("Character")) {
			GameObject.Find("Character").GetComponent<Character>().AddLife();
			gameObject.SetActive(false);
		}
	}
}
