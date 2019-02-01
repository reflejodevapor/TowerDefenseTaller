using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Image goVidaBase;

    public static float vidaBase = 100;
    public static int dinero = 40;

    public Text dineroTxt;

    /// <summary>
    /// Método para manejar cuando el enemigo llegó a la meta
    /// </summary>
    /// <param name="d"></param>
    public static void RecibeDanio(float d)
    {
        vidaBase -= d;
        //Cuando ya valio pito
        if (vidaBase <= 0)
        {
            vidaBase = 0;

            //TO DO: Implementar el fin de juego
        }
    }
    

    void AjustaBarraVida()
    {
        goVidaBase.fillAmount = vidaBase * 0.01f;
    }

    void Update()
    {
        AjustaBarraVida();
        dineroTxt.text = dinero.ToString();
    }


    


}
