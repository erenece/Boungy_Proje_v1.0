using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    Rigidbody2D rb;

    //baþlangýçtaki gözler saða bakýyor, böyle kalabilir 
    bool facingRight;                  


    // karakter zeminin üzerinde mi
    public Transform groundCheck;       
    public LayerMask groundLayer;

    public float groundCheckRadius = 0.5f;

    bool isJumping;
    bool isGrounded;

    Animator anim;

    public int coin;

    public TextMeshProUGUI text;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        facingRight = true;
    }

    private void Update()
    {
        text.text = coin.ToString();

        float movInput = Input.GetAxis("Horizontal");                                //karakterin yatay eksen hareketi, x ekseni/ saða basarsan 1 deðerini alýr; sola basarsan -1 deðerini alýr
        rb.velocity = new Vector2(movInput * speed, rb.velocity.y);                  //karakterin hareketinin hýzý 

        if (movInput > 0 && !facingRight)
        {
            Flip();
        }

        else if (movInput < 0 && facingRight) 
        {
            Flip();
        }

        //groundCheck pozisyonunun zemine deyip deymediðini kontorol ediyoruz
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping= true;
        }

        //zeminde ise ama hala zýplýyor görünüyorsa 
        if(isGrounded && isJumping)
        {
            isJumping = false;
        }


        if (movInput == 0)
        {
            anim.SetBool("hareket", false);

        }
        else
        {
            anim.SetBool("hareket", true);

        }

        Debug.Log(coin.ToString());
        //topladýðýmýz coin miktarýný yazdýrmak için

    }

    private void Flip()
    {

        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler; 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike") 
        
        {
            Debug.Log("Dikenlere temas edildi");

            SceneManager.LoadScene(0);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Düþmana Temas Edildi");
            SceneManager.LoadScene(0);
        }
    }



}
