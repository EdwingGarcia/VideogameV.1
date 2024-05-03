using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speedH;
    public float speedV;
    float yaw;
    float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor para mantenerlo dentro de la ventana
    }

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y"); // Cambiado a resta para invertir el movimiento del mouse
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Limitar el �ngulo de pitch entre -90 y 90 grados para evitar que la c�mara gire completamente

        transform.eulerAngles = new Vector3(pitch, yaw, 0f); // Cambiado el orden de los �ngulos para que la rotaci�n sea m�s intuitiva
    }
}
