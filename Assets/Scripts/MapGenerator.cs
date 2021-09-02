using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour{

    public enum DrawMode {LandmassMap, HeightMap, BiomesMap, PercipitationMap};
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
    public TerrainType[] biomes;
    public TerrainType[] heights;
    public TerrainType[] precipitations;

    void Start()
    {
        GenerateMap();    
    }
    public void GenerateMap() {


        float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
        float[,] precipitationMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed2, noiseScale, octaves, persistance, lacunarity, offset2);


        if(drawMode == DrawMode.BiomesMap){
            Debug.Log("BiomeMap");
            for (int y = 0; y< mapHeight; y++){
                for (int x = 0; x < mapWidth; x++){
                    float currentHeight = noiseMap[x,y];
                    float currentPrecipitation = precipitationMap[x,y];
                    if(currentHeight < .2){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[0].tile);
                    }
                    else if(currentHeight < .3){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[13].tile);
                    }
                    else if(currentHeight < .4){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[1].tile);
                    }
                    else if(currentHeight < .42){
                        if(currentPrecipitation < .8){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[2].tile);
                        }
                        else if(currentPrecipitation  < 1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[12].tile);
                        }
                    }
                    else if(currentHeight < .6){
                        if(currentPrecipitation < .2){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[3].tile);
                        }
                        else if(currentPrecipitation < .5){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[4].tile);
                        }
                        else if(currentPrecipitation < .7){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[5].tile);
                        }
                        else if(currentPrecipitation < .8){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[6].tile);
                        }
                        else if(currentPrecipitation < 1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[7].tile);
                        }
                    }
                    else if(currentHeight <.8){
                        if(currentPrecipitation < .7){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[5].tile);
                        }
                        else if(currentPrecipitation < .8){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[6].tile);
                        }
                        else if(currentPrecipitation < 1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[7].tile);
                        }
                    }
                    else if(currentHeight < 1){
                        if(currentPrecipitation < .7){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[8].tile);
                        }
                        else if(currentPrecipitation < .8){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[9].tile);
                        }
                        else if(currentPrecipitation < 1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[10].tile);
                        }
                    }
                }
            }
        }
        if(drawMode == DrawMode.HeightMap){
            Debug.Log("HeightMap");
            for (int y = 0; y< mapHeight; y++){
                for (int x = 0; x < mapWidth; x++){
                    float currentHeight = noiseMap[x,y];
                    if(currentHeight < .1){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[0].tile);
                    }
                    else if(currentHeight < .2){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[1].tile);
                    }
                    else if(currentHeight < .3){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[2].tile);
                    }
                    else if(currentHeight < .4){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[3].tile);
                    }
                    else if(currentHeight < .45){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[10].tile);
                    }
                    else if(currentHeight < .5){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[4].tile);
                    }
                    else if(currentHeight < .6){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[5].tile);
                    }
                    else if(currentHeight < .7){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[6].tile);
                    }
                    else if(currentHeight < .8){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[7].tile);
                    }
                    else if(currentHeight < .9){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[8].tile);
                    }
                    else if(currentHeight < 1){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[9].tile);
                    }
                }
            }
        }
        if(drawMode == DrawMode.LandmassMap){
            Debug.Log("LandmassMap");
            for (int y = 0; y< mapHeight; y++){
                for (int x = 0; x < mapWidth; x++){
                    float currentHeight = noiseMap[x,y];
                    if(currentHeight < .1){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[0].tile);
                    }
                    else if(currentHeight < .2){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[1].tile);
                    }
                    else if(currentHeight < .3){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[2].tile);
                    }
                    else if(currentHeight < .4){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[3].tile);
                    }
                    else if(currentHeight < .45){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[10].tile);
                    }
                    else if(currentHeight < 1){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[4].tile);
                    }
                }
            }
        }
        if(drawMode == DrawMode.PercipitationMap){
            Debug.Log("LandmassMap");
            for (int y = 0; y< mapHeight; y++){
                for (int x = 0; x < mapWidth; x++){
                    float currentHeight = noiseMap[x,y];
                    float currentPrecipitation = precipitationMap[x,y];
                    if(currentHeight < .1){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[0].tile);
                    }
                    else if(currentHeight < .2){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[1].tile);
                    }
                    else if(currentHeight < .3){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[2].tile);
                    }
                    else if(currentHeight < .4){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[3].tile);
                    }
                    else if(currentHeight < .45){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), heights[10].tile);
                    }
                    else if(currentHeight < 1){
                        if(currentPrecipitation < .1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[0].tile);
                        }
                        else if(currentPrecipitation < .2){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[1].tile);
                        }
                        else if(currentPrecipitation < .3){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[2].tile);
                        }
                        else if(currentPrecipitation < .4){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[3].tile);
                        }
                        else if(currentPrecipitation < .5){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[4].tile);
                        }
                        else if(currentPrecipitation < .6){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[5].tile);
                        }
                        else if(currentPrecipitation < .7){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[6].tile);
                        }
                        else if(currentPrecipitation < .8){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[7].tile);
                        }
                        else if(currentPrecipitation < .9){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[8].tile);
                        }
                        else if(currentPrecipitation < 1){
                            terrainTilemap.SetTile(new Vector3Int(x,y,0), precipitations[9].tile);
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