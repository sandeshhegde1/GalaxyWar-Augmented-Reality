using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour {

	public AudioClip explosionClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//for this to work both need colliders, one must have rigid body (spaceship) the other must have is trigger checked.
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.CompareTag("Player")){
			
			GameObject explosion = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
			explosion.transform.position = transform.position;
			Destroy(col.gameObject);
			Destroy (explosion, 2);
			AudioSource.PlayClipAtPoint (explosionClip,col.transform.position);


			//if all the enemy ships are destroyed, then instantiate them again.
			if (GameObject.FindGameObjectsWithTag("Player").Length == 0){

				GameObject enemy1 = Instantiate(Resources.Load("enemy1", typeof(GameObject))) as GameObject;
				GameObject enemy2 = Instantiate(Resources.Load("enemy2", typeof(GameObject))) as GameObject;
				GameObject enemy3 = Instantiate(Resources.Load("enemy3", typeof(GameObject))) as GameObject;
				GameObject enemy4 = Instantiate(Resources.Load("enemy4", typeof(GameObject))) as GameObject;

			}

			//destroy the bullet
			Destroy (gameObject);

		}


	}
}
