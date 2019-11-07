using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cogu : MonoBehaviour
{
    public playerScript playerScript;
    public bool cogumelo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void interacao()
    {
        if (cogumelo == false)
        {
            cogumelo = true;
            GetComponent<Collider2D>().enabled = false;

            playerScript = FindObjectOfType(typeof(playerScript)) as playerScript;
            playerScript.jumpForce = 500f;


        }
    }
}
