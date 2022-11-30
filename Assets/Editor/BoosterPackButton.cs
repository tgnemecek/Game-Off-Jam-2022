using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoosterPack))]
class BoosterPackButton : Editor
{
  public override void OnInspectorGUI()
  {
    DrawDefaultInspector();

    BoosterPack boosterPack = (BoosterPack)target;


    if (GUILayout.Button("Reload Cards"))
    {
      boosterPack.UpdateCardList();
    }
  }
}