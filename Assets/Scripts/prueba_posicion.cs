using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba_posicion : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 posicionRelativa;
    void Start()
    {
        Debug.Log(gameObject.name + "se encuentra en la posici�n respecto a su referencia " + gameObject.transform.localPosition);
        Debug.Log(gameObject.name + "se encuentra en la posici�n respecto al sistema global " + gameObject.transform.position);
        posicionRelativa = gameObject.transform.position - GameObject.Find("cigarrito").transform.position;
        Debug.Log(gameObject.name + "se encuentra en la posici�n respecto al cigarrito de  " + posicionRelativa);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
