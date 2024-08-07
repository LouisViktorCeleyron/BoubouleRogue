using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : Manager
{
    [SerializeField]
    private GameObject _runUIBand;
    [SerializeField]
    private TextMeshProUGUI _stairsText, _goldText,_healthText;
    [SerializeField]
    private GameObject _feedbackUI, _packIcon;
    [SerializeField]
    private ElementPackMaster _packUIMaster;

    private JourneyManager _journeyManager;
    private PlayerManager _playerManager;

    public bool IsUIOnFront()
    {
        return _packUIMaster.gameObject.activeInHierarchy;
    }

    public override void ManagerPreAwake()
    {
        _journeyManager = ManagerManager.GetManager<JourneyManager>();
        _playerManager = ManagerManager.GetManager<PlayerManager>();
    }

    public override void ManagerPostAwake()
    {
        _playerManager.onGoldChanged.Subscribe(UpdateGold);
        _playerManager.onHpChanged.Subscribe(UpdateHealth);
        _journeyManager.onFloorUp.Subscribe(UpdateStairs);
    }

    public void DisplayRunUIBand(bool isActive = true)
    {
        _runUIBand.SetActive(isActive);
        DisplayPackIcon(isActive);

    }

    public void DisplayPackIcon(bool value)
    {
        _packIcon.SetActive(value);
    }

    public void ActivatePackUI(bool toDelete = false)
    {
        if(toDelete)
        {
            _packUIMaster.elementDeletePackSubMaster.use = true;
        }
        _packUIMaster.gameObject.SetActive(true);
        _packIcon.SetActive(false);
    }
    public void DesactivatePackUI()
    {
        _packUIMaster.gameObject.SetActive(false);
        _packIcon.SetActive(true);
        _packUIMaster.elementDeletePackSubMaster.use = false;
        _packUIMaster.elementDeletePackSubMaster.Reset();

    }
    public void DisplayBattleFeedbackUI(bool isActive)
    {
        Debug.Log(isActive);
        _feedbackUI.SetActive(isActive);
    }

    public void UpdateStairs(int i)
    {
        _stairsText.text = i.ToString("00");
    }
    public void UpdateGold(int i)
    {
        _goldText.text = i.ToString("000");
    }

    public void UpdateHealth(int i)
    {
        _healthText.text = $"{i.ToString("00")}/{_playerManager.HpMax}";
    }
    public override void ManagerOnEachSceneLeft(Scene scene)
    {
        DisplayRunUIBand(false);
        DisplayBattleFeedbackUI(false);
        DesactivatePackUI();
    }


}
