using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    [Header("Turret Parts")]
    [SerializeField] private Transform _connectionPoint;
    [SerializeField] private Transform _barrelInerior;

    [Header("Targeting")]
    [SerializeField] private Transform _trarget;
    [SerializeField] private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.startWidth = 0.0075f;
        _lineRenderer.endWidth = 0.0075f;
    }

    private void Update()
    {
        _connectionPoint.LookAt(_trarget, Vector3.up);
        _lineRenderer.SetPosition(0, _barrelInerior.position);
        _lineRenderer.SetPosition(1, _trarget.position);
    }
}
