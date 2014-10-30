using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float jumpForce;
	public float speed;
	public UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Text lifeText;
	public int maxLife = 3;

	private int _score;
	private int _life;

	// Use this for initialization
	void Start () {
		_life = 0;
		UpdateLifeText();
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

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "ScoreTrigger") {
			IncreaseScore();
		}
	}

	public void IncreaseScore() {
		_score++;
		scoreText.text = _score.ToString();
	}

	void UpdateLifeText() {
		lifeText.text = _life.ToString();
	}

	public void AddLife() {
		if(_life < maxLife) {
			_life++;
			UpdateLifeText();
		}
	}
}
