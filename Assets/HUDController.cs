using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Image image; // Referencia para o componente Image da imagem na HUD

    private void Start()
    {
        // Desativa a imagem no inicio do jogo
        image.gameObject.SetActive(false);

        // Chama o metodo que ativa a imagem apos 10 segundos
        Invoke("MostrarImagemHUD", 10f);
    }

    private void MostrarImagemHUD()
    {
        // Ativa a imagem na HUD
        image.gameObject.SetActive(true);
    }
}

