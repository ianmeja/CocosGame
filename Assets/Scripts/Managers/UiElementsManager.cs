using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiElementsManager : MonoBehaviour
{
    #region Unity_Events
    private void Start()
    {
        EventsManager.instance.OnCharacterLifeChange += OnCharacterLifeChange;
    }
    #endregion

    #region LIFE_BAR_LOGIC
    [SerializeField] private Image _lifebar;
    [SerializeField] private Text _lifePercent;

    private void OnCharacterLifeChange(int currentLife, int maxLife)
    {
        float percent = (float)currentLife / (float)maxLife;
        Color color = percent < .1f ? Color.red 
                             : percent < .25f ? Color.yellow 
                             : Color.green;

        _lifebar.fillAmount = percent;
        _lifebar.color = color;

        _lifePercent.text = $"{ percent * 100 }%";
        _lifePercent.color = color;
    }
    #endregion
}
