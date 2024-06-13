using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // UI Text элемент для отображения диалогов
    public Button nextButton; // Кнопка для перехода к следующему диалогу
    public Button nextScene;

    private string[] dialogues; // Массив строк с диалогами
    private int currentDialogueIndex; // Индекс текущего диалога

    void Start()
    {
        string currentScene;
        GameData.LoadGame(out currentScene, out currentDialogueIndex);

        if (SceneManager.GetActiveScene().name != currentScene)
        {
            SceneManager.LoadScene(currentScene);
            return;
        }
        
        if (nextScene)
        {
            nextScene.gameObject.SetActive(false);
        }
        
        SetDialoguesForScene();
        currentDialogueIndex = 0;
        ShowDialogue();
        nextButton.onClick.AddListener(NextDialogue);
    }

    void SetDialoguesForScene()
    {
                // Пример диалогов
        if (SceneManager.GetActiveScene().name == "Station")
        {
            dialogues = new string[]
            {
                "(Внутренний монолог Алексея) Вот я и снова здесь, в этом забытом Богом городе. Столько лет прошло, а он почти не изменился.",
                "(Ольга) Алексей! Как же давно мы не виделись!",
                "(Алексей) Оля, привет! Рад тебя видеть. Как ты?",
                "(Ольга) Все хорошо. Слушай, Дмитрий хочет тебя увидеть. У него есть кое-что важное.",
            };
        }
        else if (SceneManager.GetActiveScene().name == "Cafe")
        {
            dialogues = new string[]
            {
                "(Дмитрий) Алексей, друг мой, сколько лет, сколько зим!",
                "(Алексей) Дмитрий, рад тебя видеть. Оля сказала, что у тебя есть что-то важное.",
                "(Дмитрий) Да, это связано с твоим старым домом. Я нашел нечто странное."
            };
        }
        else if (SceneManager.GetActiveScene().name == "OldHouse")
        {
            dialogues = new string[]
            {
                "(Алексей) Здесь все так, как я помню. Но почему ты сказал, что нашел что-то странное?",
                "(Дмитрий) В подвале этого дома есть комната, о которой никто не знал. Я нашел старый дневник твоего отца."
            };
        }
        else if (SceneManager.GetActiveScene().name == "Basement")
        {
            dialogues = new string[]
            {
                "(Алексей) Это невозможно... Мой отец никогда не говорил об этом.",
                "(Дмитрий) Я думаю, что он скрывал что-то важное. Возможно, это связано с его исчезновением.",
            };
        }
        else if (SceneManager.GetActiveScene().name == "ChamberSecrets")
        {
            dialogues = new string[]
            {
                "(Алексей) Все это так странно... Мне нужно узнать больше.",
                "(Дмитрий) Я помогу тебе. Мы должны разобраться, что произошло с твоим отцом."
            };
        }
        else if (SceneManager.GetActiveScene().name == "Library")
        {
            dialogues = new string[]
            {
                "(Дмитрий) Мы только в начале пути. Я чувствую, что впереди нас ждет еще много загадок.",
                "(Алексей) Что бы ни произошло, мы раскроем эту тайну."
            };
        }
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
            // Когда все диалоги показаны, сохраняем прогресс и переходим на следующую сцену
            GameData.SaveGame(SceneManager.GetActiveScene().name, currentDialogueIndex);
            SceneController sceneController = FindObjectOfType<SceneController>();
            if (sceneController != null)
            {
                sceneController.ChangeScene(GetNextSceneName());
            }
            else
            {
                dialogueText.text = "Диалоги закончились.";
                nextButton.gameObject.SetActive(false);
                nextScene.gameObject.SetActive(true);
            }
            
        }
    }

    string GetNextSceneName()
    {
        if (SceneManager.GetActiveScene().name == "Station")
            return "Cafe";
        else if (SceneManager.GetActiveScene().name == "Cafe")
            return "OldHouse";
        else if (SceneManager.GetActiveScene().name == "OldHouse")
            return "Basement";
        else if (SceneManager.GetActiveScene().name == "Basement")
            return "ChamberSecrets"; 
        else if (SceneManager.GetActiveScene().name == "ChamberSecrets")
            return "Library";
        else
            return "Station"; // Или конец игры
    }
    
    // Метод, вызываемый при нажатии на кнопку "Next"
    private void NextDialogue()
    {
        currentDialogueIndex++;
        ShowDialogue();
    }
}