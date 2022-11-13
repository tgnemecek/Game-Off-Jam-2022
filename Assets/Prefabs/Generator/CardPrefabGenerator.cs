using UnityEngine;
using UnityEditor;

public class CardPrefabGenerator : EditorWindow
{
  private bool working = false;

  private string[] CardTypeLabels = new string[] { "Resource", "Unit", "Item", "Spell", "Building" };

  private string pathName = "Prefabs/Card/CardLibrary";

  [MenuItem("Custom Utilities/Mass Card Prefab Generator")]
  public static void ShowWindow()
  {
    GetWindow(typeof(CardPrefabGenerator));
  }

  private void OnGUI()
  {
    GUILayout.Label("Mass Card Prefab Generator", EditorStyles.boldLabel);
    if (GUILayout.Button("Build Prefabs"))
    {
      if (this.working) return;

      this.working = true;

      foreach (string type in CardTypeLabels)
      {
        Debug.Log($"Generate for type: {type}");
        GeneratePrefabs(type);
      }

      this.working = false;
    }
  }

  private void GeneratePrefabs(string type)
  {
    string[] assets = AssetDatabase.FindAssets("t:MonoScript", new string[] { $"Assets/{pathName}/{type}CardLibrary/" });

    Debug.Log($"Found {assets.Length} assets");

    foreach (string guid in assets)
    {
      string assetPath = AssetDatabase.GUIDToAssetPath(guid);

      MonoScript foundCard = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);

      MonoScript foundParentCard = AssetDatabase.LoadAssetAtPath<MonoScript>($"Assets/{pathName}/BaseCardLibrary/Card_{type}.cs");

      string prefabPath = $"Assets/{pathName}/{type}CardLibrary/{foundCard.name}.prefab";

      GameObject existingPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

      if (existingPrefab)
      {
        Debug.Log($"Prefab already exists for card: {foundCard.name}. Skipping");
        continue;
      }

      GameObject parentPrefab = AssetDatabase.LoadAssetAtPath<GameObject>($"Assets/{pathName}/BaseCardLibrary/Card_{type}.prefab");

      GameObject cardPrefab = (GameObject)PrefabUtility.InstantiatePrefab(parentPrefab);

      cardPrefab.AddComponent(foundCard.GetClass());

      Card cardScriptComponent = (Card)cardPrefab.GetComponent(foundCard.GetClass());

      cardScriptComponent.InjectDefaultDependencies();

      PrefabUtility.SaveAsPrefabAssetAndConnect(cardPrefab, prefabPath, InteractionMode.UserAction);

      DestroyImmediate(cardPrefab);
      DestroyImmediate(parentPrefab);

      Debug.Log($"Created prefab for card: {foundCard.name}");
    }
  }
}