using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // UI Text ������� ��� ����������� ��������
    public Button nextButton; // ������ ��� �������� � ���������� �������

    private string[] dialogues; // ������ ����� � ���������
    private int currentDialogueIndex; // ������ �������� �������

    void Start()
    {
        // ������ ��������
        dialogues = new string[]
        {
            "��� � � ����� �����, � ���� ������� ����� ������.",
            "���, ������! ��� ���� ������. ��� ��?",
            "��� ������. ������, ������� ����� ���� �������."
        };
        currentDialogueIndex = 0;
        ShowDialogue();
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