using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public bool alive;
    [SerializeField]
    private GameObject pickupPreFab;

	// Use this for initialization
	void Start () {
        alive = true;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && alive)
        {
            alive = false;
            Instantiate(pickupPreFab, transform.position, Quaternion.identity);
        }
    }
}
