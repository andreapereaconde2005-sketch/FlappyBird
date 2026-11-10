using UnityEngine;

public class CollisionColorChange : MonoBehaviour
{
    // VARIABLES (Mantengo tu estructura de apuntes de clase)
    [SerializeField] public Color hitColor;
    public Color normalColor;

    // --- NUEVO REQUISITO: ARRAY PARA GUARDAR TODAS LAS MALLAS (ARRIBA Y ABAJO) ---
    private MeshRenderer[] todasLasMallas;
    
    // Este método se ejecuta al iniciar el juego
    void Start()
    {
        // --- MODIFICADO CON ARRAY: Guardamos todas las mallas hijas en el array ---
        todasLasMallas = GetComponentsInChildren<MeshRenderer>();

        // Registro automáticamente el color original que tiene mi malla (mi verde oscuro chulo por ejemplo)
        normalColor = GetComponentInChildren<MeshRenderer>().material.color;
    }

    void Update()
    {
        
    }

    // Se ejecuta de forma automática en el instante que algo choca físicamente contra mi tubo
    private void OnCollisionEnter(Collision other) 
    {
        // Compruebo si el objeto que me ha golpeado tiene la etiqueta "Player"
        if (other.gameObject.CompareTag("Player")) 
        {
            // --- MODIFICADO CON BUCLE FOR: Recorremos el array usando un contador numérico ---
            for (int i = 0; i < todasLasMallas.Length; i++)
            {
                todasLasMallas[i].material.color = hitColor;
            }

            // Cambio el color de mi material al color de impacto (por ejemplo, rojo)
            // GetComponentInChildren<MeshRenderer>().material.color = hitColor;

            // Busco el componente PlayerCollisionManager dentro del objeto que me ha golpeado (el jugador)
            PlayerCollisionManager playerCollisionManager = other.gameObject.GetComponentInChildren<PlayerCollisionManager>();
            
            // Si el jugador realmente tiene ese script, le ordeno que procese el golpe para reiniciar la partida
            if (playerCollisionManager != null)
            {
                playerCollisionManager.ProcessHit();
            }
        }
    }

    // Se ejecuta de forma automática si el objeto se separa de mi colisionador
    private void OnCollisionExit(Collision other)
    {
        // --- MODIFICADO CON BUCLE FOR: Recorremos el array para restaurar los colores originales ---
        for (int i = 0; i < todasLasMallas.Length; i++)
        {
            todasLasMallas[i].material.color = normalColor;
        }

        // Devuelvo el material a su color original para dejarlo como estaba
        // GetComponentInChildren<MeshRenderer>().material.color = normalColor;
    }
}
