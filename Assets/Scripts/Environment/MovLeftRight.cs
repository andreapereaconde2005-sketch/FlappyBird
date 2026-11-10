using UnityEngine;

public class MovLeftRight : MonoBehaviour
{
// VARIABLES CONTROLES
    public float velocidad;          // Cómo de rápido camina el obstáculo
    public float tiempoCambioDireccion; // Cada cuántos segundos cambia de lado

    private float cronometro;
    private int direccion;             // 1 es derecha, -1 es izquierda

    void Start()
    {
        velocidad = 3f;
        tiempoCambioDireccion = 2f;
        cronometro = 0f;
        direccion = 1;
    }

    void Update()
    {
        // 1. Avanzamos el cronómetro con el tiempo del juego
        cronometro += Time.deltaTime;

        // 2. Si se cumple el tiempo asignado, cambiamos de dirección y reiniciamos el reloj
        if (cronometro >= tiempoCambioDireccion)
        {
            direccion *= -1; // Invierte el valor: de 1 pasa a -1, y de -1 pasa a 1
            cronometro = 0f; // Resetea el reloj a cero
        }

        // 3. Movemos el obstáculo usando transform.Translate (igual que mi pájaro)
        MoverObstaculo();
    }

    private void MoverObstaculo()
    {
        // Multiplicamos por 'direccion' para que vaya a la derecha (positivo) o izquierda (negativo)
        transform.Translate(Vector3.right * velocidad * direccion * Time.deltaTime);
    }
}