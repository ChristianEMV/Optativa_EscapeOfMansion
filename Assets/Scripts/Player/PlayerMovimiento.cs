using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad;

    public bool EnMovimeinto => _direccionMovimieto.magnitude > 0f;
    public Vector2 DireccionMovimiento => _direccionMovimieto;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _input;
    private Vector2 _direccionMovimieto;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //x
        if (_input.x > 0.1f)
        {
            _direccionMovimieto.x = 1f;
        }
        else if (_input.x < 0f)
        {
            _direccionMovimieto.x = -1f;
        }
        else {
            _direccionMovimieto.x = 0f;
        }

        //y
        if (_input.y > 0.1f)
        {
            _direccionMovimieto.y = 1f;
        }
        else if (_input.y < 0f)
        {
            _direccionMovimieto.y = -1f;
        }
        else
        {
            _direccionMovimieto.y = 0f;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direccionMovimieto * velocidad * Time.fixedDeltaTime);

    }
}
