using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{


    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.jumpSound);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.TakeDamage(10);
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.damageSound);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.Instance.AddScore(10);
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.coinSound);
            Debug.Log("CoinPoolManager: " + CoinPoolManager.Instance);


            CoinPoolManager.Instance.CollectCoin(other.gameObject);
            //Destroy(other.gameObject);
            Debug.Log("player added to score");
        }

        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.TakeDamage(10);
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.damageSound);
        }
    }

}
