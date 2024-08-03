using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLIst : MonoBehaviour
{
    [SerializeReference]
    public List<Foo> RoseGardenia;
    // Start is called before the first frame update
    void Start()
    {
        RoseGardenia.Add(new Foo());
        RoseGardenia.Add(new Fii());
        RoseGardenia.Add(new Foo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Foo
{
    public int i;
}

[System.Serializable]
public class Fii : Foo
{
    public string x;
}
