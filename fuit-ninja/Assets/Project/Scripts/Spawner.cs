using UnityEngine;

namespace Project.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject prefab;
        [Header("Spawn interval & rate")]
        public float intervalTime;
        public float repeatRate;
        [Header("LeftBottom spawn")]
        public float minimumXBottomLeft;
        public float maximumXBottomLeft;
        [Header("RightBottom spawn")]
        public float minimumXBottomRight;
        public float maximumXBottomRight;
        [Header("Left spawn")]
        public float minimumYLeft;
        public float maximumYLeft;
        [Header("Right spawn")]
        public float minimumYRight;
        public float maximumYRight;
        [Header("Count elements")] 
        public float countLeftBottomElements;
        public float countRightBottomElements;
        public float countLeftElements;
        public float countRightElements;
        [Header("Count elements modify")] 
        public float countModifyGeneral;
        [Header("Chance spawn")]
        public float chanceOfSpawningFromLeft;
        public float chanceOfSpawningFromRight;
        public float chanceOfSpawningFromBottomLeft;
        public float chanceOfSpawningFromBottomRight;
        [Header("Visible elements")]
        public float plusForVisible;

        public Sprite[] sprites;
        
        private void Start()
        {
            RepeatingSpawn();
        }

        private void RepeatingSpawn()
        {
            InvokeRepeating(nameof(SpawnChance), intervalTime, repeatRate);
        }

        public void SpawnChance()
        {
            var randomChance = Random.value;
            
            if (randomChance >= chanceOfSpawningFromLeft) // 0.8
            {
                SpawnLeft();
            }
            else if(randomChance >= chanceOfSpawningFromRight && randomChance < chanceOfSpawningFromLeft) // 0.6
            {
                SpawnRight();
            }
            else if(randomChance >= chanceOfSpawningFromBottomLeft && randomChance < chanceOfSpawningFromRight) // 0.3
            {
                SpawnBottomLeft();
            }
            else if(randomChance >= chanceOfSpawningFromBottomRight && randomChance < chanceOfSpawningFromBottomLeft) // 0.0
            {
                SpawnBottomRight();
            }
        }

        private void SpawnBottomLeft()
        {
            for (var i = 0; i < countLeftBottomElements * countModifyGeneral; i++)
            {
                var instance = Instantiate(prefab);

                var randomSprite = sprites[Random.Range(0, sprites.Length)];
                instance.GetComponent<SpriteRenderer>().sprite = randomSprite;

                if (Camera.main is null) continue;
                var v = Camera.main.ScreenToWorldPoint(Vector2.zero);

                instance.transform.position =
                    new Vector2(Random.Range(minimumXBottomLeft, maximumXBottomLeft), (v.y + plusForVisible));
            }
        }

        private void SpawnBottomRight()
        {
            for (var i = 0; i < countRightBottomElements * countModifyGeneral; i++)
            {
                var instance = Instantiate(prefab);
        
                var randomSprite = sprites[Random.Range(0, sprites.Length)];
                instance.GetComponent<SpriteRenderer>().sprite = randomSprite;

                if (Camera.main is null) continue;
                var v = Camera.main.ScreenToWorldPoint(Vector2.zero);
        
                instance.transform.position = 
                    new Vector2(Random.Range(minimumXBottomRight, maximumXBottomRight), (v.y + plusForVisible));
            }
        }

        private void SpawnLeft()
        {
            for (var i = 0; i < countLeftElements * countModifyGeneral; i++)
            {
                var instance = Instantiate(prefab);
        
                var randomSprite = sprites[Random.Range(0, sprites.Length)];
                instance.GetComponent<SpriteRenderer>().sprite = randomSprite;

                if (Camera.main is null) continue;
                var v = Camera.main.ScreenToWorldPoint(Vector2.zero);
        
                instance.transform.position = 
                    new Vector2((v.x + plusForVisible),Random.Range(minimumYLeft, maximumYLeft));
            }
        }

        private void SpawnRight()
        {
            for (var i = 0; i < countRightElements * countModifyGeneral; i++)
            {
                var instance = Instantiate(prefab);
        
                var randomSprite = sprites[Random.Range(0, sprites.Length)];
                instance.GetComponent<SpriteRenderer>().sprite = randomSprite;

                if (Camera.main is null) continue;
                var v = Camera.main.ScreenToWorldPoint(Vector2.zero);
        
                instance.transform.position = 
                    new Vector2((-v.x - plusForVisible), Random.Range(minimumYRight, maximumYRight));
            }
        }
    }
}
