using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

using UnityEngine.UI;

public class AreaDesap : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area")) // Comprueba si el jugador entró en la zona
        {
            Destroy(other.gameObject);

        }
    }
}
