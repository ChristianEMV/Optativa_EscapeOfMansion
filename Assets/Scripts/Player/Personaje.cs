using UnityEngine;
using UnityEngine.Rendering;

public class Personaje : MonoBehaviour
{
    public PersonajeVida PersonajeVida { get; private set; }
    public PersonajeAnimaciones PersonajeAnimaciones { get; private set; }
    public PersonajeMana PersonajeMana { get; private set; }

    private void Awake()
    {
        PersonajeVida = GetComponent<PersonajeVida>();
        PersonajeAnimaciones = GetComponent<PersonajeAnimaciones>();
        PersonajeMana = GetComponent<PersonajeMana>();
    }

    public void ResturarPersonaje()
    {
        PersonajeVida.ResturarPersonaje();
        PersonajeAnimaciones.RevivirPersonje();
        PersonajeMana.RestablecerMana();

    }



}