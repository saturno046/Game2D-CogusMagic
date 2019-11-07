using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private _GameCtrl _GameCtrl;

    private     Animator    playerAnimator;
    private     Rigidbody2D playerRb;
    private     SpriteRenderer sRender;

    private     float       h, v;

    public      Transform   groundCheck; //objeto responsavel em deectar se o prsonagem esta sobre uma superficie
    public      LayerMask   whatIsGround; //indica o que é superficie para o teste do grounded

    public      int         vidaMaxima;
    public      int         vidaAtual;

    public      float       speed; //velocidade de movimentacao do personagem
    public      float       jumpForce; //forca aplicada para gerar o pulo do personagem

    public      bool        Grounded; //indica se o personagem esta pisando em alguma superficie
    public      bool        attacking; //indica de o personagem esta atacando
    public      bool        loockLeft; //indica se o personagem esta virado para a esquerda
    public      int         idAnimation; //indica o id da animacao
    public      Collider2D  standing, crounching; //colisor em pé, colisor agachado

    //intereção com itens e objetos
    public      Transform   hand;
    private     Vector3     dir = Vector3.right;
    public      LayerMask   interacao;
    public      GameObject  objetoInteracao;
    public      GameObject  alertaBalao;

    //Sistema de armas
    public      GameObject[]  armas;
    
    // Start is called before the first frame update
    void Start()
    {
        _GameCtrl = FindObjectOfType(typeof(_GameCtrl)) as _GameCtrl;

        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        sRender = GetComponent<SpriteRenderer>();

        vidaAtual = vidaMaxima;

        foreach (GameObject o in armas) {
            o.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);

        playerRb.velocity = new Vector2(h * speed, playerRb.velocity.y);

        interagir();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if(h > 0 && loockLeft && !attacking)
        {
            flip();
        }
        else if(h< 0 && !loockLeft && !attacking)
        {
            flip();
        }

        if(v < 0)
        {
            idAnimation = 2;
            if (Grounded)
            {
                h = 0;
            }
        }
        else if (h != 0)
        {
            idAnimation = 1;
        } else
        {
            idAnimation = 0;
        }

        if (Input.GetButtonDown("Fire1") && v >= 0 && attacking == false && objetoInteracao == null)
        {
            playerAnimator.SetTrigger("atack");
        }

        if (Input.GetButtonDown("Fire1") && v >= 0 && attacking == false && objetoInteracao != null)
        {
            objetoInteracao.SendMessage("interacao", SendMessageOptions.DontRequireReceiver);
        }

        if (Input.GetButtonDown("Jump") && Grounded && !attacking)
        {
            playerRb.AddForce(new Vector2(0, jumpForce));
        }

        if (attacking && Grounded)
        {
            h = 0;
        }

        if (v < 0 && Grounded)
        {
            crounching.enabled = true;
            standing.enabled = false;
        } 
        else if (Grounded)
        {
            crounching.enabled = false;
            standing.enabled = true;            
        }
        else if (v != 0 && !Grounded)
        {
            crounching.enabled = false;
            standing.enabled = true;
        }

        playerAnimator.SetBool("grounded", Grounded);
        playerAnimator.SetInteger("idAnimation", idAnimation);
        playerAnimator.SetFloat("speedY", playerRb.velocity.y);
    }

    private void flip()
    {
        loockLeft = !loockLeft; // inverte o valor da variavel
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

        dir.x = x;
        //dir = dir;
    }

    public void attack(int atk)
    {
        switch (atk)
        {
            case 0:
                attacking = false;
                armas[2].SetActive(false);
                break;

            case 1:
                attacking = true;
                break;
        }
    }

    void interagir()
    {
        Debug.DrawRay(hand.position, dir * 0.1f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(hand.position, dir, 0.1f, interacao);

        if (hit == true)
        {
            objetoInteracao = hit.collider.gameObject;
            alertaBalao.SetActive(true);
        }
        else
        {
            objetoInteracao = null;
            alertaBalao.SetActive(false);
        }
    }

    void controleArma(int id)
    {
        foreach (GameObject o in armas)
        {
            o.SetActive(false);
        }

        armas[id].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "coletavel":

                collision.gameObject.SendMessage("coletar", SendMessageOptions.DontRequireReceiver);

                break;
        }
    }

    public void changeMaterial(Material novoMaterial)
    {
        sRender.material = novoMaterial;
        foreach (GameObject o in armas)
        {
            o.GetComponent<SpriteRenderer>().material = novoMaterial;
        }
    }
}
