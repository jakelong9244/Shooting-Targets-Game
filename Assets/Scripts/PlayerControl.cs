using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public float height;
    private Vector3 jump = new Vector3(0.0f, 1.0f, 0.0f);
    private bool touching;
    private bool boosted = false;
    private int counter;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate () {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.AddForce(speed*movement);

       

        if (Input.GetKeyDown("space") && touching == true) {
            rb.AddForce(jump * height, ForceMode.Impulse);
        }
    }

    void LateUpdate() {
        if (boosted) {
            counter += 1;
            if (counter >= 1000) {
                speed -= 50;
                boosted = false;
                counter = 0;
            }   
        }           
    }

    //Check if Ball is touching object    
    void OnCollisionStay() {      
        touching = true;
    }

    //Check if Ball is no longer touching anything
    void OnCollisionExit() {
        touching = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            speed += 50;
            boosted = true;
            counter = 0;
        }
    }
    
    
}