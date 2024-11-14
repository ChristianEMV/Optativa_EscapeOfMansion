using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class UIManagger : Singleton<UIManagger>
{
    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [SerializeField] private Image manaPlayer;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;

    [Header("Paneles")]
    [SerializeField] private GameObject panelInventario;

    private float vidaActual;
    private float vidaMax;

    private float manaActual;
    private float manaMax;

    void Update()
    {
        ActualziarUIPersonaje();
        
    }

    private void ActualziarUIPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount,
            vidaActual / vidaMax, 10f * Time.deltaTime);

        manaPlayer.fillAmount = Mathf.Lerp(manaPlayer.fillAmount,
            manaActual / manaMax, 10f * Time.deltaTime);

        vidaTMP.text = $"{vidaActual} / {vidaMax}";

        manaTMP.text = $"{manaActual} / {manaMax}";
    
    }

    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax)
    {
        vidaActual = pVidaActual;
        vidaMax = pVidaMax;
    
    }

    public void ActualizarManaPersonaje(float pManaActual, float pManaMax)
    {
        manaActual = pManaActual;
        manaMax = pManaMax;

    }

    #region Paneles

    public void AbrirCerrarPanelInventario()
    {
        panelInventario.SetActive(!panelInventario.activeSelf);
    
    }

    #endregion
}
