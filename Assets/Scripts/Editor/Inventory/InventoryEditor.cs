using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor {

	private bool[] showItemSlots = new bool[Inventory.numItemSlots];

	private SerializedProperty itemImagesProperty;
	private SerializedProperty itemTextsProperty;
	private SerializedProperty itemsProperty;
	private SerializedProperty itemValuesProperty;

	private const string inventoryPropItemImagesName = "itemImages";
	private const string inventoryPropItemTextsName = "itemTexts";
	private const string inventoryPropItemsName = "items";
	private const string inventoryPropItemValuesName = "itemValues";

	private void OnEnable() {
		itemImagesProperty = serializedObject.FindProperty(inventoryPropItemImagesName);
		itemTextsProperty = serializedObject.FindProperty(inventoryPropItemTextsName);
		itemsProperty = serializedObject.FindProperty(inventoryPropItemsName);
		itemValuesProperty = serializedObject.FindProperty(inventoryPropItemValuesName);
	}

	public override void OnInspectorGUI() {
		serializedObject.Update ();

		for (int i = 0; i < showItemSlots.Length; i++) {
			ItemSlotGUI (i);
		}

		serializedObject.ApplyModifiedProperties ();
	}

	private void ItemSlotGUI(int idx) {
		EditorGUILayout.BeginVertical (GUI.skin.box);
		EditorGUI.indentLevel++;

		showItemSlots [idx] = EditorGUILayout.Foldout (showItemSlots [idx], "Item Slot " + idx);
		if (showItemSlots [idx]) {
			EditorGUILayout.PropertyField (itemImagesProperty.GetArrayElementAtIndex (idx));
			EditorGUILayout.PropertyField (itemTextsProperty.GetArrayElementAtIndex (idx));
			EditorGUILayout.PropertyField (itemsProperty.GetArrayElementAtIndex (idx));
			EditorGUILayout.PropertyField (itemValuesProperty.GetArrayElementAtIndex (idx));
		}

		EditorGUI.indentLevel--;
		EditorGUILayout.EndVertical ();
	}
}
