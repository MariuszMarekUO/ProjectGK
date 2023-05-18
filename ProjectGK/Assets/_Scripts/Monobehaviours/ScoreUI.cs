using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] GameObject scoreboardElementPrefab;
    [SerializeField] Transform elementWrapper;
    [SerializeField] ScoreMenager scoreMenager;

    List<GameObject> scoreboardElements = new List<GameObject>();

    private void OnEnable()
    {
        ScoreMenager.onScoreListChanged += UpdateUI;
    }

    private void OnDisable()
    {
        ScoreMenager.onScoreListChanged -= UpdateUI;
    }

    private void UpdateUI(List<Score> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Score el = list[i];

            if (el != null && el.distance > 0)
            {
                if (i >= scoreboardElements.Count)
                {
                    // instantiate new entry
                    var inst = Instantiate(scoreboardElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);

                    scoreboardElements.Add(inst);
                }

                // write or overwrite name & points
                var texts = scoreboardElements[i].GetComponentsInChildren<TextMeshProUGUI>();
                texts[0].text = (i + 1).ToString();
                texts[1].text = el.name;
                var _d = Decimal.Round(((decimal)(el.distance)), 2);
                texts[2].text = _d.ToString();
            }
        }
    }
}
