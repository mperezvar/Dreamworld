using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BotonesPausa : MonoBehaviour
{
    public GameObject MenuPausa;
    public Button[] botones;
    public void Continuar()
    {
        MenuPausa.SetActive(false);
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            botones[i].interactable = false;
        }
    }
    public void VolverMenu()
    {
        SceneManager.LoadScene("Fondo animado menu");
    }
}
