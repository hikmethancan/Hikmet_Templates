using System.Collections;
using System.Collections.Generic;
using ObjPooler;
using UnityEngine;

namespace Deneme.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        public int numOfTotalObjects = 0;
        public List<GameObject> InstantObjects = new List<GameObject>() ;
        public GameObject SpawnObjectPrefab;
        public Transform InstantPoint;

        private int currentNumOfObject;

        private void Start()
        {
            Debug.Log("Merhaba..");
            currentNumOfObject = 0;
            SpawnStartGame();
            StartCoroutine(SpawnObject());
            
            
        }

        private void SpawnStartGame()
        {
            for (int i = 0; i < numOfTotalObjects; i++)
            {
                GameObject newObject =  Instantiate(SpawnObjectPrefab, transform);
                InstantObjects.Add(newObject);
                InstantObjects[i].SetActive(false);
            }
        }

        IEnumerator SpawnObject()
        {
            yield return new WaitForSeconds(3f);

            while (InstantObjects != null)
            {
                if (currentNumOfObject < InstantObjects.Count)
                {
                    Debug.Log("Spawn 1 ba�lad�");
                    InstantObjects[currentNumOfObject].SetActive(true);
                    InstantObjects[currentNumOfObject].transform.position = InstantPoint.transform.position;
                    currentNumOfObject++;
                    Debug.Log("Spawn 1 tane ettik");
                }
                else
                {
                    currentNumOfObject = 0;
                    InstantObjects[currentNumOfObject].SetActive(true);
                    InstantObjects[currentNumOfObject].transform.position = InstantPoint.transform.position;
                }
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}
