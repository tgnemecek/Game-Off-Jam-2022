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
    this.cardType = (CardTypes)EditorGUILayout.EnumPopup("Card Type", this.cardType);

    if (GUILayout.Button("Build Prefabs")) GeneratePrefabs();
  }

  private void GeneratePrefabs()
  {
    foreach (string guid in Selection.assetGUIDs)
    {
      string cardTypeLabel = this.cardTypeLabelMap[cardType];

      string assetPath = AssetDatabase.GUIDToAssetPath(guid);

      MonoScript foundCard = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);

      MonoScript foundParentCard = AssetDatabase.LoadAssetAtPath<MonoScript>($"Assets/{pathName}/BaseCardLibrary/Card_{cardTypeLabel}.cs");

      string prefabPath = $"Assets/{pathName}/{cardTypeLabel}CardLibrary/{foundCard.name}.prefab";

      string localPath = AssetDatabase.GenerateUniqueAssetPath(prefabPath);

      GameObject existingPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(localPath);

      if (existingPrefab) return;

      GameObject parentPrefab = AssetDatabase.LoadAssetAtPath<GameObject>($"Assets/{pathName}/BaseCardLibrary/Card_{cardTypeLabel}.prefab");

      GameObject cardPrefab = (GameObject)PrefabUtility.InstantiatePrefab(parentPrefab);

      cardPrefab.AddComponent(foundCard.GetClass());

      Card cardScriptComponent = (Card)cardPrefab.GetComponent(foundCard.GetClass());

      cardScriptComponent.InjectDefaultDependencies();

      PrefabUtility.SaveAsPrefabAssetAndConnect(cardPrefab, localPath, InteractionMode.UserAction);

      DestroyImmediate(cardPrefab);
      DestroyImmediate(parentPrefab);
    }
  }
}