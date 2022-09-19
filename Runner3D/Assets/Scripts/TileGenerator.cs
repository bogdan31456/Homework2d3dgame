using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles=new List<GameObject> ();
    private float spawnPos = 0;
    private float tileLength = 100;
    
    [SerializeField] private Transform player;
    private int startTiles = 6;
    void Start()
    {
       for(int i=0; i< startTiles;i++)
        {
            SpawnTile(Random.Range(0,tilePrefabs.Length));
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (player.position.z - 60 > spawnPos - (startTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleTile();
        }
        
        
    }

    private void  SpawnTile(int tileindex)
    {
        GameObject nextTile=Instantiate(tilePrefabs[tileindex],transform.forward*spawnPos,transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }
    private void DeleTile()
    {
        
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

}
