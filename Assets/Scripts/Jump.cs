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
    private int JumpsLeft = 2;
    public AudioSource JumpFX;
    public AudioSource DeathFX;
    public AudioSource BackgroundNorm;
    public AudioSource BackgroundFast;

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

            if (Input.GetButtonUp("Jump") && JumpsLeft > 0)
            {
                if(MyRigidBody.velocity.y < 0)
                {
                    MyRigidBody.velocity = Vector2.zero;
                }

                MyRigidBody.AddForce(transform.up * BunnyJumpForce);
                JumpsLeft--;

                JumpFX.Play();
            }

            MyAnim.SetFloat("vVelocity", MyRigidBody.velocity.y);
            ScoreText.text = (Time.time - StartTime).ToString("0.0");

            if (decimal.Parse(ScoreText.text) == 10)
            {
                BackgroundNorm.Stop();
                BackgroundFast.Play(); 
            }
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

            DeathFX.Play();
        }
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            JumpsLeft = 2;
        }
    }
}
