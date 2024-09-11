using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Opdracht2 : MonoBehaviour
{
    public GameObject prefab;

    public Material Material;

    private void Start()
    {
        Material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit))
            {
                GameObject gb = Instantiate(prefab);
                gb.transform.position = new(raycastHit.point.x, 0, raycastHit.point.z);
                gb.transform.localScale = RandomSize();
                Material material = gb.GetComponent<MeshRenderer>().material;
                material.SetColor("_Color", RandomColor());
                Destroy(gb, 10);
            }
        }

        //Material.SetColor("_Color", RandomColor());
    }
    private Vector3 RandomSize()
    {
        Vector3 vec = new Vector3();
        vec.y = Random.Range(1, 4);
        vec.z = vec.x = Random.Range(1, 4);
        
       return vec;
    }

    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color randColor = new Color(r, g, b, 1f);

        return randColor;
    }
}
