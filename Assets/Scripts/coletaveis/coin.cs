using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private _GameCtrl _GameCtrl;

    public int valor;

    private void Start()
    {
        _GameCtrl = FindObjectOfType(typeof(_GameCtrl)) as _GameCtrl;
    }

    public void coletar()
    {
        _GameCtrl.gold += valor;
        Destroy(this.gameObject);
    }
}
