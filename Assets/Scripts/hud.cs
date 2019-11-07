﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hud : MonoBehaviour
{
    // controle de vida do personagem "lembrar criar"
    private playerScript playerScript;
    public Image[] hpBar;
    public Sprite half, full;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType(typeof(playerScript)) as playerScript;
    }

    // Update is called once per frame
    void Update()
    {
        controleBarraVida();
    }

    void controleBarraVida()
    {
        float percVida = (float)playerScript.vidaAtual / (float)playerScript.vidaMaxima;// CALCULA PERCENTUAL DE VIDA

        // REPRESENTA 100% DE VIDA
        foreach (Image img in hpBar)
        {
            img.enabled = true;
            img.sprite = full;
        }

        if (percVida == 1)
        {

        }
        else if (percVida >= 0.9f)
        {
            hpBar[4].sprite = half;
        }
        else if (percVida >= 0.8f)
        {
            hpBar[4].enabled = false;
        }        
        else if (percVida >= 0.7f)
        {
            hpBar[4].enabled = false;
            hpBar[3].sprite = half;
        }
        else if (percVida >= 0.6f)
        {
            hpBar[4].enabled = false;
            hpBar[3].enabled = false;
        }
        else if (percVida >= 0.5f)
        {
            hpBar[4].enabled = false;
            hpBar[3].enabled = false;
            hpBar[2].sprite = half;
        }
        else if (percVida >= 0.4f)
        {
            hpBar[4].enabled = false;
            hpBar[3].enabled = false;
            hpBar[2].enabled = false;
        }
        else if (percVida >= 0.3f)
        {
            hpBar[4].enabled = false;
            hpBar[3].enabled = false;
            hpBar[2].enabled = false;
            hpBar[1].sprite = half;
        }
        else if (percVida >= 0.2f)
        {
            hpBar[4].enabled = false;
            hpBar[3].enabled = false;
            hpBar[2].enabled = false;
            hpBar[1].enabled = false;
        }
        else if (percVida >= 0.01f)
        {
            hpBar[4].enabled = false;
            hpBar[3].enabled = false;
            hpBar[2].enabled = false;
            hpBar[1].enabled = false;
            hpBar[0].sprite = half;
        }
        else if (percVida <= 0f)
        {
            hpBar[4].enabled = false;
            hpBar[3].enabled = false;
            hpBar[2].enabled = false;
            hpBar[1].enabled = false;
            hpBar[0].enabled = false;
        }
    }
}
