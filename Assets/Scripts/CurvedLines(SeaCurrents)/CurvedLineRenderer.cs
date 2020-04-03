using System.Collections.Generic;
using UnityEngine;

namespace EasyCurvedLine
{
    [RequireComponent(typeof(LineRenderer))]
    public class CurvedLineRenderer : MonoBehaviour
    {
        [SerializeField] private float lineSegmentSize = 0.15f;
        [SerializeField] private float lineWidth = 0.1f;

        [SerializeField] private bool useCustomEndWidth = false;
        [SerializeField] private float endWidth = 0.1f;
        [SerializeField] private bool showGizmos = true;

        [SerializeField] private float gizmoSize = 0.1f;
        [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 0.5f);

        private CurvedLinePoint[] linePoints = new CurvedLinePoint[0];
        private Vector3[] linePositions = new Vector3[0];
        private Vector3[] linePositionsOld = new Vector3[0];
        private LineRenderer lineRenderer = null;
        private Material lineRendererMaterial = null;

        public CurvedLinePoint[] LinePoints
        {
            get
            {
                return linePoints;
            }
        }
        public void Update()
        {
           
        }
        public void Start()
        {
            GetPoints();
            SetPointsToLine();
            UpdateMaterial();
        }

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        private void GetPoints()
        {
            // find curved points in children
            // scan only the first hierarchy level to allow nested curved lines (like modelling a tree or a coral)
            List<CurvedLinePoint> curvedLinePoints = new List<CurvedLinePoint>();
            for(int i=0; i<transform.childCount;i++)
            {
                CurvedLinePoint childPoint = transform.GetChild(i).GetComponent<CurvedLinePoint>();
                if(childPoint!=null)
                {
                    curvedLinePoints.Add(childPoint);
                }
            }
            linePoints = curvedLinePoints.ToArray();

            //add positions
            linePositions = new Vector3[linePoints.Length];
            for (int i = 0; i < linePoints.Length; i++)
            {
                linePositions[i] = linePoints[i].transform.position;
            }
        }


        private void SetPointsToLine()
        {
            //create old positions if they dont match
            if (linePositionsOld.Length != linePositions.Length)
            {
                linePositionsOld = new Vector3[linePositions.Length];
            }

            //check if line points have moved
            bool moved = false;
            for (int i = 0; i < linePositions.Length; i++)
            {
                //compare
                if (linePositions[i] != linePositionsOld[i])
                {
                    moved = true;
                }
            }

            //update if moved
            if (moved == true)
            {
                if (lineRenderer==null)
                {
                    lineRenderer = GetComponent<LineRenderer>();
                }
                //get smoothed values
                Vector3[] smoothedPoints = LineSmoother.SmoothLine(linePositions, lineSegmentSize);

                //set line settings
                lineRenderer.positionCount = smoothedPoints.Length;
                lineRenderer.SetPositions(smoothedPoints);
                lineRenderer.startWidth = lineWidth;
                lineRenderer.endWidth = useCustomEndWidth ? endWidth : lineWidth;
            }
        }


        private void OnDrawGizmosSelected()
        {
            Update();
        }


        private void OnDrawGizmos()
        {
            if (linePoints.Length == 0)
            {
                GetPoints();
            }

            //settings for gizmos
            foreach (CurvedLinePoint linePoint in linePoints)
            {
                linePoint.showGizmo = showGizmos;
                linePoint.gizmoSize = gizmoSize;
                linePoint.gizmoColor = gizmoColor;
            }
        }

        private void UpdateMaterial()
        {
            if (lineRenderer==null)
            {
                lineRenderer = GetComponent<LineRenderer>();
            }
            Material lineMaterial = lineRenderer.sharedMaterial;
            if (lineRendererMaterial != lineMaterial)
            {
                if (lineMaterial != null)
                {
                    lineRenderer.generateLightingData = !lineMaterial.shader.name.StartsWith("Unlit");
                }
                else
                {
                    lineRenderer.generateLightingData = false;
                }
            }
            lineRendererMaterial = lineMaterial;
        }
    }
}
