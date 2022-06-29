using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSpawner : MonoBehaviour
{
    [SerializeField] private LettersController lettersController;
    [SerializeField] private SpawnPoint spawnPointPrefab;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    private void OnEnable()
    {
        GenerateSpawnPoints(9, 9);
        UIInputController.onGenerateButtonDown += GenerateSpawnPoints;
        UIInputController.onMixButtonDown += MixPoints;
    }
    private void OnDisable()
    {
        UIInputController.onGenerateButtonDown -= GenerateSpawnPoints;
        UIInputController.onMixButtonDown -= MixPoints;
    }
    private void GenerateSpawnPoints(int num1, int num2)
    {
        DestroyPreviousPoints();
        GameObject[,] spawnPoints = new GameObject[num1, num2];
        for (int z = 0; z < num2; z++)
        {
            for (int x = 0; x < num1; x++)
            {
                GameObject newPoint = Instantiate(spawnPointPrefab.gameObject, this.transform);
                spawnPoints[x, z] = newPoint;
                spawnPoints[x, z].name = "SpawnPoint" + z + x;
                spawnPoints[x, z].transform.position = new Vector3(spawnPoints[x, z].transform.position.x + offsetX * x,
    spawnPoints[x, z].transform.position.y, spawnPoints[x, z].transform.position.z + offsetY * z);
                lettersController.SetLetters(spawnPoints[x, z].GetComponent<SpawnPoint>().textBar);
            }
        }
    }
    private void DestroyPreviousPoints()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Destroy(spawnPoints[i]);
        }
    }
    private void MixPoints()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Transform ttemp = spawnPoints[spawnPoints.Length - 1].transform;
        for (int i = 0; i < spawnPoints.Length - 1; i++)
        {
            int num1 = Random.Range(i, spawnPoints.Length - 1);
            Vector3 tempTransform = spawnPoints[i].transform.position;
            spawnPoints[i].transform.position = spawnPoints[num1].transform.position;
            spawnPoints[num1].transform.position = tempTransform;
        }
    }
}
