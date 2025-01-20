using UnityEngine;

// A script that transfers the distance traveled by the Trail Renderer's Head when it moves to the material's scroll UV.
// Trail Renderer's Texture Mode must be Tile
// The values passed to the material are between 0 and 1..
[ExecuteAlways]
public class MoveToTrailUV : MonoBehaviour
{
    [System.Serializable]
    public struct MaterialData
    {
        public MaterialData(TrailRenderer trailRenderer, Material material, Vector2 uvScale, float move)
        {
            m_trailRenderer = trailRenderer;
            m_uvTiling = uvScale;
            m_move = move;
        }

        public TrailRenderer m_trailRenderer;
        [HideInInspector] public Vector2 m_uvTiling;
        [HideInInspector] public float m_move;
    }

#if UNITY_EDITOR
    //public bool m_overrideMaterial = true;
#endif
    public Transform m_moveObject;
    public string m_shaderPropertyName = "_MoveToMaterialUV"; // Property name that will accept UV values in the shader.
    public int m_shaderPropertyID; // ID for shader properties without using strings
    public MaterialData[] m_materialData = new MaterialData[1] { new MaterialData(null, null, new Vector2(1, 1), 0f) };

    private Vector3 m_beforePosW = Vector3.zero;
    void Start()
    {
        Initialize();
    }

    void LateUpdate()
    {
        if (m_moveObject == null)
            return;
        if (m_materialData == null || m_materialData.Length == 0)
            return;

        Vector3 nowPosW = m_moveObject.transform.position;
        if (nowPosW == m_beforePosW)
            return; // Do nothing if there is no change in location

        float distance = Vector3.Distance(nowPosW, m_beforePosW);
        m_beforePosW = nowPosW;

        for (int i = 0; i < m_materialData.Length; i++)
        {
            if (m_materialData[i].m_trailRenderer == null)
                continue;

            m_materialData[i].m_move += distance * m_materialData[i].m_uvTiling.x;
            // m_move To avoid values becoming too large, only the remainder is passed
            //      if it is greater than 1 (it must already be a value multiplied by m_uvTiling.x).
            if (m_materialData[i].m_move > 1f)
            {
                m_materialData[i].m_move = m_materialData[i].m_move % 1f;
            }

            // Record without checking for property existence.
            // There is a problem that the material version is continuously treated as changed if the property exists..
            TrailRenderer trailRenderer = m_materialData[i].m_trailRenderer;
            if (trailRenderer != null)
            {
                Material mat = trailRenderer.sharedMaterial;
                if (mat != null)
                {
                    mat.SetFloat(m_shaderPropertyID, m_materialData[i].m_move);
                }
            }
        }
    }

    public void Initialize()
    {
        if (m_materialData == null || m_materialData.Length == 0)
            return;

        m_shaderPropertyID = Shader.PropertyToID(m_shaderPropertyName);

        for (int i = 0; i < m_materialData.Length; i++)
        {
            m_materialData[i].m_move = 0f;
            TrailRenderer trailRenderer = m_materialData[i].m_trailRenderer;
            if (trailRenderer != null)
            {
                Material mat = trailRenderer.sharedMaterial;
                if (mat != null)
                {
                    m_materialData[i].m_uvTiling = mat.mainTextureScale;
                }
            }
        }
    }
}