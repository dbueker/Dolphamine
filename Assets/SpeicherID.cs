using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeicherID : MonoBehaviour
{
    public Text inputText;
    public Text placeHolderText;
    public GameObject button;
    private void Start()
    {
        if(Messung.idWasSet)
        {
            placeHolderText.text = Messung.id;
            button.SetActive(false);
        }
    }

    public void Speichern()
    {
        if(Messung.idWasSet == false)
        {
            Messung.id = inputText.text;
        }
        Messung.idWasSet = true;
    }
}
