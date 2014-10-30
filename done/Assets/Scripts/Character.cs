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
	private Animator _animator;
	private ParticleSystem _particleSystem;
	
	// Use this for initialization
	void Start () {
		_particleSystem = GetComponent<ParticleSystem>();
		_animator = GetComponent<Animator> ();
		_life = maxLife;
		UpdateLifeText();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			this.rigidbody2D.AddForce(Vector2.up * jumpForce);
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
			if (_life > 1) { 
				_animator.SetTrigger("Damage");
			}
			else {
				_animator.SetTrigger("Die");
			}
			RemoveLife ();
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "ScoreTrigger") {
			IncreaseScore();
		}
	}
	
	public void StartParticleSystem() {
		_particleSystem.Play();
	}
	
	public void RestartLevel() {
		Application.LoadLevel(0);
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

	public void RemoveLife() {
		_life--;
		UpdateLifeText();
	}
}

