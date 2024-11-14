using UnityEngine;

public class LevelManagger : MonoBehaviour
{
    [SerializeField] private Transform puntoReaparicion;
    [SerializeField] private Personaje personaje;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (personaje.PersonajeVida.Derrotado)
            {
                personaje.transform.localPosition = puntoReaparicion.position;
                personaje.ResturarPersonaje();
            }

        }
    }
}