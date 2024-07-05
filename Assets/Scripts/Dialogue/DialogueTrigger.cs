using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; // Ссылка на диалог

    public bool isStarted = false;

    private bool isFinished = false;

    DialogueManager manager;

    public void TriggerDialogue()
    {
        manager = FindObjectOfType<DialogueManager>();

        if (!isStarted)
        {
            manager.StartDialogue(dialogue); // Запуск диалога в DialogueManager
            isFinished = true;
        }
    }

    public void Update()
    {
        if (!isStarted && isFinished)
        {
            if (Input.GetMouseButtonDown(0))
            {
                manager.DisplayNextSentence();
            }
        }
    }
}
