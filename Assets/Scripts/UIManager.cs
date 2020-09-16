using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthSlider;
    public Text tokenText;

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void UpdateTokens(int tokens)
    {
        tokenText.text = tokens.ToString();
    }

}
