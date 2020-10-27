using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BotonesHab : MonoBehaviour
{
    public TextMeshProUGUI mensaje;
    public Button[] Opciones;
    public string cerrarCama;
    public string cerrarCofre;
    private string msjfinal;
    public GameObject jugador;
    private string s = "";
    private bool cama;
    private bool cofre;
    // Start is called before the first frame update
    void Update()
    {
        cama = jugador.GetComponent<DatosJugador>().GetCama();
        cofre = jugador.GetComponent<DatosJugador>().GetCofre();
    }
    public void CambiarEscena()
    {
        if (cama)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (cofre)
            SceneManager.LoadScene("Cofre");
    }

    public void Cerrar()
    {
        StopAllCoroutines();
        StartCoroutine(Escribir());
        for (int i = 0; i < Opciones.Length; i++) {
            Opciones[i].interactable = false;
            Opciones[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }
    IEnumerator Escribir()
    {
        if (cama)
            msjfinal = cerrarCama;
        else if (cofre)
            msjfinal = cerrarCofre;
        else
            msjfinal = "";


        for (int let = 0; let < msjfinal.Length; let++)
        {
            yield return new WaitForSeconds(0.07f);
            s = s + msjfinal[let].ToString();
            mensaje.text = s;
            if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Return))
            {
                mensaje.text = msjfinal;
                yield return new WaitWhile(() => !(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.Return)));
                break;
            }
        }
        s = "";
        jugador.GetComponent<Movimiento>().SetVelocidad(10.0f);
    }
}
