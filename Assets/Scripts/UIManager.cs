using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public GameObject goVidaBase;

    public static float vidaBase;
    public static float dinero;


    public Text vidaBaseTxt;
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

	

}
