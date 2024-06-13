using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // UI Text ������� ��� ����������� ��������
    public Button nextButton; // ������ ��� �������� � ���������� �������
    public Button nextScene;

    private string[] dialogues; // ������ ����� � ���������
    private int currentDialogueIndex; // ������ �������� �������

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
                // ������ ��������
        if (SceneManager.GetActiveScene().name == "Station")
        {
            dialogues = new string[]
            {
                "(���������� ������� �������) ��� � � ����� �����, � ���� ������� ����� ������. ������� ��� ������, � �� ����� �� ���������.",
                "(�����) �������! ��� �� ����� �� �� ��������!",
                "(�������) ���, ������! ��� ���� ������. ��� ��?",
                "(�����) ��� ������. ������, ������� ����� ���� �������. � ���� ���� ���-��� ������.",
            };
        }
        else if (SceneManager.GetActiveScene().name == "Cafe")
        {
            dialogues = new string[]
            {
                "(�������) �������, ���� ���, ������� ���, ������� ���!",
                "(�������) �������, ��� ���� ������. ��� �������, ��� � ���� ���� ���-�� ������.",
                "(�������) ��, ��� ������� � ����� ������ �����. � ����� ����� ��������."
            };
        }
        else if (SceneManager.GetActiveScene().name == "OldHouse")
        {
            dialogues = new string[]
            {
                "(�������) ����� ��� ���, ��� � �����. �� ������ �� ������, ��� ����� ���-�� ��������?",
                "(�������) � ������� ����� ���� ���� �������, � ������� ����� �� ����. � ����� ������ ������� ������ ����."
            };
        }
        else if (SceneManager.GetActiveScene().name == "Basement")
        {
            dialogues = new string[]
            {
                "(�������) ��� ����������... ��� ���� ������� �� ������� �� ����.",
                "(�������) � �����, ��� �� ������� ���-�� ������. ��������, ��� ������� � ��� �������������.",
            };
        }
        else if (SceneManager.GetActiveScene().name == "ChamberSecrets")
        {
            dialogues = new string[]
            {
                "(�������) ��� ��� ��� �������... ��� ����� ������ ������.",
                "(�������) � ������ ����. �� ������ �����������, ��� ��������� � ����� �����."
            };
        }
        else if (SceneManager.GetActiveScene().name == "Library")
        {
            dialogues = new string[]
            {
                "(�������) �� ������ � ������ ����. � ��������, ��� ������� ��� ���� ��� ����� �������.",
                "(�������) ��� �� �� ���������, �� �������� ��� �����."
            };
        }
    }
    
    // ����� ��� ����������� �������� �������
    void ShowDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            // ����� ��� ������� ��������, ��������� �������� � ��������� �� ��������� �����
            GameData.SaveGame(SceneManager.GetActiveScene().name, currentDialogueIndex);
            SceneController sceneController = FindObjectOfType<SceneController>();
            if (sceneController != null)
            {
                sceneController.ChangeScene(GetNextSceneName());
            }
            else
            {
                dialogueText.text = "������� �����������.";
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
            return "Station"; // ��� ����� ����
    }
    
    // �����, ���������� ��� ������� �� ������ "Next"
    private void NextDialogue()
    {
        currentDialogueIndex++;
        ShowDialogue();
    }
}