using UnityEngine;

public class Check : MonoBehaviour
{
    public GameObject key;
    void Update()
    {
        if (key == null)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
