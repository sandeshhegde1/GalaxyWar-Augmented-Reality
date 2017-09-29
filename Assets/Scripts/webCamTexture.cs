using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webCamTexture : MonoBehaviour {

	public GameObject webCamPlane;
	public Button fireButton;
	// Use this for initialization
	void Start () {

		if (Application.isMobilePlatform) {
			GameObject cameraParent = new GameObject ("camParent");
			cameraParent.transform.position = this.transform.position;
			this.transform.parent = cameraParent.transform;
			cameraParent.transform.Rotate (Vector3.right, 90);
		}

		Input.gyro.enabled = true;

		fireButton.onClick.AddListener (OnFireButtonClick);

		WebCamTexture webCamTexture = new WebCamTexture ();
		webCamPlane.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
		webCamTexture.Play ();
	}

	void OnFireButtonClick(){

		GameObject bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
		Rigidbody rb = bullet.GetComponent<Rigidbody>();
		bullet.transform.rotation = Camera.main.transform.rotation;
		bullet.transform.position = Camera.main.transform.position;
		rb.AddForce(Camera.main.transform.forward * 500f);
		GetComponent<AudioSource> ().Play ();
		Destroy (bullet, 3);



	}
	// Update is called once per frame
	void Update () {
		Quaternion cameraRotation = new Quaternion (Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
		this.transform.localRotation = cameraRotation;
	}
}
