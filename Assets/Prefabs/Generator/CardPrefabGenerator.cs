using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CardPrefabGenerator : EditorWindow
{
  private Dictionary<CardTypes, string> cardTypeLabelMap = new Dictionary<CardTypes, string>()
  {
    [CardTypes.Resource] = "Resource",
    [CardTypes.Unit] = "Unit",
    [CardTypes.Item] = "Item",
    [CardTypes.Spell] = "Spell",
    [CardTypes.Building] = "Building",
  };

  private CardTypes cardType = CardTypes.Resource;

  private string pathName = "Prefabs/Card/CardLibrary";

  [MenuItem("Custom Utilities/Mass Card Prefab Generator")]
  public static void ShowWindow()
  {
    GetWindow(typeof(CardPrefabGenerator));
  }

  private void OnGUI()
  {
    GUILayout.Label("Mass Card Prefab Generator", EditorStyles.boldLabel);
    this.pathName = EditorGUILayout.TextField("Save Path", this.pathName);
    this.cardType = (CardTypes)EditorGUILayout.EnumPopup("Card Type", this.cardType);

    Debug.Log(cardType);

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

      string cardTypeLabel = this.cardTypeLabelMap[cardType];

      GameObject parentPrefab = AssetDatabase.LoadAssetAtPath<GameObject>($"Assets/{pathName}/BaseCards/Card_{cardTypeLabel}.prefab");

      GameObject cardPrefab = PrefabUtility.InstantiatePrefab(parentPrefab) as GameObject;

      cardPrefab.AddComponent(foundCard.GetClass());

      PrefabUtility.SaveAsPrefabAssetAndConnect(cardPrefab, localPath, InteractionMode.UserAction);

      DestroyImmediate(cardPrefab);
      DestroyImmediate(parentPrefab);
    }
  }
}