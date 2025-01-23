using UnityEngine;

namespace Game.CameraManagement
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform Target => target;

        [SerializeField] private Transform target;
        [SerializeField, Range(0.01f, 0.5f)] private float cameraHeight = 0.25f;
        [SerializeField, Range(1.0f, 100.0f)] private float distance;
        [SerializeField, Range(1.0f, 10.0f)] private float rotationSpeed = 3.0f;
        [SerializeField, Range(0.01f, 1.0f)] private float smoothTime = 0.2f;

        [SerializeField] private Texture2D crosshairTexture; // Tekstura celownika
        [SerializeField] private Vector2 crosshairSize = new Vector2(32, 32); // Rozmiar celownika
        [SerializeField] private Vector2 crosshairOffset = Vector2.zero; // Przesuniêcie celownika

        private Vector3 cameraPos;
        private Vector3 velocity;
        private Transform t;

        private float angle;
        private bool showCrosshair; // Flaga pokazuj¹ca, czy rysowaæ celownik

        private void Awake()
        {
            t = transform;
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(1)) // Klikniêcie prawego przycisku
            {
                showCrosshair = true; // W³¹cz rysowanie celownika
                distance = 1f;
                smoothTime = 0.0001f;
                cameraHeight = 0.8f;
                rotationSpeed = 50f;
            }
            else if (Input.GetMouseButtonUp(1)) // Puszczenie prawego przycisku
            {
                showCrosshair = false; // Wy³¹cz rysowanie celownika
                distance = 7f;
                smoothTime = 0.2f;
                cameraHeight = 0.25f;
                rotationSpeed = 3f;
            }

            FollowPlayer();
        }

        private void FollowPlayer()
        {
            cameraPos = target.position - (target.forward * distance) + target.up * distance * cameraHeight;
            t.position = Vector3.SmoothDamp(t.position, cameraPos, ref velocity, smoothTime);
            angle = Mathf.Abs(Quaternion.Angle(t.rotation, target.rotation));
            t.rotation = Quaternion.RotateTowards(
                t.rotation, target.rotation, (angle * rotationSpeed) * Time.deltaTime);
        }

        private void OnGUI()
        {
            if (showCrosshair && crosshairTexture != null)
            {
                // Oblicz pozycjê celownika z uwzglêdnieniem przesuniêcia
                float x = (Screen.width - crosshairSize.x) / 2 + crosshairOffset.x;
                float y = (Screen.height - crosshairSize.y) / 2 + crosshairOffset.y;

                // Rysuj teksturê celownika
                GUI.DrawTexture(new Rect(x, y, crosshairSize.x, crosshairSize.y), crosshairTexture);
            }
        }
    }
}
