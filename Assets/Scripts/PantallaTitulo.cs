using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PantallaTitulo : MonoBehaviour {

    public void MoveScene(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }


}
