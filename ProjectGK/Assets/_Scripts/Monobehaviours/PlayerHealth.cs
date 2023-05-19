using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    private int _health = 3;

    private bool _hasProtectiveShield = false;

    public bool HasProtectiveShield
    {
        get { return _hasProtectiveShield; }
        set { _hasProtectiveShield = value; }
    }

    void Start()
    {
        foreach(Image image in hearts)
        {
            image.sprite = fullHeart;
        }
    }

    public void TakeDamage()
    {
        if (!_hasProtectiveShield)
        {
            _health--;

            foreach (Image image in hearts)
            {
                image.sprite = emptyHeart;
            }
            for (int i = 0; i < _health; i++)
            {
                hearts[i].sprite = fullHeart;
            }

            if (_health <= 0)
            {
                // gameover
            }
        }
        else
        {
            _hasProtectiveShield = false;
        }
    }
}
