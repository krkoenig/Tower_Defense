using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnWave : ScriptableObject
{

    public List<GameObject> enemy;
    public List<int> enemyCount;
}

public class MakeSpawnWave
{
    [MenuItem("Assets/Create/SpawnWave")]
    public static void CreateMyAsset()
    {
        SpawnWave asset = ScriptableObject.CreateInstance<SpawnWave>();

        AssetDatabase.CreateAsset(asset, "Assets/Enemy Waves/NewSpawnwave.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
