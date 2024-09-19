
using UnityEngine;
using TMPro;
using System;

public class KeyCounter : MonoBehaviour
{
    public Action KeyFound { get; private set; }
    [SerializeField] private int maxKeyAmount;
    [SerializeField] private TextMeshProUGUI counterUi;
    [SerializeField] private GameObject door;
    private static int currAmount = 0;


    void Start()
    {
        currAmount = 0;
        KeyFound = () => ShowKey();
        counterUi.text = $"{currAmount}/{maxKeyAmount}";
    }

    private void ShowKey ()
    {
        currAmount = currAmount > maxKeyAmount ? maxKeyAmount : currAmount+1;
       
        counterUi.text = $"{currAmount}/{maxKeyAmount}";

        if (currAmount == maxKeyAmount)
        {
            counterUi.text = "Find the door";
            door.SetActive(true);
        }
            
    }
}
