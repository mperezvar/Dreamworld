using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogoComplejo : MonoBehaviour
{
    [TextArea(3,10)]
    public string[] oraciones;
    public TextMeshProUGUI mensajeC;
    public TextMeshProUGUI avisoC;
    public GameObject panelC;
    public GameObject jugador;
    public Button[] Opciones;
    public string[] OPText;
    public GameObject panelaviso;
    private string s="";
    private float vel;
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        panelaviso.SetActive(false);
        vel = jugador.GetComponent<Movimiento>().GetVelocidad();
        for (int n=0; n<Opciones.Length; n++)
        {
            Opciones[n].interactable = false;
        }
        
        panelC.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D otro)
    {
        TagID();
        if (otro.CompareTag("Player"))
        {
            s = "";
            panelaviso.SetActive(true);
            avisoC.text = "Presiona Z o ENTER para interactuar";
            StartCoroutine(DialogoC());
        }
    }
    IEnumerator DialogoC()
    {
        //Al presionar Z o Enter el aviso se va
        yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
        avisoC.text = "";
        panelaviso.SetActive(false);

        //Ciclo for que muestra las oraciones en pantalla
        for (int i = 0; i < oraciones.Length; i++)
        {
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
            jugador.GetComponent<Movimiento>().SetVelocidad(0.0f);
            panelC.SetActive(true);
            for (int let = 0; let < oraciones[i].Length; let++)
            {
                yield return new WaitForSeconds(0.07f);
                s = s + oraciones[i][let].ToString();
                mensajeC.text = s;
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
                {
                    mensajeC.text = oraciones[i];
                    yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                    break;
                }
            }
            s = "";
            if (i == oraciones.Length - 1)
            {
                yield return new WaitForSecondsRealtime(2.0f);
                jugador.GetComponent<Movimiento>().SetVelocidad(0.0f);
                for (int j=0; j<Opciones.Length; j++)
                {
                    Opciones[j].interactable = true; 
                    Opciones[j].GetComponentInChildren<TextMeshProUGUI>().text = OPText[j];
                }
            }
            yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
        }
    }
    void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            Apagar();
        }
    }
    void Apagar()
    {
        StopAllCoroutines();
        s = "";
        mensajeC.text = "";
        for(int i=0; i<Opciones.Length; i++)
        {
            Opciones[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            Opciones[i].interactable = false;
        }
        panelC.SetActive(false);
        avisoC.text = "";
        panelaviso.SetActive(false);
        TagDesactivar();

    }
    void TagID()
    {
        switch (objeto.tag)
        {
            case "Cama":
                jugador.GetComponent<DatosJugador>().SetCama(true);
                break;
            case "Cofre":
                jugador.GetComponent<DatosJugador>().SetCofre(true);
                break;
            default:
                jugador.GetComponent<DatosJugador>().SetCama(true);
                break;

        }
    }
    void TagDesactivar()
    {
        jugador.GetComponent<DatosJugador>().SetCama(false);
        jugador.GetComponent<DatosJugador>().SetCofre(false);
    }

}
