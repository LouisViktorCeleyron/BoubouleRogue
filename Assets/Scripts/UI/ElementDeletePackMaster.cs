using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[System.Serializable]
public class ElementDeletePackSubMaster
{
    //Faut vrmnt que je passe par une delegate ou une optimisation du bail donc temporaire
    public bool use;
    private Element _elementToDelete;
    [SerializeField]
    private Image _previewImage;
    [SerializeField]
    private GameObject _areYouSureButton;
    
    private PlayerManager _playerManager;
    private MySceneManager _sceneManager;


    public void Init()
    {
        _playerManager = ManagerManager.GetManager<PlayerManager>();
        _sceneManager = ManagerManager.GetManager<MySceneManager>();
    }

    public void Reset()
    {
        _areYouSureButton.SetActive(false);
    }

    public void RegisterElementToDelete(Element elementToDelete)
    {
        _elementToDelete = elementToDelete;
        _areYouSureButton.SetActive(true);
        _previewImage.sprite = elementToDelete.icone;
    }

    public void Sure()
    {
        _playerManager.RemoveElement(_elementToDelete);
        _sceneManager.LoadMap();//Temporaire
    }

}
