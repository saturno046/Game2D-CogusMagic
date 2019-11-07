using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public fade fade;
    public playerScript playerScript; // TRANSFORM DO PLAYER
    public Transform destino;

    public bool escuro;
    public Material luz2D, padrao2D;

    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType(typeof(fade)) as fade;
        playerScript = FindObjectOfType(typeof(playerScript)) as playerScript;
    }

    public void interacao()
    {
        StartCoroutine("acionarPorta");
    }

    IEnumerator acionarPorta()
    {
        fade.fadeIn();
        yield return new WaitWhile(() => fade.fume.color.a < 0.9f);
        playerScript.gameObject.SetActive(false);

        switch (escuro)
        {
            case true:
                playerScript.changeMaterial(luz2D);
                break;
            case false:
                playerScript.changeMaterial(padrao2D);
                break;
        }

        playerScript.transform.position = destino.position;
        yield return new WaitForSeconds(0.5f);
        playerScript.gameObject.SetActive(true);
        fade.fadeOut();
    }
}
