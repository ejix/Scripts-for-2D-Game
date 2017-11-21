using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {

    BoxCounter boxCounter;
	void Start () {
        boxCounter = GameObject.Find("Manager").GetComponent<BoxCounter>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            boxCounter.IncrementCounter();
        }
    }
}
