using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingBoard : MonoBehaviour
{

    private BattleManager _battleManager;
    public Transform botLeft, topRight;


    public Vector2 RandomPointInBoard()
    {
        var x = Random.Range(botLeft.position.x, topRight.position.x);
        var y = Random.Range(botLeft.position.y, topRight.position.y);
        return new Vector2(x, y);   
    }

    // Start is called before the first frame update
    void Start()
    {
        _battleManager  = ManagerManager.GetManager<BattleManager>();
        _battleManager.board = this;  
    }
}
