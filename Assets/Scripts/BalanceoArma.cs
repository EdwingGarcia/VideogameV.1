using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceoArma : MonoBehaviour
{
    private Quaternion rotacionInicial;
    public float balanceo = 8;
   
    void Start()
    {
        rotacionInicial=transform.localRotation;
    }

    void Update()
    {
        Balanceo();
    }

    private void Balanceo() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Quaternion anguloX = Quaternion.AngleAxis(mouseX * -1.25f,Vector3.up);
        Quaternion anguloY = Quaternion.AngleAxis(mouseY * -1.25f,Vector3.right);
        Quaternion rotacionObjetivo = rotacionInicial * anguloX * anguloY;
        transform.localRotation = Quaternion.Lerp(transform.localRotation,rotacionObjetivo,Time.deltaTime*balanceo);
    
    }
}
