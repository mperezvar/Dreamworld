using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonesBosque : MonoBehaviour
{
    public TextMeshProUGUI mensaje;
    public Button[] Opciones;
    public string noGuardar;
    public GameObject jugador;
    private string s = "";
    public float velocidad;
    // Start is called before the first frame update
    public void NoGuardar()
    {
        StopAllCoroutines();
        StartCoroutine(Escribir());
        for (int i = 0; i < Opciones.Length; i++)
        {
            Opciones[i].interactable = false;
            Opciones[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }

    IEnumerator Escribir()
    {


        for (int let = 0; let < noGuardar.Length; let++)
        {
            yield return new WaitForSeconds(0.07f);
            s = s + noGuardar[let].ToString();
            mensaje.text = s;
            if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
            {
                mensaje.text = noGuardar;
                yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                break;
            }
        }
        s = "";
        jugador.GetComponent<Movimiento>().SetVelocidad(velocidad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
