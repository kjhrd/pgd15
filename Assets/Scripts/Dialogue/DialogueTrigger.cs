using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; // Ссылка на диалог

    public bool isStarted = false;

    DialogueManager manager;

    public void TriggerDialogue()
    {
        manager = FindObjectOfType<DialogueManager>();

        if (!isStarted)
        {
            manager.StartDialogue(dialogue); // Запуск диалога через DialogueManager
        }
    }

    public void Update()
    {
        if (!isStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                manager.DisplayNextSentence();
            }
        }
    }
}
