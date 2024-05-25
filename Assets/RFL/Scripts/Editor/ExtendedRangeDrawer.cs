namespace RFL.Scripts.Editor
{
    using RFL.Scripts.Attributes;
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    ///     <a href="https://forum.unity.com/threads/range-attribute.451848/">
    ///         code taken from here
    ///     </a>
    /// </summary>
    [CustomPropertyDrawer(typeof(ExtendedRangeAttribute))]
    public sealed class ExtendedRangeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var attr = (ExtendedRangeAttribute)attribute;

            if (property.propertyType != SerializedPropertyType.Integer)
            {
                EditorGUI.LabelField(position, label.text, "Use Extended Range with int.");
                return;
            }

            var max = attr.Max - (attr.Max - attr.Min) % attr.Step;
            var value = EditorGUI.IntSlider(position, label, property.intValue, attr.Min, max);

            // NOT a bug, 'cause division rounding value to floor 
            value = Mathf.Min(value / attr.Step * attr.Step + attr.Min % attr.Step, max);
            property.intValue = value;
        }
    }
}