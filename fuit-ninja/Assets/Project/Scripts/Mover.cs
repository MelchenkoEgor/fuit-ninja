using UnityEngine;

namespace Project.Scripts
{
    public class Mover : MonoBehaviour
    {
        public float speed;
        private void Start()
        {
            OnDestroy();
        }
        
        private void Update()
        {
            var transform1 = transform;
            transform.position = Vector2.Lerp(transform1.position, transform1.up, speed * Time.deltaTime);
        }

        private void OnDestroy()
        {
            if (Camera.main is null) return;
            var v = Camera.main.ScreenToWorldPoint(Vector2.zero);

            if (transform.position.y < v.y || transform.position.y > (-v.y) || transform.position.x > (-v.x) || transform.position.x < v.x )
            {
                Destroy(gameObject);
            }
        }
    }
}
