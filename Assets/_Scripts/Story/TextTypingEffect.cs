using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class TextTypingEffect : MonoBehaviour
{
    public Text textComponent;
    public string[] textStrings;
    public float typingSpeed = 0.1f;
    public float delayBetweenTexts = 5f;

    private void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (string textString in textStrings)
        {
            // Clear the text component
            textComponent.text = "";

            // Type each character with a delay
            foreach (char c in textString)
            {
                textComponent.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }

            // Wait for a delay before displaying the next text
            yield return new WaitForSeconds(delayBetweenTexts);
        }

        // Load the next scene after displaying all the text
        SceneManager.LoadScene("AreaOne");
    }
}
