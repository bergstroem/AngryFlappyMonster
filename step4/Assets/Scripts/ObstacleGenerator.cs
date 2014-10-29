using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(Transform))]
public class ObstacleGenerator : MonoBehaviour {
	public Transform obstacleParent;

	// Prefabs
	public List<GameObject> obstacles;
	public List<GameObject> destructibles;

	private float _creationInterval = 8.0f;
	private float _currentCreationPosition = 0.0f;
	private float _creationOffset = 30.0f;

	private List<GameObject> _oldObstacles;

	// Use this for initialization
	void Start () {
		_oldObstacles = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x - _currentCreationPosition > 0) {
			_currentCreationPosition += _creationInterval;
			
			float random = Random.value;
			
			if(random > 0.2f) {
				CreateRandomObstacle(obstacles, 0);
			} else {
				CreateRandomObstacle(destructibles, 2);
			}
			
			RemoveOldObstacles();
		}
	}

	void CreateRandomObstacle(List<GameObject> objects, float yPosition) {
		int index = Mathf.FloorToInt(Random.value * objects.Count);
		Vector3 position = new Vector3 (_currentCreationPosition + _creationOffset, yPosition, 0);
		var obstacle = Instantiate (objects [index], position, Quaternion.identity) as GameObject;
		obstacle.transform.parent = obstacleParent;
		_oldObstacles.Add(obstacle);
	}
	
	void RemoveOldObstacles() {
		if (_oldObstacles.Count > 8) {
			Destroy(_oldObstacles[0]);
			_oldObstacles.RemoveAt(0);
		}
	}
}
