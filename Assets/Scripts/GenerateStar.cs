using System;

using UnityEngine;

public class GenerateStar : MonoBehaviour
{
    GameObject[] starSurfaces;
    private Transform chosenSurface;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starSurfaces = GameObject.FindGameObjectsWithTag("starSurface");

        SelectRandomSurface();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectRandomSurface()
    {
        // int randomNmbr = Random.Range(0, starSurfaces.Length);
        // chosenSurface = starSurfaces[randomNmbr].transform;
    }
}
