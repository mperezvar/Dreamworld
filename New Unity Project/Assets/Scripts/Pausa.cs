using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pausa : MonoBehaviour
{
    public GameObject MenuPausa;
    public Button[] botones;
    public string[] texto;
    // Awake is called before the first frame update
    void Start()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            botones[i].interactable = false;
        }
        MenuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            MenuPausa.SetActive(true);
            for(int i=0; i<botones.Length; i++)
            {
                botones[i].GetComponentInChildren<TextMeshProUGUI>().text = texto[i];
                botones[i].interactable = true;
            }
        }

    }
  
}
