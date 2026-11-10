using UnityEngine;
using UnityEngine.SceneManagement;

public class Dropper : MonoBehaviour
{
    // --- VARIABLES ---
    Rigidbody myRigidBody;
    MeshRenderer myMeshRenderer;
    float startTime;

    [SerializeField] float delay = 1.0f; // Segundos a esperar antes de caer

    // NUEVAS VARIABLES PARA EL TEMPORIZADOR
    private float timer = 0f;          // Nuestro cronómetro, empieza en 0
    private bool isCounting = false;   // Controla si debemos empezar a contar el tiempo o no
    private bool hasDropped = false;   // Evita que el código de caída se ejecute repetidamente una vez que ya cayó

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        //Time.time mide el tiempo total acumulado desde que se inició el juego, mientras que Time.deltaTime mide el tiempo que pasa entre un fotograma (frame) y el siguiente.
        startTime = Time.time;

        myRigidBody.useGravity = false;
    }

    // Update revisa las condiciones en cada fotograma del juego
    void Update()
    {
        // SI el sensor nos dio la orden de contar Y AÚN NO ha caído el objeto...
        if (isCounting && !hasDropped)
        {
            // Sumamos el tiempo real que ha pasado desde el último frame al cronómetro
            timer += Time.deltaTime;

            // IF PRINCIPAL: ¿El cronómetro ya alcanzó o superó el tiempo de espera deseado?
            if (timer >= delay)
            {
                DropObject(); // Llamamos a la función que activa la gravedad
            }
        }
    }

    // Esta función la sigue llamando tu TriggerActivator en el momento exacto en que pasa el pájaro
    public void Activate()
    {
        // Encendemos el interruptor para que el Update empiece a contar
        isCounting = true;
    }

    void DropObject()
    {
        myRigidBody.useGravity = true; // El objeto cae
        hasDropped = true;             // Marcamos que ya cayó para apagar el comportamiento del Update
    }
    // NUEVA FUNCIÓN: Se activa automáticamente cuando este objeto choca físicamente contra otro
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobamos si el objeto con el que hemos chocado es el Jugador--> Objeto Jugador porque es el que lleva el collider
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. Buscamos el objeto LevelController que está en la escena
            LevelController levelController = FindAnyObjectByType<LevelController>();

            // 2. Si lo encuentra, le pide que gestione el reinicio con su retraso de 0.5s
            if (levelController != null)
            {
                levelController.TriggerReloadLevel();
            }
        }
    }
}
