using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalScript : MonoBehaviour
{
    public SpriteRenderer  spriteRenderer;
    public Sprite[]         imagemObjeto;
    public bool             openPortal;
    public string          cenaDestino;
    private fade fade;

    // Start is called before the first frame update
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fade = FindObjectOfType(typeof(fade)) as fade;
        
    }

    public void interacao()
    {

        StartCoroutine("acionarPortal");

        
    }

     IEnumerator acionarPortal()
    {

        if (openPortal == true)
        {
           fade.fadeIn();
           yield return new WaitWhile(() => fade.fume.color.a < 0.9f);
           SceneManager.LoadScene(cenaDestino);
        }
    }
}
