using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lISTTESTED : MonoBehaviour
{
    public static List<GameObject> _objcets;
    public GameObject _1;
    public GameObject _2;
    public GameObject _3;
    public GameObject _4;
    public GameObject _5;
    public GameObject _6;
    public GameObject _7;
    public GameObject _8;

    private void Start()
    {
        _objcets = new List<GameObject>();
        _objcets.Add(_1);
        _objcets.Add(_2);
        _objcets.Add(_3);
        _objcets.Add(_4);
        _objcets.Add(_5);
        _objcets.Add(_6);
        _objcets.Add(_7);
        _objcets.Add(_8);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)&& _objcets.Count>0) 
        {
            _objcets.RemoveAt(0);
            LoadAllItemsInTheList();
        }
        else if (Input.GetKeyDown(KeyCode.S) && _objcets.Count > 1)
        {
            _objcets.RemoveAt(1);
            LoadAllItemsInTheList();
        }  
        else if (Input.GetKeyDown(KeyCode.D) && _objcets.Count > 2)
        {
            _objcets.RemoveAt(2);
            LoadAllItemsInTheList();
        } 
        else if (Input.GetKeyDown(KeyCode.F) && _objcets.Count > 3)
        {
            _objcets.RemoveAt(3);
            LoadAllItemsInTheList();
        }
    }

    void LoadAllItemsInTheList()
    {
        Debug.Log("List length" + _objcets.Count);
        for (int i = 0; i < _objcets.Count; i++)
        {
            Debug.Log(i + " :- " + _objcets[i]);
        }
    }
}
