using UnityEngine;
using UnityEngine.UIElements;

public class SpawnRoof : MonoBehaviour
{

    public GameObject roof;

    GameObject RoofParent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RoofParent = new GameObject();

        for (int x=0; x<20; x++)
        {
            for (int z = 0; z < 20; z++)
            {
                GameObject childRoof = Instantiate(roof, new Vector3(x, 1.5f, z), Quaternion.identity);
                childRoof.transform.parent = RoofParent.transform;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        roof.transform.parent = RoofParent.transform;
    }
}
