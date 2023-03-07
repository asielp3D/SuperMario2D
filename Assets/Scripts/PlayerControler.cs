
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    int playerHealt = 3;
    public float playerSpeed = 5.5f;
    public float jumpforce = 3f;
    string texto = "Hello World";

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    public Animator anim;
    private Coin coin;
    private Flag flag;
    SFXManager sfxManager;
    SoundManager soundManager;
    float horizontal;
    public Text cointext;
    int contadorMonedas;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
        rBody = GetComponent <Rigidbody2D>();
        anim = GetComponent<Animator>();
        sensor = GameObject.Find("GroundSensor").GetComponent <GroundSensor>();
        coin = GameObject.Find("Coin").GetComponent <Coin>();
        playerHealt = 10;
        Debug.Log(texto);
        contadorMonedas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(horizontal, 0, 0) * playerSpeed * Time.deltaTime;
        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
        anim.SetBool("IsRunning", false);
        if (Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }
    }
    private void FixedUpdate() 
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ColisionCoin")
        {
            Debug.Log("Moneda cogida");
            Coin coin = collision.gameObject.GetComponent<Coin>();
            coin.Pick();
            contadorMonedas++;
            cointext.text = "coin x" + contadorMonedas;
        }

        if(collision.gameObject.tag == "ColisionFlag")
        {
            Debug.Log("WIN");
            Flag flag = collision.gameObject.GetComponent<Flag>();
            flag.Touch();
        }
    }        

    
}
