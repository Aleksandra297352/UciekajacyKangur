using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKangarooController : MonoBehaviour
{
    public float playerSpeed;
    public float maxY;
    public float minY;
    private Rigidbody2D rb;
    public GameObject sprite;
    Vector2 playerDirection;
    public AudioSource AudioSource;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameStarted && GameManager.GameFinished == false && animator.enabled == false)
        {
            animator.enabled = true;
        }
        if (GameManager.GameFinished) return;
        var directionY = Input.GetAxisRaw("Vertical");
        var newDirection = new Vector2(0, directionY).normalized;

        if ((transform.position.y + 0.1 >= maxY && newDirection.y > 0) || (transform.position.y - 0.1 <= minY && newDirection.y < 0))
        {
            playerDirection = new Vector2(0, 0);
            return;
        }

        playerDirection = newDirection;
    }
    void FixedUpdate()
    {
        if (GameManager.GameFinished)
        {
            rb.velocity = new Vector2();
            return;
        }
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.FinishGame();
        animator.StopPlayback();
        animator.enabled = false;
        AudioSource.enabled = true;
        AudioSource.Play();
    }
}
