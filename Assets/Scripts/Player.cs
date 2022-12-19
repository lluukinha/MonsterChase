using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private bool isGrounded = true;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();

    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        var movement = Time.deltaTime * moveForce;
        transform.position += new Vector3(movementX, 0f, 0f) * movement;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlayerJump();
        }
    }

    void AnimatePlayer()
    {
        var willMove = movementX > 0 || movementX < 0;
        var willFlip = sr.flipX;

        if (movementX > 0)
        {
            willMove = true;
            willFlip = false;

        } else if (movementX < 0)
        {
            willMove = true;
            willFlip = true;
        }

        sr.flipX = willFlip;
        anim.SetBool(WALK_ANIMATION, willMove);
    }

    void PlayerJump()
    {
        isGrounded = false;
        myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
