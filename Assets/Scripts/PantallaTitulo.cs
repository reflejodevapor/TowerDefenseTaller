using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PantallaTitulo : MonoBehaviour {

    public void MoveScene(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public GameObject imagenBloqueo;
    public GameObject panelCreditos;
    public GameObject panelOpciones;
    public void EstadoPanelCreditos(bool _estado)
    {
        imagenBloqueo.SetActive(_estado);
        panelCreditos.SetActive(_estado);
    }

    public void EstadoPanelOpciones(bool _estado)
    {
        imagenBloqueo.SetActive(_estado);
        panelOpciones.SetActive(_estado);
    }


    public void EstadoUI(bool _estado)
    {
        imagenBloqueo.SetActive(_estado);
        panelOpciones.SetActive(_estado);
        panelCreditos.SetActive(_estado);

    }


}
