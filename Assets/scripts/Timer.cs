using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 120f; // Tempo total em segundos (2 minutos)
    private float currentTime; // Tempo atual
    private Text timerText; // Referência ao componente Text

    private void Start()
    {
        timerText = GetComponent<Text>(); // Obtém o componente Text do objeto
        currentTime = totalTime; // Define o tempo inicial igual ao tempo total
    }

    private void Update()
    {
        // Verifica se o tempo atual é maior que zero
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime; // Decrementa o tempo atual com base no tempo real do jogo
            UpdateTimerDisplay(); // Atualiza a exibição do temporizador
        }
        else
        {
            // O tempo acabou, execute qualquer ação necessária
            // Exemplo: Encerrar o jogo, exibir uma mensagem, etc.
            Debug.Log("Tempo esgotado!");
        }
    }

    private void UpdateTimerDisplay()
    {
        // Converte o tempo atual em minutos e segundos formatados
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        // Atualiza o texto do temporizador
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
