using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // UI Text элемент для отображения диалогов
    public Button nextButton; // Кнопка для перехода к следующему диалогу

    private string[] dialogues; // Массив строк с диалогами
    private int currentDialogueIndex; // Индекс текущего диалога

    void Start()
    {
        // Пример диалогов
        dialogues = new string[]
        {
            "Вот я и снова здесь, в этом забытом Богом городе.",
            "Оля, привет! Рад тебя видеть. Как ты?",
            "Все хорошо. Слушай, Дмитрий хочет тебя увидеть."
        };
        currentDialogueIndex = 0;
        ShowDialogue();
    }

    // Метод для отображения текущего диалога
    void ShowDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            // Когда все диалоги показаны, скрываем диалоговое окно или делаем переход на следующую сцену
            dialogueText.text = "Диалоги закончились.";
            nextButton.gameObject.SetActive(false);
        }
    }

    // Метод, вызываемый при нажатии на кнопку "Next"
    public void NextDialogue()
    {
        currentDialogueIndex++;
        ShowDialogue();
    }
}