using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI  dialogueText; // UI Text ������� ��� ����������� ��������
    public Button nextButton; // ������ ��� �������� � ���������� �������

    private string[] dialogues; // ������ ����� � ���������
    private int currentDialogueIndex; // ������ �������� �������

    void Start()
    {
        // ������ ��������
        if (SceneManager.GetActiveScene().name == "Station")
        {
            dialogues = new string[]
            {
                "��� � � ����� �����, � ���� ������� ����� ������. ������� ��� ������, � �� ����� �� ���������.",
                "�������! ��� �� ����� �� �� ��������!",
                "���, ������! ��� ���� ������. ��� ��?",
                "��� ������. ������, ������� ����� ���� �������. � ���� ���� ���-��� ������.",
            };
        }
        else if (SceneManager.GetActiveScene().name == "Cafe")
        {
            dialogues = new string[]
            {
                "�������, ���� ���, ������� ���, ������� ���!",
                "�������, ��� ���� ������. ��� �������, ��� � ���� ���� ���-�� ������.",
                "��, ��� ������� � ����� ������ �����. � ����� ����� ��������."
            };
        }
        else if (SceneManager.GetActiveScene().name == "OldHouse")
        {
            dialogues = new string[]
            {
                "����� ��� ���, ��� � �����. �� ������ �� ������, ��� ����� ���-�� ��������?",
                "� ������� ����� ���� ���� �������, � ������� ����� �� ����. � ����� ������ ������� ������ ����."
            };
        }
        else if (SceneManager.GetActiveScene().name == "Basement")
        {
            dialogues = new string[]
            {
                "��� ����������... ��� ���� ������� �� ������� �� ����.",
                "� �����, ��� �� ������� ���-�� ������. ��������, ��� ������� � ��� �������������.",
            };
        }
        else if (SceneManager.GetActiveScene().name == "ChamberSecrets")
        {
            dialogues = new string[]
            {
                "��� ��� ��� �������... ��� ����� ������ ������.",
                "� ������ ����. �� ������ �����������, ��� ��������� � ����� �����."
            };
        }
        else if (SceneManager.GetActiveScene().name == "Library")
        {
            dialogues = new string[]
            {
                "�� ������ � ������ ����. � ��������, ��� ������� ��� ���� ��� ����� �������.",
                "��� �� �� ���������, �� �������� ��� �����."
            };
        }
        currentDialogueIndex = 0;
        ShowDialogue();
        nextButton.onClick.AddListener(NextDialogue);
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
            // ����� ��� ������� ��������, �������� ���������� ���� ��� ������ ������� �� ��������� �����
            dialogueText.text = "������� �����������.";
            nextButton.gameObject.SetActive(false);
        }
    }

    // �����, ���������� ��� ������� �� ������ "Next"
    public void NextDialogue()
    {
        currentDialogueIndex++;
        ShowDialogue();
    }
}