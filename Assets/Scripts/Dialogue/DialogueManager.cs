using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // ������ �� ��������� TextMeshPro ��� ������ �������
    public GameObject dialoguePanel; // ������ �� ������ �������

    private Queue<string> sentences; // ������� ��� �������� ����������� �������

    private Dialogue d;

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false); // �������� ������ ������� � ������
    }

    public void StartDialogue(Dialogue dialogue)
    {
        d = dialogue;
        dialoguePanel.SetActive(true); // ���������� ������ �������
        sentences.Clear(); // ������� ������� �����������

        foreach (string sentence in d.sentences)
        {
            sentences.Enqueue(sentence); // ��������� ����������� � �������
        }

        DisplayNextSentence(); // ���������� ������ �����������
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); // �������� ��������� �����������
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); // ��������� �������� ��� ������ �����������
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter; // �������� ����������� �� �����
            yield return new WaitForSeconds(0.07f);
        }
    }

    void EndDialogue()
    {
        d.trigger.isStarted = true;
        dialoguePanel.SetActive(false); // �������� ������ �������
    }
}
