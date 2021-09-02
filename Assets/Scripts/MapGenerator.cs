using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour{

    public enum DrawMode {NoiseMap, HeightMap, CitiesMap, BiomesMap};
    public DrawMode drawMode;
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;
    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;
    public int seed;
    public int seed2;
    public Vector2 offset;
    public Vector2 offset2;
    public bool autoUpdate;
    [SerializeField] Tilemap terrainTilemap;
    public TerrainType[] regions;

    void Start()
    {
        GenerateMap();    
    }
    public void GenerateMap() {


        float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
        float[,] precipitationMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed2, noiseScale, octaves, persistance, lacunarity, offset2);


        if(drawMode == DrawMode.BiomesMap){
            for (int y = 0; y< mapHeight; y++){
                for (int x = 0; x < mapWidth; x++){
                    float currentHeight = noiseMap[x,y];
                    float currentPrecipitation = precipitationMap[x,y];
                    if(currentHeight < .3){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[0].tile);
                    }
                    else if(currentHeight < .4){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[1].tile);
                    }
                    else if(currentHeight < .42){
                        if(currentPrecipitation < .8){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[2].tile);
                        }
                        else if(currentPrecipitation  < 1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[12].tile);
                        }
                    }
                    else if(currentHeight < .6){
                        if(currentPrecipitation < .2){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[3].tile);
                        }
                        else if(currentPrecipitation < .5){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[4].tile);
                        }
                        else if(currentPrecipitation < .7){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[5].tile);
                        }
                        else if(currentPrecipitation < .8){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[6].tile);
                        }
                        else if(currentPrecipitation < 1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[7].tile);
                        }
                    }
                    else if(currentHeight <.8){
                        if(currentPrecipitation < .7){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[5].tile);
                        }
                        else if(currentPrecipitation < .8){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[6].tile);
                        }
                        else if(currentPrecipitation < 1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[7].tile);
                        }
                    }
                    else if(currentHeight < 1){
                        if(currentPrecipitation < .7){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[8].tile);
                        }
                        else if(currentPrecipitation < .8){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[9].tile);
                        }
                        else if(currentPrecipitation < 1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[10].tile);
                        }
                    }
                }
            }
            if(drawMode == DrawMode.HeightMap){
                for (int y = 0; y< mapHeight; y++){
                    for (int x = 0; x < mapWidth; x++){
                        float currentHeight = noiseMap[x,y];
                        if(currentHeight < .3){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[0].tile);
                        }
                        else if(currentHeight < .4){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[1].tile);
                        }
                        else if(currentHeight < .45){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), regions[3].tile);
                        }
                    }
                }
            }
        }
        // gameObject.GetComponent<CityGenerator>().GenerateCities(mapWidth, mapHeight);
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
    public RuleTile tile;
    
}