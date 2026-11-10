using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    // VARIABLES AJUSTADAS PARA FLAPPY BIRD
    public float speed;          // Velocidad constante de avance hacia la derecha
    public float ThrustForce = 8000f;   // Fuerza fija adecuada para dar un buen impulso vertical
    private bool jump;                  // Bandera para controlar el salto
    private Rigidbody rb;
    private Vector3 directionVector = Vector3.right;

    void Start()
    {
        // Conecto el componente físico del ObjetoJugador
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Si el jugador ha pulsado la tecla, ejecuto el método de salto
        if (jump)
        {
            Jump();
        }

        // Muevo al pájaro hacia la derecha automáticamente todo el tiempo
        MoveAutomatically();
    }

    // He reescrito este método para que avance solo, sin usar el teclado
    //NO ES NECESARIO OnMove PORQUE EL JUGADOR NO PULSA NADA PARA MOVERSE
    private void MoveAutomatically()
    {
        //Mi vector de dirección es Vector3.right, lo que significa que los valores internos son 
        // (X: 1, Y: 0, Z: 0). 
        transform.Translate(
        directionVector.x * speed * Time.deltaTime,
        directionVector.y * speed * Time.deltaTime,
        directionVector.z * speed * Time.deltaTime);
    }


    private void Jump()
    {
        Debug.Log("Jumping!");
        rb.AddRelativeForce(Vector3.up * ThrustForce * Time.fixedDeltaTime);
        jump = false;
        //(0, 1, 0) = Vector.up
    }

    public void OnJump(InputValue value)
    {
        jump = value.isPressed; 
    }

}


