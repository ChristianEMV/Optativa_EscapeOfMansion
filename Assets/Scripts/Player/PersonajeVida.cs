using System;
using UnityEngine;

public class PersonajeVida : VidaBase
{

    public static Action EventoPersonajeDerrotado;

    public bool Derrotado { get; private set; }
    public bool PuedeSerCurado => Salud < saludMax;

    private BoxCollider2D _boxcollider2D;

    private void Awake()
    {
        _boxcollider2D = GetComponent<BoxCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
        ActualizarBarraVida(Salud, saludMax);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RecibirDanio(10);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            RestaurarSalud(10);
        }
    }

    public void RestaurarSalud(float cantidad)
    {
        if (Derrotado)
        {
            return;
        }
        if (PuedeSerCurado)
        {
           Salud += cantidad;
            if(Salud > saludMax)
            {
                Salud = saludMax;
            }
        }

        ActualizarBarraVida(Salud, saludMax);
    }

    protected override void PersonajeDerrotado()
    {
        _boxcollider2D.enabled = false;
        Derrotado = true;
        EventoPersonajeDerrotado?.Invoke();
        
    }

    public void ResturarPersonaje()
    {
        _boxcollider2D.enabled = true;
        Derrotado = false;
        Salud = saludInicial;
        ActualizarBarraVida(Salud, saludInicial);

    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        UIManagger.Instance.ActualizarVidaPersonaje(vidaActual, vidaMax);

    }
}