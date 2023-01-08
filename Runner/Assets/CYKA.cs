using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CYKA : MonoBehaviour
{
    public float _fdhd;

    private void Start()
    {
        StartCoroutine(wef());
    }
    private IEnumerator wef()
    {
       // var seconds = new WaitForSeconds(1f);  ¿ Œ√Œ ’”ﬂ Õ≈–¿¡Œ“¿≈“  ”–Œ“»Õ¿ ¡Àﬂ“‹!
        yield return new WaitForSeconds(1f);
        _fdhd += 0.1f;
    }
}
