using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

    float jumpForce = 200f;
    float forwardSpeed = 2f;
    bool dead = false;
    Rigidbody2D rb;
    public GameObject cam;

	// Use this for initialization
	void Start () {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {
        if (dead == false) { 
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);
            }
            rb.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
            cam.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
        }
        if (rb.transform.position.x >= 40)
        {
            dead = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dead = true;
        cam.transform.Translate(new Vector3(0, 0, 0) * forwardSpeed * Time.deltaTime);
    }
}
