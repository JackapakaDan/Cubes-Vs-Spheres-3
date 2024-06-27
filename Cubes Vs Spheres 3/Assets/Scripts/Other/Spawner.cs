using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject obj;
    public int numOfObjects;
    public float maxLocationX;
    public float maxLocationZ;
    public float minLocationX;
    public float minLocationZ;
    public Globals.SpawnerTypes typeOfSpawner;
    GameObject[] objects;
    void Start()
    {
        StartCoroutine(WaitForSpawn());
    }
    IEnumerator WaitForSpawn()
    {
        while (true)
        {
            if (typeOfSpawner == Globals.SpawnerTypes.Enemy)
            {
                objects = GameObject.FindGameObjectsWithTag("Enemy");
                if (objects.Length < numOfObjects)
                {
                    Vector3 enemy_position = new Vector3(Random.Range(minLocationX, maxLocationX), 1.1f, Random.Range(minLocationZ, maxLocationZ));
                    if (!Physics.CheckBox(enemy_position, obj.transform.localScale))
                    {
                        enemy_position.y = 0;
                        Instantiate(obj, enemy_position, Quaternion.identity);
                    }


                }
            }

            else if (typeOfSpawner == Globals.SpawnerTypes.Furnature)
            {
                objects = GameObject.FindGameObjectsWithTag("Furnature");
                if (objects.Length < numOfObjects)
                {
                    Vector3 furnaturePos = new Vector3(Random.Range(minLocationX, maxLocationX), 1.1f, Random.Range(minLocationZ, maxLocationZ));
                    if (!Physics.CheckBox(furnaturePos, obj.transform.localScale))
                    {
                        furnaturePos.y = 0;
                        Instantiate(obj, furnaturePos, Quaternion.identity);
                    }
                }

            }
            yield return new WaitForSeconds(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
