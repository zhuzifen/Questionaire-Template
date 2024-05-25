using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "问题";
    [SerializeField] string[] answers = {"1", "2", "3", "4", "5"};

    public string GetQuestion() {
        return question;
    }

    public string GetAnswer(int index) {
        return answers[index];
    }
}

