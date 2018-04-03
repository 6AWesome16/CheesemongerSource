using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;
    void Awake()
    {
       if (instance!=null)
        {
            Debug.LogWarning("There is already an instance of the Inventory!");
            return;
        }
        instance = this;
    }
    #endregion

    public List<GameObject> items = new List<GameObject>();

    void add(GameObject g)
    {
        items.Add(g);
    }

    void remove(GameObject g)
    {
        items.Remove(g);
    }
}
