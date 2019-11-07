using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    private SpriteRenderer  spriteRenderer;
    public Sprite[]         imagemObjeto;
    public bool             open;
    public GameObject[]     loots;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void interacao()
    {
        if (open == false)
        {
            open = true;
            spriteRenderer.sprite = imagemObjeto[1];                        
            StartCoroutine("gerarLoot");
            GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator gerarLoot()
    {
        // CONTROLE DE LOOT
        int qtdMoedas = Random.Range(1, 5);
        for (int l = 0; l <= qtdMoedas; l++)
        {
            int rand = 0;
            rand = Random.Range(1, 100);
            int idLoot = 0;

            if (rand >= 50)
            {
                idLoot = 1;
            }
            GameObject lootTemp = Instantiate(loots[idLoot], transform.position, transform.localRotation);
            lootTemp.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-25, 25), 150));
            yield return new WaitForSeconds(0.01f);
        }
    }
}
