using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class CityGenerator : MonoBehaviour{

    [SerializeField] Tilemap terrainTilemap;

    public Tile city;

    public Tile grass2;
    public Tile sand;
    public Tile grass;
    public void GenerateCities(int mapWidth, int mapHeight){
        for (int y = 0; y < mapHeight; y++){
            for(int x = 0; x < mapWidth; x++){
                if( terrainTilemap.GetTile(new Vector3Int(x,y,0)) == grass || terrainTilemap.GetTile(new Vector3Int(x,y,0)) == grass2 || terrainTilemap.GetTile(new Vector3Int(x,y,0)) == sand){
                    int rand = Random.Range(0,1000);
                    if(rand == 0){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), city);
                        terrainTilemap.SetTile(new Vector3Int(x+1,y,0), city);
                        terrainTilemap.SetTile(new Vector3Int(x,y+1,0), city);
                        terrainTilemap.SetTile(new Vector3Int(x+1,y+1,0), city);
                    }
                }
            }
        }
        
    }
}
