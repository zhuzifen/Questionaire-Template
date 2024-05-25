using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    int currentQuestionIndex = 0;
    QuestionSO currentQuestion;
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] Sprite defaultAnswerSpriteGreen;
    [SerializeField] Sprite defaultAnswerSpriteRed;
    [SerializeField] Sprite defaultAnswerSpriteBlue;
    [SerializeField] Sprite clickedAnswerSprite;
    string savedResponses = "";
    [SerializeField] GameObject buttonGroup;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject sideNote;
    [SerializeField] GameObject logo1;
    [SerializeField] GameObject logo2;
    

    void Start()
    {
        currentQuestion = questions[0];
        questionText.text = currentQuestion.GetQuestion();
        buttonGroup.SetActive(false);
        logo1.SetActive(false);
        logo2.SetActive(false);
    }

    public void OnButtonClicked() {
        currentQuestionIndex++;
        GetNextQuestion();
        startButton.SetActive(false);
        sideNote.SetActive(false);
        buttonGroup.SetActive(true);
    }
    public void OnAnswerSelected(int index) {
        savedResponses += (index + 1).ToString();
        if (currentQuestionIndex % 4 == 0) {
            savedResponses += "\n";
        }
        Image buttonImage = answerButtons[index].GetComponent<Image>();
        buttonImage.sprite = clickedAnswerSprite;
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count - 1) {
            Thread.Sleep(1000);
            GetNextQuestion();
        }
        else {
            questionText.text = questions[questions.Count - 1].GetQuestion() + "\n" + savedResponses;
            buttonGroup.SetActive(false);
            logo1.SetActive(true);
            logo2.SetActive(true);
        }
    }

    void GetNextQuestion() {
        setDefaultButtonSprites();
        currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.GetQuestion();
    }

    void setDefaultButtonSprites() {
        Image buttonImage0 = answerButtons[0].GetComponent<Image>();
        buttonImage0.sprite = defaultAnswerSpriteGreen;
        Image buttonImage1 = answerButtons[1].GetComponent<Image>();
        buttonImage1.sprite = defaultAnswerSpriteGreen;
        Image buttonImage2 = answerButtons[2].GetComponent<Image>();
        buttonImage2.sprite = defaultAnswerSpriteRed;
        Image buttonImage3 = answerButtons[3].GetComponent<Image>();
        buttonImage3.sprite = defaultAnswerSpriteBlue;
        Image buttonImage4 = answerButtons[4].GetComponent<Image>();
        buttonImage4.sprite = defaultAnswerSpriteBlue;
    }

}
