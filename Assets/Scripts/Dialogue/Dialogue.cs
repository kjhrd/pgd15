using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; // Имя персонажа
    [TextArea(3, 10)]
    public string[] sentences; // Массив предложений диалога
    public DialogueTrigger trigger;
}
