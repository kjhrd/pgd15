using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // Ссылка на компонент TextMeshPro для текста диалога
    public GameObject dialoguePanel; // Ссылка на панель диалога

    private Queue<string> sentences; // Очередь для хранения предложений диалога

    private Dialogue d;

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false); // Скрываем панель диалога в начале
    }

    public void StartDialogue(Dialogue dialogue)
    {
        d = dialogue;
        dialoguePanel.SetActive(true); // Показываем панель диалога
        sentences.Clear(); // Очищаем очередь предложений

        foreach (string sentence in d.sentences)
        {
            sentences.Enqueue(sentence); // Добавляем предложения в очередь
        }

        DisplayNextSentence(); // Отображаем первое предложение
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); // Получаем следующее предложение
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); // Запускаем корутину для печати предложения
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter; // Печатаем предложение по букве
            yield return new WaitForSeconds(0.07f);
        }
    }

    void EndDialogue()
    {
        d.trigger.isStarted = true;
        dialoguePanel.SetActive(false); // Скрываем панель диалога
    }
}
