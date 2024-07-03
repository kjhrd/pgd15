using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    [SerializeField]private List<KeyCode> possibleKeys = new(){ KeyCode.Z, KeyCode.B, KeyCode.C, KeyCode.X, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.N, KeyCode.M, KeyCode.L, KeyCode.T };

    // Список для хранения текущего сочетания клавиш
    public List<KeyCode> currentCombination = new();

    public TMPro.TextMeshPro com;

    // Длина сочетания клавиш
    public int combinationLength = 2;

    public bool isResqued = false;

    public void Update()
    {
        if (isResqued )
        {
            com.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        GenerateRandomCombination();
    }
    public void GenerateRandomCombination()
    {
        currentCombination.Clear();
        for (int i = 0; i < combinationLength; i++)
        {
            int r = Random.Range(0, possibleKeys.Count);
            KeyCode randomKey = possibleKeys[r];
            currentCombination.Add(randomKey);
            possibleKeys.RemoveAt(r);
        }

        // Отобразим сгенерированное сочетание клавиш в консоли
        string combination = "";
        foreach (KeyCode key in currentCombination)
        {
            combination += key.ToString() + " ";
            print(combination);
            possibleKeys.Add(key);
        }
        com.text = combination;
        
    }
    public bool InputCombinationMatched()
    {
        for (int i = 0; i < currentCombination.Count; i++)
        {
            if (!Input.GetKey(currentCombination[i]))
            {
                return false;
            }
            else print("ok");
        }
        return true;
    }
}
