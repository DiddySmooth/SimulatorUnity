using System.Collections;
using System.Collections.Generic;
using System;
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
    int seed;
    public int maxRivers;
    public int seed2;
    public Vector2 offset;
    public Vector2 offset2;
    public bool autoUpdate;
    [SerializeField] Tilemap terrainTilemap;
    public TerrainType[] biomes;
    public TerrainType[] heights;
    public TerrainType[] precipitations;
    public RuleTile river;
    public RuleTile water;
    
    int currentRivers;

    void Start(){
        GenerateMap(0);
        seed = UnityEngine.Random.Range(-1000, 1000);
    }
    public void GenerateMap(int mapType) {
        float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
        float[,] precipitationMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed2, noiseScale, octaves, persistance, lacunarity, offset2);


        if(mapType == 0){
            drawLandmassMap(noiseMap);
        }
        if(mapType == 1){
            drawHeightMap(noiseMap);
        }
        if(mapType == 2){
            drawPrecipitationMap(noiseMap, precipitationMap);
        }
        if(mapType == 3){
            drawBiomeMap(noiseMap, precipitationMap);
        }
        if(mapType == 4){
            drawBiomeMap(noiseMap, precipitationMap);
            drawMapWithRivers(noiseMap, precipitationMap);
        }
        
        // gameObject.GetComponent<CityGenerator>().GenerateCities(mapWidth, mapHeight);
    }  
    public void drawLandmassMap(float[,] noiseMap){
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
    public void drawPrecipitationMap(float[,] noiseMap, float[,] precipitationMap){
        Debug.Log("Precipitation Map");
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
    public void drawHeightMap(float[,] noiseMap){
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
    public void drawBiomeMap(float[,] noiseMap, float[,] precipitationMap){
        Debug.Log("BiomeMap");
            for (int y = 0; y< mapHeight; y++){
                for (int x = 0; x < mapWidth; x++){
                    float currentHeight = noiseMap[x,y];
                    float currentPrecipitation = precipitationMap[x,y];
                    if(currentHeight < .1){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[0].tile);
                    }
                    else if(currentHeight < .4){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[13].tile);
                    }
                    else if(currentHeight < .5){
                        terrainTilemap.SetTile(new Vector3Int(x,y,0), biomes[1].tile);
                    }
                    else if(currentHeight < .52){
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

    public void drawMapWithRivers(float[,] noiseMap, float[,] precipitationMap){
        
        int[][] riverStarts = new int[maxRivers][];
        
        for( int z = 0; z < maxRivers; z++){
            riverStarts[z] = new int[2];
            Debug.Log("Creating River Array");
        }

        for( int i = 0; i< maxRivers; i++){
            float maxScore = 0; 
            int maxX = 0; 
            int maxY = 0;
            for (int y = 0; y< mapHeight; y++){
                for (int x = 0; x < mapWidth; x++){
                    if(i == 0 ){
                        float currentScore = noiseMap[x,y] + precipitationMap[x,y];
                        if(currentScore > maxScore){
                            maxScore = currentScore;
                            maxX = x;
                            maxY = y;
                        }
                    }
                    else{
                        for(int j = 0; j < riverStarts.Length; j++){
                            if( riverStarts[j][0] == 0 && riverStarts[j][1] == 0){
                                break;
                            } 
                            float x1 = (float)x;
                            float y1 = (float)y;
                            float x2 = (float)riverStarts[j][0];
                            float y2 = (float)riverStarts[j][1];
                            float distance = Mathf.Sqrt(Mathf.Pow(x1 - x2, 2f) + Mathf.Pow(y1 - y2, 2f) * 1.0f);
                            float normalDistance = (distance / mapWidth);

                            float currentScore = noiseMap[x,y] + precipitationMap[x,y] + normalDistance;
                            if(currentScore > maxScore){
                                maxScore = currentScore;
                                maxX = x;
                                maxY = y;
                            }

                            Debug.Log("The distance between" + x + " " + y + " and " + x2 + " " + y2 + " is" + distance);
                        }
                    }
                }
            }

            riverStarts[i][0] = maxX;
            riverStarts[i][1] = maxY;
        }
        //drawMapWithRivers(noiseMap);
    }
    
    void createRiver(int x, int y, float[,] noiseMap){
        
        bool complete = false;
    
        while(complete == false){
            terrainTilemap.SetTile(new Vector3Int(x,y,0), river);
            float currentHeight = noiseMap[x,y];
            if(noiseMap[x+1,y] <= currentHeight && terrainTilemap.GetTile(new Vector3Int(x+1,y,0)) != river){
                x++;
            }
            else if(noiseMap[x - 1,y] <= currentHeight && terrainTilemap.GetTile(new Vector3Int(x-1,y,0)) != river){
                x--;
            }
            else if(noiseMap[x,y + 1] <= currentHeight && terrainTilemap.GetTile(new Vector3Int(x,y+1,0)) != river){
                y++;
            }
            else if(noiseMap[x,y - 1] <= currentHeight && terrainTilemap.GetTile(new Vector3Int(x,y-1,0)) != river){
                y--;
            }
            else{
                x++;
            }
            if(terrainTilemap.GetTile(new Vector3Int(x,y,0)) == water || x >= 500 || x <= 0 || y >= 500 || y <= 0){
                complete = true;
                Debug.Log("Rivers Complete");
            }
            
        }
        
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