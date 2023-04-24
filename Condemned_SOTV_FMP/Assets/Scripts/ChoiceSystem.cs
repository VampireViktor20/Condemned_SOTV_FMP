using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceSystem : MonoBehaviour
{
    public Text DialogueText;
    public GameObject dialogueBox;
    public Text wrongChoiceText;
    public GameObject wrongChoiceBox;

    [Header("Choice Buttons")]
    public GameObject startChoice1;
    public GameObject startChoice2;
    public GameObject choice1A1;
    public GameObject choice1A2;
    public GameObject choice1B1;
    public GameObject choice1B2;
    public GameObject choice2A1;
    public GameObject choice2A2;
    public GameObject choice2B1;
    public GameObject choice2B2;
    public GameObject choice3A1;
    public GameObject choice3A2;
    public GameObject choice3B1;
    public GameObject choice3B2;
 


    public int choiceMade;

        void Start()
    {
        StartCoroutine(DialogueIntro());

    }
    void Update()
    {
       
    }


    public void StartChoice1()
    {
        choiceMade = 1;
        StartCoroutine(Dialogue1A());
        startChoice1.SetActive(false);
        startChoice2.SetActive(false);

    }

    public void StartChoice2()
    {
        choiceMade = 2;
        StartCoroutine(Dialogue1B());
        startChoice1.SetActive(false);
        startChoice2.SetActive(false);
    }

    public void Choice1A1()
    {
        choiceMade = 1;
        StartCoroutine(Dialogue2A());
        choice1A1.SetActive(false);
        choice1A2.SetActive(false);

    }

    public void Choice1A2()
    {
        choiceMade = 2;
        StartCoroutine(WrongChoice());
    }

    public void Choice1B1()
    {
        choiceMade = 1;
        StartCoroutine(WrongChoice());

    }
    public void Choice1B2()
    {
        choiceMade = 2;
        StartCoroutine(Dialogue2B());
        choice1B1.SetActive(false);
        choice1B2.SetActive(false);
    }

    public void Choice2A1()
    {
        choiceMade = 1;
        StartCoroutine(WrongChoice());

    }

    public void Choice2A2()
    {
        choiceMade = 2;
        StartCoroutine(Dialogue3A());
        choice2A1.SetActive(false);
        choice2A2.SetActive(false);
    }

    public void Choice2B1()
    {
        choiceMade = 1;
        StartCoroutine(Dialogue3B());
        choice2B1.SetActive(false);
        choice2B2.SetActive(false);
    }

    public void Choice2B2()
    {
        choiceMade = 2;
        StartCoroutine(WrongChoice());

    }

    public void Choice3A1()
    {
        choiceMade = 1;
        StartCoroutine(Dialogue4A());
        choice3A1.SetActive(false);
        choice3A2.SetActive(false);
    }
    public void Choice3A2()
    {
        choiceMade = 2;
        StartCoroutine(Dialogue4B());
        choice3A1.SetActive(false);
        choice3A2.SetActive(false);
    }
    public void Choice3B1()
    {
        choiceMade = 1;
        StartCoroutine(Dialogue4B());
        choice3B1.SetActive(false);
        choice3B2.SetActive(false);
    }
    public void Choice3B2()
    {
        choiceMade = 2;
        StartCoroutine(Dialogue3A());
        choice3B1.SetActive(false);
        choice3B2.SetActive(false);

    }
   

    public IEnumerator DialogueIntro()
    {
        DialogueText.GetComponent<Text>().text = "SO, YOU FINALLY MADE IT TO THE VEIL? YOU KNEW IT WAS GOING TO HAPPEN SOONER OR LATER...";
        yield return new WaitForSeconds(5f);
        DialogueText.GetComponent<Text>().text = "DO YOU UNDERSTAND WHY YOU HAVE BEEN BROUGHT HERE?";
        yield return new WaitForSeconds(3f);
        startChoice1.SetActive(true);
        startChoice2.SetActive(true);
    }

    public IEnumerator WrongChoice()
    {
        dialogueBox.SetActive(false);
        yield return new WaitForSeconds(0f);
        wrongChoiceBox.SetActive(true);
        wrongChoiceText.GetComponent<Text>().text = "YOU DO WISH NOT TO DISCUSS IT? YOU'RE ONLY CONDEMNING YOURSELF FURTHER!";
        yield return new WaitForSeconds(5f);
        wrongChoiceBox.SetActive(false);
        dialogueBox.SetActive(true);

        
    }

    public IEnumerator Dialogue1A()
    {
        yield return new WaitForSeconds(1f);
        DialogueText.GetComponent<Text>().text = "YOU ADMIT THAT YOU’RE STRUGGLING THEN? IS THAT ALL?";
        yield return new WaitForSeconds(4f);
        DialogueText.GetComponent<Text>().text = "WHAT IS IT EXACLY YOU ARE STRUGGLING WITH SINCE YOU’VE COME ALL THIS WAY…";
        yield return new WaitForSeconds(4f);
        choice1A1.SetActive(true);
        choice1A2.SetActive(true);
       

    }
    public IEnumerator Dialogue1B()
    {
        yield return new WaitForSeconds(1f);
        DialogueText.GetComponent<Text>().text = "THE POLAROID’S HELPED YOU PIECE TOGETHER AND UNCOVER YOUR PAST";
        yield return new WaitForSeconds(5f);
        DialogueText.GetComponent<Text>().text = "DID YOU LEARN ANYTHING OTHER THAN MAKING A COLLAGE?";
        yield return new WaitForSeconds(3f);
        choice1B1.SetActive(true);
        choice1B2.SetActive(true);

    }
    public IEnumerator Dialogue2A()
    {
        yield return new WaitForSeconds(1f);
        DialogueText.GetComponent<Text>().text = "IS THAT SO? WOULD YOU SAY IT HAS BECOME TOO MUCH TO HANDLE ALONE?";
        yield return new WaitForSeconds(5f);
        DialogueText.GetComponent<Text>().text = "SO MUCH THAT IT'S TIME TO LOOK FOR SUPPORT?";
        yield return new WaitForSeconds(3f);
        choice2A1.SetActive(true);
        choice2A2.SetActive(true);
    }
    public IEnumerator Dialogue2B()
    {
        yield return new WaitForSeconds(1f);
        DialogueText.GetComponent<Text>().text = "LIFE? TRUST ME, THIS IS SOMETHING THAT WILL ONLY GET WORSE IF YOU DON’T SEEK HELP!";
        yield return new WaitForSeconds(5f);
        DialogueText.GetComponent<Text>().text = "DO YOU KNOW WHAT IS CONDEMNING YOU?";
        yield return new WaitForSeconds(3f);
        choice2B1.SetActive(true);
        choice2B2.SetActive(true);
        
    }
    public IEnumerator Dialogue3A()
    {
        yield return new WaitForSeconds(1f);
        DialogueText.GetComponent<Text>().text = "THAT’S WHAT I WANTED TO HEAR! REALISING IS THE FIRST PART BUT…";
        yield return new WaitForSeconds(5f);
        DialogueText.GetComponent<Text>().text = "ARE YOU WILLING TO ACCEPT OR DENY THE ONE OF MANY FORMS CONDEMNING YOU?";
        yield return new WaitForSeconds(3f);
        choice3A1.SetActive(true);
        choice3A2.SetActive(true);
    }
    public IEnumerator Dialogue3B()
    {
        yield return new WaitForSeconds(1f);
        DialogueText.GetComponent<Text>().text = "TO YOU I’M NOT, JUST AN UNFORTUNATE SOUL TRYING TO REACH OUT TO OTHERS LIKE YOURSELF WHO ARE SUFFERING.";
        yield return new WaitForSeconds(5f);
        DialogueText.GetComponent<Text>().text = "WHAT DID YOU THINK THE EMAILS WERE FOR? AFTERALL…";
        yield return new WaitForSeconds(2f);
        DialogueText.GetComponent<Text>().text = "YOU SENT THEM TO YOURSELF.";
        yield return new WaitForSeconds(1f);
        choice3B1.SetActive(true);
        choice3B2.SetActive(true);
        

    }
    public IEnumerator Dialogue4A()
    {
        yield return new WaitForSeconds(1f);
        DialogueText.GetComponent<Text>().text = "YOU’VE COME TO TERMS WITH WHAT’S CONDEMNING YOU.";
        yield return new WaitForSeconds(5f);
        DialogueText.GetComponent<Text>().text = "YOUR SOUL HAS BEEN SPARED FROM THE VEIL AND NOW THE REST IS UP TO YOU…";
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Ending");

    }
    public IEnumerator Dialogue4B()
    {
        yield return new WaitForSeconds(1f);
        DialogueText.GetComponent<Text>().text = "THERE IS ONLY SO MUCH THAT CAN BE DONE TO MAKE YOU REALISE...";
        yield return new WaitForSeconds(4f);
        DialogueText.GetComponent<Text>().text = "IT SEEMS YOU ARE NOT READY TO ACCEPT THE TRUTH…";
        yield return new WaitForSeconds(5f);
        DialogueText.GetComponent<Text>().text = "YOU SHALL NOW ENTER THE VEIL ONCE MORE TO FACE YOUR DEMONS";
        yield return new WaitForSeconds(2F);
        SceneManager.LoadScene("Veil");
    }






}
