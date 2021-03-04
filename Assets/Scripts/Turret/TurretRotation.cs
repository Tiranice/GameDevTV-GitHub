using UnityEngine;

/// <summary>
/// Rotates the turret's connection point so that the barrel faces the target.
/// </summary>
public class TurretRotation : MonoBehaviour
{
    #region Inspector Fields

    [Header("Turret Parts")]
    [Tooltip("The part that connects the barrel to the rest of the turret.")]
    [SerializeField] private Transform _connectionPoint;

    [Tooltip("The transform that marks the shooty bit of the barrel.")]
    [SerializeField] private Transform _barrelInerior;

    [Header("Targeting")]
    [Tooltip("The thing the turret want to shoot.")]
    [SerializeField] private Transform _target;

    [Tooltip("Renders a line from the barrel to the target.")]
    [SerializeField] private LineRenderer _lineRenderer;

    #endregion

    #region Unity Messages

    private void Start() => SetupLineRenderer();

    private void Update() => Retarget();

    #endregion

    #region Setup & Teardown

    /// <summary>
    /// Sets the position count and width of the <see cref="_lineRenderer">Line Renderer</see>.
    /// </summary>
    private void SetupLineRenderer()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.startWidth = 0.0075f;
        _lineRenderer.endWidth = 0.0075f;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Rotates the <see cref="_connectionPoint">Connection Point</see> so that it looks at the
    /// <see cref="_target">Target</see>, then marks the target with the <see cref="_lineRenderer">
    /// Line Renderer</see>.
    /// </summary>
    private void Retarget()
    {
        _connectionPoint.LookAt(_target, Vector3.up);
        _lineRenderer.SetPosition(0, _barrelInerior.position);
        _lineRenderer.SetPosition(1, _target.position);
    }

    #endregion
}
