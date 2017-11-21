using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPlayer : MonoBehaviour {

    public GameObject hero;

    private Vector3 currentVelocity;
    public float smoothTime;


	void Start () {
		
	}

	void Update () {
        Vector3 newCameraPosition = new Vector3(hero.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currentVelocity, smoothTime);
	}
}
