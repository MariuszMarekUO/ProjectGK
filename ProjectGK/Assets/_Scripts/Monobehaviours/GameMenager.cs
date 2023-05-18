using TMPro;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    [SerializeField] ScoreMenager scoreMenager;
    [SerializeField] DistanceMenager distanceMenager;
    //[SerializeField] GameObject usernameInput;
    public string text;
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
        scoreText.text = (distanceMenager.D).ToString();
    }

    public void AddButton()
    {
        Debug.Log("add");
        //var name = usernameInput.GetComponent<InputField>().text;
        Debug.Log("text");
        var distance = distanceMenager.Distance;
        Debug.Log("distance");
        Score score = new Score(text, distance);
        scoreMenager.AddNewScore(score);
    }

}
