using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator creditAnims;
    public string playscene = "Game";

    //Configuraci�n para el boton de Jugar
    public void EvButton_Play()
    {
        SceneManager.LoadScene(playscene);
    }

    //Para que vayamos a los creditos "CreditGo" se pone true.
    public void EvButton_Credits() => creditAnims.SetBool("CreditsGo", true);

    //Y para que salgamos cambiamos el valor de "CreditGo" a false.
    public void EvButton_BackCredits() => creditAnims.SetBool("CreditsGo", false);

    public void EvButton_Options()
    {
       
    }

    //Configuraci�n de boton para salir
    public void EvButton_Exit()
    {
        Application.Quit();
    }
}
