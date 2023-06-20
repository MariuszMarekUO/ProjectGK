using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Animator[] hearts;
    [SerializeField] GameMenager gameMenager;

    private int _health = 3;

    private bool _hasProtectiveShield = false;

    public bool HasProtectiveShield
    {
        get { return _hasProtectiveShield; }
        set { _hasProtectiveShield = value; }
    }

    public void TakeDamage()
    {
        if (!_hasProtectiveShield)
        {
            _health--;

            hearts[_health].SetBool("HeartLost", true);

            if (_health <= 0)
            {
                gameMenager.EndGame();
            }
        }
        else
        {
            _hasProtectiveShield = false;
        }
    }
}
