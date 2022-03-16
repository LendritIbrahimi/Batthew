using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float m_OffsetY;

        private float m_OffsetZ;
        private Vector3 m_CurrentVelocity = Vector3.zero;


        // Use this for initializatio
        private void Start()
        {
            m_OffsetZ = transform.position.z;
        }


        // Update is called once per frame
        private void Update()
        {
            Vector3 aheadTargetPos = new Vector3(target.position.x, m_OffsetY, m_OffsetZ);
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;
        }
    }
}
