using System.Collections.Generic;
using UnityEngine;


public class ScoreMenager : MonoBehaviour
{
    List<Score> scores = new List<Score>();
    [SerializeField] string filename;

    public delegate void OnScoreListChanged(List<Score> list);
    public static event OnScoreListChanged onScoreListChanged;

    private void Start()
    {
        LoadScores();
    }

    void LoadScores()
    {
        scores = FileHandler.ReadListFromJSON<Score>(filename);
      
        if (onScoreListChanged != null)
        {
            onScoreListChanged.Invoke(scores);
        }
    }

    void SaveScores()
    {
        FileHandler.SaveToJSON<Score>(scores, filename);
    }

    public void AddNewScore(Score score)
    {
        Debug.Log("addnew score");
        if(scores.Count == 0)
        {
            Debug.Log("insert1");
            scores.Add(score);

            SaveScores();

            if (onScoreListChanged != null)
            {
                onScoreListChanged.Invoke(scores);
            }

        }

        else
        {
            for (int i = 0; i < scores.Count; i++)
            {
                if (score.distance > scores[i].distance)
                {
                    Debug.Log("insert");

                    scores.Insert(i, score);

                    SaveScores();

                    if (onScoreListChanged != null)
                    {
                        onScoreListChanged.Invoke(scores);
                    }

                    break;
                }
            }
        }
        
    }
}
