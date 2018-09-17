using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;

[CustomPropertyDrawer(typeof(VelocityBehaviour))]
public class VelocityDrawer : PropertyDrawer
{
    public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
    {
        int fieldCount = 1;
        return fieldCount * EditorGUIUtility.singleLineHeight;
    }

    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty velocityProp = property.FindPropertyRelative("velocity");

        Rect singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(singleFieldRect, velocityProp);
    }
}