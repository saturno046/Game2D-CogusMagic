using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manivela : MonoBehaviour
{
    private SpriteRenderer  spriteRenderer;
    public Sprite[]         imagemObjeto;
    public bool             Manivela;
    public portalScript portalScript;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void interacao()
    {
        if (Manivela == false)
        {
            Manivela = true;
            spriteRenderer.sprite = imagemObjeto[1];   
                        
            GetComponent<Collider2D>().enabled = false;

            portalScript = FindObjectOfType(typeof(portalScript)) as portalScript;
            portalScript.openPortal = true;
            portalScript.spriteRenderer.sprite = imagemObjeto[2];  

        }
    }
}

