using Core.Attributes;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Editor.PropertyDrawer
{

	[CustomPropertyDrawer(typeof(RequireImplementArrayAttribute))]
	public class RequireImplementArrayDrawer : UnityEditor.PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var attr = (RequireImplementArrayAttribute)attribute;

			EditorGUI.BeginProperty(position, label, property);

			if (property.propertyType != SerializedPropertyType.ObjectReference)
			{
				EditorGUI.LabelField(position, label.text, "RequireImplementArrayAttribute can only be used with Object array elements");
				EditorGUI.EndProperty();
				return;
			}

			var old = property.objectReferenceValue;
			var obj = EditorGUI.ObjectField(position, label, old, typeof(Object), true);

			if (obj == null)
			{
				property.objectReferenceValue = null;
			}
			else if (attr.type.IsAssignableFrom(obj.GetType()))
			{
				property.objectReferenceValue = obj;
			}
			else if (obj is GameObject go && go.TryGetComponent(attr.type, out Component comp))
			{
				property.objectReferenceValue = comp;
			}
			else
			{
				property.objectReferenceValue = old;
				Debug.LogWarning($"Object must implement {attr.type.Name}.");
			}

			EditorGUI.EndProperty();
		}
	}

}
