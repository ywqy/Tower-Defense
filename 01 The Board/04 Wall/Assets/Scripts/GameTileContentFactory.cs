﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameTileContentFactory : ScriptableObject
{
    [SerializeField]
    GameTileContent emptyPrefab = default;
    [SerializeField]
    GameTileContent destinationPrefab = default;
    [SerializeField]
    GameTileContent wallPrefab = default;
    

    Scene contentScene;

    public GameTileContent Get(GameTileContentType type) {
        switch (type) {
            case GameTileContentType.Empty: return Get(emptyPrefab);
            case GameTileContentType.Destination: return Get(destinationPrefab);
            case GameTileContentType.Wall: return Get(wallPrefab);
        }
        Debug.Assert(false, "Unspported type: " + type);
        return null;
    }
    

    public void Reclaim(GameTileContent content) {
        Debug.Assert(content.OriginFactory == this, "Wrong factory reclaimed!");
        Destroy(content.gameObject);
    }

    GameTileContent Get(GameTileContent Prefab) {
        GameTileContent instance = Instantiate(Prefab);
        instance.OriginFactory = this;
        MoveToFactoryScene(instance.gameObject);
        return instance;
    }

    void MoveToFactoryScene(GameObject o) {
        if (!contentScene.isLoaded) {
            if (Application.isEditor) {
                contentScene = SceneManager.GetSceneByName(name);
                if (!contentScene.isLoaded) {
                    contentScene = SceneManager.CreateScene(name);
                }

            } else {
                contentScene = SceneManager.CreateScene(name);
            }
        }
        SceneManager.MoveGameObjectToScene(o, contentScene);
    }
}
