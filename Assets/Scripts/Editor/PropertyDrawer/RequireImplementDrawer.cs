using Core.Attributes;
using UnityEditor;
using UnityEngine;

namespace Editor.PropertyDrawer
{

	[CustomPropertyDrawer(typeof(RequireImplementAttribute))]
	public class RequireInterfaceDrawer : UnityEditor.PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var attr = (RequireImplementAttribute)attribute;
			var old = property.objectReferenceValue;

			EditorGUI.BeginProperty(position, label, property);

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