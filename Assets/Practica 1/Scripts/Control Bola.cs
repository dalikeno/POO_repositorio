using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ControlBola : MonoBehaviour
{

    public Transform CamaraMain;

    public Rigidbody rb;

    public float velocidadDeApuntado = 5f;
    public float LimiteIzquierdo = -2f;
    public float LimiteDerecho = 2f;
  
    public float FuerzaDeLanzamiento = 1079f;

    private bool dalikeno;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // MIENTRAS QUE HA SIDO LANZADO SE DISPARA
        if (dalikeno == false)
        {
            Chema();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();

            }
        }
    }

    void Chema()
    {
        float InputHorizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right*InputHorizontal*velocidadDeApuntado*Time.deltaTime);

        Vector3 posicionActual = transform.position;

        posicionActual.x = Mathf.Clamp(posicionActual.x, LimiteIzquierdo, LimiteDerecho);

        transform.position = posicionActual;
    }

    void Lanzar()
    {
        dalikeno = true;
        rb.AddForce(Vector3.forward * FuerzaDeLanzamiento);

        if (CamaraMain!=null)
        {
            CamaraMain.SetParent(transform);
        }
    }

} //Bienvenido al infierno
