using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    [SerializeField] ScoreMenager scoreMenager;
    [SerializeField] DistanceMenager distanceMenager;
    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameUI;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        distanceMenager = GameObject.FindGameObjectWithTag("Player").GetComponent<DistanceMenager>();
    }

    public void EndGame()
    {
        GameUI.SetActive(false);
        GameOver.SetActive(true);
        scoreText.text = (distanceMenager.DistanceDec).ToString();
    }

    public void AddButton()
    {
        string name = usernameInput.text;
        var distance = distanceMenager.Distance;
        Score score = new Score(name, distance);
        scoreMenager.AddNewScore(score);
    }
}
