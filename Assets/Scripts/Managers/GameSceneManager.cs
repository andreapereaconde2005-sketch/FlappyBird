using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    //estamos añadiendo a la clase un objeto de SU propio tipo, esto en ingeniería de software
    //se llama hacer un PATRÓN SINGLETON --> nos aseguramos de que jamás se cree más una instancia 
    //de esta clase pues solo quiero tener UNA. Meteré en esta clase pues todas las cosas que quiero 
    //Unity recuerde al pasar de escenas
    public static GameSceneManager Instance;

    public int points;

    //aquí start no nos hace falta, haremos uso de otro callback llamado Awake. Este método es parecido
    // a Start, solo se ejecuta una vez, se llama antes incluso que a Start 
    void Awake()
    {
        //PATRON SINGLETON
        if(Instance == null)//solo estará vació la primera vez
        {
            Instance = this; //lo referenciamos con el atributo que hemos creado, primer objeto que Unity ve
            points = 0;  //inicializamos points como haríamos en el Start
            DontDestroyOnLoad(gameObject); //cuando pases por aquí marca ese objeto como NO DESTRUIR
        }
        else
        {
            //si ya hemos creado la referencia entonces sí destruimos
            Destroy(gameObject);
        }
    }
}
