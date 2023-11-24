using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

public class UiElementsManager : MonoBehaviour
{
    #region Unity_Events
    private void Start()
    {
        EventsManager.instance.OnCharacterLifeChange += OnCharacterLifeChange;
        EventsManager.instance.OnWeaponChange += OnWeaponChange;
        EventsManager.instance.OnBulletCountChange += OnBulletCountChange;
        EventsManager.instance.OnAvatarChange += OnAvatarChange;
        EventsManager.instance.OnLevelChange += OnLevelChange;

        StartCoroutine(ContadorTotal());
    }
    #endregion

    #region LIFE_BAR_LOGIC
    [SerializeField] private Image _lifebar;
    [SerializeField] private Text _lifePercent;
    [SerializeField] private float _lifePercentValue = 1f;

    private void OnCharacterLifeChange(int currentLife, int maxLife)
    {
        _lifePercentValue = (float)currentLife / (float)maxLife;
        Color color = _lifePercentValue < .1f ? Color.red
                             : _lifePercentValue < .25f ? Color.yellow
                             : Color.green;

        _lifebar.fillAmount = _lifePercentValue;
        _lifebar.color = color;

        _lifePercent.text = $"{ _lifePercentValue * 100 }%";
        _lifePercent.color = color;
    }
    #endregion

    #region WEAPONS_UI_LOGIC
    [SerializeField] private List<Sprite> _weaponSprites;
    [SerializeField] private Image _weapon;
    [SerializeField] private Text _bulletInformation;

    // 0 -> Pistol 1 -> Machinegun 2 -> Shotgun
    private void OnWeaponChange(Weapon id) => _weapon.sprite = _weaponSprites[(int)id];
    private void OnBulletCountChange(int bulletCount, int maxBullet) => _bulletInformation.text = $"{bulletCount} de {maxBullet}";
    #endregion

    #region AVATAR_UI_LOGIC
    [SerializeField] private List<Sprite> _avatarSprites;
    [SerializeField] private Image _avatar;
    // 0 -> Normal 1 -> Bloody 2 -> Action
    private void OnAvatarChange(AvatarFace id)
    {
        _avatar.sprite = _avatarSprites[(int)id];

        if (id == AvatarFace.ActionFace)
        {
            Invoke("UpdateActionAvatarFace", 2);
        }
    }
    private void UpdateActionAvatarFace()
    {
        _avatar.sprite = _lifePercentValue > .25f
            ? _avatarSprites[(int)AvatarFace.NormalFace]
            : _avatarSprites[(int)AvatarFace.BloodyFace];
    }
    #endregion

    #region TIEMPO_UI_LOGIC
    [SerializeField] private Text _tiempoRestanteText;
    [SerializeField] private float _tiempoTotal = 120f;

    private IEnumerator ContadorTotal()
    {
        while (_tiempoTotal > 0)
        {
            if(_tiempoTotal < 120f){
                int minutes = Mathf.FloorToInt(_tiempoTotal / 60F);
                int seconds = Mathf.FloorToInt(_tiempoTotal - minutes * 60);

                _tiempoRestanteText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            yield return null;
            _tiempoTotal -= Time.deltaTime;
        }
        _tiempoRestanteText.text = "¡Fin!";
        EventsManager.instance.EventNewLevel();
    }
    #endregion

    #region NEXT_LEVEL_UI_LOGIC
    [SerializeField] private Text _endOfLevel;

    private void OnLevelChange()
    {
        _endOfLevel.text = "Dirigete hacia la puerta mágica!";
    }
    #endregion
}

