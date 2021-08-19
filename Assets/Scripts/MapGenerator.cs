using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour{

    public enum DrawMode {NoiseMap, ColorMap, CitiesMap, TileMap};
    public DrawMode drawMode;
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;
    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;
    public bool autoUpdate;
    [SerializeField] Tilemap terrainTilemap;
    public TerrainType[] regions;

    void Start()
    {
        GenerateMap();    
    }
    public void GenerateMap() {
        float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);



        for (int y = 0; y< mapHeight; y++){
            for (int x = 0; x < mapWidth; x++){
                float currentHeight = noiseMap[x,y];
                for (int i = 0; i < regions.Length; i++){
                    if(currentHeight <= regions [i].height) {


                        terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[i].tile);
                        break;
                    }
                }
                
            }
        }
        gameObject.GetComponent<CityGenerator>().GenerateCities(mapWidth, mapHeight);

    }

    void OnValidate() {
        if (mapWidth < 1){
            mapWidth = 1;
        }
        if (mapHeight < 1){
            mapHeight = 1;
        }
        if (lacunarity < 1){
            lacunarity = 1;
        }
        if (octaves < 0){
            octaves = 0;
        }
    }
}
[System.Serializable]
public struct TerrainType {
    public string name;
    public float height;
    public RuleTile tile;
}