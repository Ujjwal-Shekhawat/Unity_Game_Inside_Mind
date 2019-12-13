using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story_Line : MonoBehaviour
{

    public Text Dialogue;
    public string[] dialogues;
    private int index = 0;
    private void Start()
    {
        //Dialogue = GetComponent<Text>();
        StartCoroutine(Story_Going());
        Dialogue.fontSize = 56;
    }

    private void Update()
    {

    }

    IEnumerator Story_Going()
    {
        if (index < dialogues.Length)
        {
            Dialogue.rectTransform.position = new Vector2(Random.Range(600, 800), Random.Range(200, 400));
            Dialogue.text = dialogues[index];
            index += 1;
        }
        else
        {
            Dialogue.text = "You are hopeless lets see you suffer and die";
        }
        yield return new WaitForSeconds(10.0f);

        if (index < dialogues.Length)
        {
            StartCoroutine(Story_Going());
        }
    }
}
