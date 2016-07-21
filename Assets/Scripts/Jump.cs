using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    private Rigidbody2D MyRigidBody;
    private Animator MyAnim;
    public float BunnyJumpForce = 500f;

	// Use this for initialization
	void Start () {
        MyRigidBody = GetComponent<Rigidbody2D>();
        MyAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Jump"))
        {
            MyRigidBody.AddForce(transform.up * BunnyJumpForce);
        }

        MyAnim.SetFloat("vVelocity", MyRigidBody.velocity.y);
	}
}
