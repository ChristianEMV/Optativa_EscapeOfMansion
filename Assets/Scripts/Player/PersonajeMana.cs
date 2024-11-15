using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMana : MonoBehaviour
{
    [SerializeField] private float manaInicial;
    [SerializeField] private float manaMax;
    [SerializeField] private float regeneracionPorSegundo;

    public float ManaActual { get; private set; }
    private PersonajeVida _personajeVida;

    private void Awake()
    {
        _personajeVida = GetComponent<PersonajeVida>();
    }

    void Start()
    {
        ManaActual = manaInicial;
        ActualizarBarraMana();

        InvokeRepeating(nameof(RegenerarMana), 1f, 1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UsarMana(10f);  
        }
    }

    public void UsarMana(float cantidad)
    {
        if(ManaActual >= cantidad)
        { 
            ManaActual -= cantidad;
            ActualizarBarraMana();
        
        }
    }

    private void RegenerarMana()
    {
        if (_personajeVida.Salud > 0f && ManaActual < manaMax)
        {
            ManaActual += regeneracionPorSegundo;
            ActualizarBarraMana();
        }
    }

    public void RestablecerMana()
    {
        ManaActual = manaInicial;
        ActualizarBarraMana();
    
    }

    private void ActualizarBarraMana()
    {
        UIManagger.Instance.ActualizarManaPersonaje(ManaActual, manaMax);
    
    }
}
