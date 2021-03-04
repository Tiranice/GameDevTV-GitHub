using UnityEngine;

namespace TirUtilities.CustomGizmos
{
    [ExecuteInEditMode]
    public class DrawForwardGizmo : MonoBehaviour
    {
        #region Data Structures

        private enum ShapeType
        {
            Sphere,
            WireSphere,
            Cube,
            WireCube,
        }

        #endregion

        #region Inspector Fields

        [Header("Shape")]
        [Tooltip("Toggle the shape gizmo on and off.")]
        [SerializeField] private bool _drawShape = true;

        [Tooltip("The color of the shape.  Change the alpha for a translucent gizmo.")]
        [SerializeField] private Color _shapeColor = Color.green;
        
        // TODO:  Make this tooltip less awful.
        [Tooltip("The type of shape that is drawn.\nWire and solid versions.")]
        [SerializeField] private ShapeType _shapeType = ShapeType.WireSphere;

        [Tooltip("The size of the shape gizmo.  This is a multiple of the object's scale.")]
        [Range(0.1f, 2.0f)]
        [SerializeField] private float _shapeSize = 1.0f;

        [Header("Line")]
        [Tooltip("Toggle the line gizmo on and off.")]
        [SerializeField] private bool _drawLine = true;

        [Tooltip("The color of the shape.  Change the alpha for a translucent gizmo.")]
        [SerializeField] private Color _lineColor = Color.red;

        [Tooltip("The length of the line gizmo.  One is the exact depth of the object's largest extent.")]
        [Range(1.0f, 10.0f)]
        [SerializeField] private float _lineLength = 2.0f;

        #endregion

        #region Gizmo

        private void OnDrawGizmos()
        {
            Vector3 position = transform.position;

            // Size of the cuboid gizmos.
            Vector3 size = transform.localScale * _shapeSize;

            // Radius of the spheroid gizmos.
            float radius = Mathf.Max(transform.localScale.x, transform.localScale.y, transform.localScale.z) * _shapeSize;

            Gizmos.color = _shapeColor;


            if (_drawShape)
            {
                if (_shapeType == ShapeType.WireSphere)
                    Gizmos.DrawWireSphere(position, radius);

                else if (_shapeType == ShapeType.Cube)
                    Gizmos.DrawCube(position, size);

                else if (_shapeType == ShapeType.Sphere)
                    Gizmos.DrawSphere(position, radius);

                else if (_shapeType == ShapeType.WireCube)
                    Gizmos.DrawWireCube(position, size);
            }

            if (_drawLine)
            {
                Gizmos.color = _lineColor;
                Gizmos.DrawLine(position, position + transform.forward * _lineLength);
            }
        }

        #endregion
    }
}