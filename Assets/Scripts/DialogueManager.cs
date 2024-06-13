using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI  dialogueText; // UI Text элемент для отображения диалогов
    public Button nextButton; // Кнопка для перехода к следующему диалогу

    private string[] dialogues; // Массив строк с диалогами
    private int currentDialogueIndex; // Индекс текущего диалога

    void Start()
    {
        // Пример диалогов
        if (SceneManager.GetActiveScene().name == "Station")
        {
            dialogues = new string[]
            {
                "Вот я и снова здесь, в этом забытом Богом городе. Столько лет прошло, а он почти не изменился.",
                "Алексей! Как же давно мы не виделись!",
                "Оля, привет! Рад тебя видеть. Как ты?",
                "Все хорошо. Слушай, Дмитрий хочет тебя увидеть. У него есть кое-что важное.",
            };
        }
        else if (SceneManager.GetActiveScene().name == "Cafe")
        {
            dialogues = new string[]
            {
                "Алексей, друг мой, сколько лет, сколько зим!",
                "Дмитрий, рад тебя видеть. Оля сказала, что у тебя есть что-то важное.",
                "Да, это связано с твоим старым домом. Я нашел нечто странное."
            };
        }
        else if (SceneManager.GetActiveScene().name == "OldHouse")
        {
            dialogues = new string[]
            {
                "Здесь все так, как я помню. Но почему ты сказал, что нашел что-то странное?",
                "В подвале этого дома есть комната, о которой никто не знал. Я нашел старый дневник твоего отца."
            };
        }
        else if (SceneManager.GetActiveScene().name == "Basement")
        {
            dialogues = new string[]
            {
                "Это невозможно... Мой отец никогда не говорил об этом.",
                "Я думаю, что он скрывал что-то важное. Возможно, это связано с его исчезновением.",
            };
        }
        else if (SceneManager.GetActiveScene().name == "ChamberSecrets")
        {
            dialogues = new string[]
            {
                "Все это так странно... Мне нужно узнать больше.",
                "Я помогу тебе. Мы должны разобраться, что произошло с твоим отцом."
            };
        }
        else if (SceneManager.GetActiveScene().name == "Library")
        {
            dialogues = new string[]
            {
                "Мы только в начале пути. Я чувствую, что впереди нас ждет еще много загадок.",
                "Что бы ни произошло, мы раскроем эту тайну."
            };
        }
        currentDialogueIndex = 0;
        ShowDialogue();
        nextButton.onClick.AddListener(NextDialogue);
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