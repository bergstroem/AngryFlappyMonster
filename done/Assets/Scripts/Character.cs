using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float jumpForce;
	public float speed;
	public UnityEngine.UI.Text scoreText;

	private int _score;
	private Animator _animator;
	private ParticleSystem _particleSystem;

	// Use this for initialization
	void Start () {
		_particleSystem = GetComponent<ParticleSystem>();
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			this.rigidbody2D.AddForce(Vector2.up * jumpForce);
			this.audio.Play();
			_animator.SetTrigger("Fly");
		}
	}

	void FixedUpdate() {
		if (this.rigidbody2D.velocity.x < speed) {
			this.rigidbody2D.AddForce(Vector2.right * 100);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.gameObject.tag == "Deadly") {
			_animator.SetTrigger("Die");
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

	public void StartParticleSystem() {
		_particleSystem.Play();
	}

	public void RestartLevel() {
		Application.LoadLevel(0);
	}
}
