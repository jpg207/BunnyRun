using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jump : MonoBehaviour {

    private Rigidbody2D MyRigidBody;
    private Animator MyAnim;
    public float BunnyJumpForce = 500f;
    private float BunnyHurtTime = -1;
    private Collider2D MyCollider;
    public Text ScoreText;
    private float StartTime;

	// Use this for initialization
	void Start () {
        MyRigidBody = GetComponent<Rigidbody2D>();
        MyAnim = GetComponent<Animator>();
        MyCollider = GetComponent<Collider2D>();
        StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (BunnyHurtTime == -1)
        {

            if (Input.GetButtonUp("Jump"))
            {
                MyRigidBody.AddForce(transform.up * BunnyJumpForce);
            }

            MyAnim.SetFloat("vVelocity", MyRigidBody.velocity.y);
            ScoreText.text = (Time.time - StartTime).ToString("0.0");
        }
        else
        {
            if (Time.time > BunnyHurtTime + 2)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            foreach (Moveleft movelefter in FindObjectsOfType<Moveleft>())
            {
                movelefter.enabled = false;
            }

            foreach (Prefab_Spawner spawner in FindObjectsOfType<Prefab_Spawner>())
            {
                spawner.enabled = false;
            }

            BunnyHurtTime = Time.time;
            MyAnim.SetBool("BunnyHurt", true);
            MyRigidBody.velocity = Vector2.zero;
            MyRigidBody.AddForce(transform.up * BunnyJumpForce);
            MyCollider.enabled = false;
        }
    }
}
