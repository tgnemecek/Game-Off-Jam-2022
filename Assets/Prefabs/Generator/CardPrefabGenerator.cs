using UnityEngine;
using UnityEditor;

public class CardPrefabGenerator : EditorWindow
{
  private string pathName = "Prefabs/Card/CardLibrary";

  private string baseCardPathName = "Assets/Prefabs/Card/CardLibrary/Card_Base.prefab";

  [MenuItem("Custom Utilities/Mass Card Prefab Generator")]
  public static void ShowWindow()
  {
    GetWindow(typeof(CardPrefabGenerator));
  }

  private void OnGUI()
  {
    GUILayout.Label("Mass Card Prefab Generator", EditorStyles.boldLabel);
    pathName = EditorGUILayout.TextField("Save Path", this.pathName);

    if (GUILayout.Button("Build Prefabs")) GeneratePrefabs();
  }

  private void GeneratePrefabs()
  {
    foreach (string guid in Selection.assetGUIDs)
    {
      string assetPath = AssetDatabase.GUIDToAssetPath(guid);

      MonoScript foundCard = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);

      string prefabPath = $"Assets/{pathName}/{foundCard.name}.prefab";

      string localPath = AssetDatabase.GenerateUniqueAssetPath(prefabPath);

      GameObject parentPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(baseCardPathName);

      GameObject cardPrefab = PrefabUtility.InstantiatePrefab(parentPrefab) as GameObject;

      cardPrefab.GetComponent<Card_Base>().enabled = false;

      cardPrefab.AddComponent(foundCard.GetClass());

      PrefabUtility.SaveAsPrefabAssetAndConnect(cardPrefab, localPath, InteractionMode.UserAction);

      DestroyImmediate(cardPrefab);
      DestroyImmediate(parentPrefab);
    }
  }
}