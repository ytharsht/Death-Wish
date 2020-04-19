using UnityEngine;
using System.Collections;

public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Animator camAnim;

    [Header ("Settings")]
    [Range (1, 100)]
    public float moveSpeed;
    [Range(1, 100)]
    public float jumpForce;
    public int jumpCount;
    [Range (1, 100)]
    public float secondaryJumpForce;
    [HideInInspector] public int plantsCollected;
    [Space]
    public Transform groundPosition;
    public float Radius;
    public LayerMask WhatIsGround;
    [Space]
    [Header("Polish")]
    public GameObject dustEffect;
    public GameObject victoryEffect;
    [Space]
    public GameObject winningMenuUI;
    [Header("SFX")]
    private AudioSource audioSource;
    public AudioClip jumpSound;

    private float movement;
    private bool isGrounded;
    private bool landing;
    private int startJumpCount = 3;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();

        winningMenuUI.SetActive(false);
    }

    private void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
    }

    private void Update()
    {
        if (plantsCollected == 6)
        {
            StartCoroutine(vicotry());
        }

        if (movement > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (movement < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (movement == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
        isGrounded = Physics2D.OverlapCircle(groundPosition.position, Radius, WhatIsGround);

        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            if (jumpCount > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                anim.SetTrigger("Takeoff");
                Instantiate(dustEffect, groundPosition.position, Quaternion.identity);
                jumpCount++;
                audioSource.clip = jumpSound;
                audioSource.Play();
            }
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
            jumpCount = startJumpCount;

            if (landing == true)
            {
                Instantiate(dustEffect, groundPosition.position, Quaternion.identity);
                camAnim.SetBool("shake", true);
                landing = false;
            }
        }
        else
        {
            anim.SetBool("isJumping", true);
            landing = true;
            camAnim.SetBool("shake", false);
        }

        if (isGrounded == false && Input.GetButtonDown("Jump"))
        {
            if (jumpCount > 1)
            {
                rb.velocity = Vector2.up * secondaryJumpForce;
                jumpCount--;
                audioSource.clip = jumpSound;
                audioSource.Play();
            }
        }

        IEnumerator vicotry()
        {
            Instantiate(victoryEffect, transform.position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(3);
            winningMenuUI.SetActive(true);
        }

    }
    }
