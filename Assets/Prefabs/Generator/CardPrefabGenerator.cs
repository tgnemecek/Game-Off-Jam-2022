using UnityEngine;
using UnityEditor;

public class CardPrefabGenerator : EditorWindow
{
  private string pathName = "Prefabs/Card/CardLibrary";

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

      GameObject gameObj = new GameObject();

      gameObj.AddComponent(foundCard.GetClass());

      PrefabUtility.SaveAsPrefabAssetAndConnect(gameObj, localPath, InteractionMode.UserAction);

      DestroyImmediate(gameObj);
    }
  }
}