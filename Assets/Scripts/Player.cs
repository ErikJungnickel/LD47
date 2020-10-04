using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    public VolumeProfile deathProfile;
    public GameObject globalVolume;
    public GameObject deathCubes;
    public GameObject pauseMenu;

    private Rigidbody2D rb;
    private Animator animator;
    private float jumpForce = 12;

    private bool isGrounded = true;
    private bool isInAir = false;
    private bool isCrouching = false;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        animator.SetBool("crouch", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCrouch(InputValue value)
    {
        float crourchValue = value.Get<float>(); // 1 - button down, 0 - button release
        if (crourchValue == 0)
        {
            isCrouching = false;
            animator.SetBool("crouch", false);
        }
        else
        {
            isCrouching = true;
            animator.SetBool("crouch", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            playerDead();
        }

        if (collision.gameObject.name == "ground")
        {
            if (isInAir)
            {
                animator.SetTrigger("landing");
            }

            isGrounded = true;
            isInAir = false;

            rb.gravityScale = 3;
        }
    }

    void playerDead()
    {
        if (!isDead)
        {
            isDead = true;
            Score.Instance.isDead = true;
            GetComponent<AudioSource>().Play();

            Volume volume = globalVolume.GetComponent<Volume>();
            volume.profile = deathProfile;

            GetComponent<SpriteRenderer>().enabled = false;
            deathCubes.SetActive(true);

            StartCoroutine(WaitAfterDeath());

        }
    }

    IEnumerator WaitAfterDeath()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnJump(InputValue value)
    {
        float jumpValue = value.Get<float>(); // 1 - button down, 0 - button release
        Debug.Log(jumpValue);
        if (jumpValue == 0 && !isGrounded)
        {
            rb.gravityScale = 5;
        }
        if (isGrounded && !isCrouching && jumpValue == 1)
        {
            isGrounded = false;
            isInAir = true;            

            animator.SetTrigger("jump");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void OnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
}
