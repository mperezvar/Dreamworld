using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosJugador : MonoBehaviour
{
    private int vida;
    private int nivel;
    private int EXP;
    private int DEF;
    private int daño;
    private bool cama=false;
    private bool cofre=false;
    // Start is called before the first frame update
    //Getters
    public int GetVida()
    {
        return vida;
    }
    public int GetNivel()
    {
        return nivel;
    }
    public int GetEXP()
    {
        return EXP;
    }
    public int GetDEF()
    {
        return DEF;
    }
    public int GetDaño()
    {
        return daño;
    }

    //Setters
    public void SetVida(int v)
    {
        vida = v;
    }
    public void SetNivel(int n)
    {
        nivel= n;
    }
    public void SetEXP(int exp)
    {
        EXP= exp;
    }
    public void SetDEF(int def)
    {
        DEF= def;
    }
    public void SetDaño(int dmg)
    {
        daño = dmg;
    }
    public void SetCama(bool b)
    {
        cama = b;
    }
    public void SetCofre(bool b)
    {
        cofre = b;
    }
    public bool GetCama()
    {
        return cama;
    }
    public bool GetCofre()
    {
        return cofre;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

}
