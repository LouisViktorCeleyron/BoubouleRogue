using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapMaster : MonoBehaviour
{

    private int _floorOnMap;
    private JourneyManager _journeyManager;
    
    private List<MapButton> _mapButtons;

    private void Start()
    {
        _journeyManager = ManagerManager.GetManager<JourneyManager>();
        _mapButtons = new List<MapButton>();
        _mapButtons = FindObjectsOfType<MapButton>().ToList(); //degeulasse mais pas le choix pour l'instant
        foreach (var button in _mapButtons)
        {
            button.SetUp(_journeyManager.GetFloor());
        }
    }
}

