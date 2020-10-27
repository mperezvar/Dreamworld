using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogoSImple : MonoBehaviour
{
    [TextArea(3,10)]
    public string[] listaOraciones;
    public GameObject panel;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI aviso;
    public GameObject panelAviso;
    public GameObject jugador;
    private string mensaje = "Presiona Z o ENTER para interactuar";
    private string s="";
    private float vel;
    // Start is called before the first frame update
    void Start()
    {
        vel=jugador.GetComponent<Movimiento>().GetVelocidad();
        panelAviso.SetActive(false);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D jugador)
    {
        if (jugador.CompareTag("Player"))
        {
            s = "";
            panelAviso.SetActive(true);
            aviso.text = mensaje;
            StartCoroutine(iniciarDialogo());
        }
    }
    IEnumerator iniciarDialogo()
    {
        yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
        aviso.text = "";
        panelAviso.SetActive(false);


        for (int i = 0; i < listaOraciones.Length; i++)
        {
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
            jugador.GetComponent<Movimiento>().SetVelocidad(0.0f);
            panel.SetActive(true);

            //Ciclo for que muestra las oraciones en pantalla letra por letra
            for (int let = 0; let < listaOraciones[i].Length; let++)
            {
                yield return new WaitForSeconds(0.07f);
                s = s + listaOraciones[i][let].ToString();
                texto.text = s;
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
                {
                    texto.text = listaOraciones[i];
                    yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                    break;
                }
            }
            s = "";
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));

            //Cuando se acabe el diálogo el jugador vuelve a tener su velocidad anterior.
            if (i == listaOraciones.Length - 1)
                jugador.GetComponent<Movimiento>().SetVelocidad(vel);
        }
    } 
    void OnTriggerExit2D(Collider2D jugador)
    {
        if (jugador.CompareTag("Player"))
        {
            s = "";
            StopAllCoroutines();
            texto.text = "";
            panel.SetActive(false);
            aviso.text = "";
            panelAviso.SetActive(false);
        }
    }
}
