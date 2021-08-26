using UnityEngine;


namespace Main
{
    public class EnemySpawner : MonoBehaviour
    {

        public float _spawnTimer = 2f;
        private bool _isPaused;
        private Enemy _enemy;
        private Vector3 _spawnPoint;
        private int _maxEnemy=10;


        public Vector3 SpawnCoords()
        {
             return _spawnPoint=new Vector3(RandomX(), RandomY(), RandomZ());
        }

        public void SetPause(bool isPaused)
        {
            _isPaused = isPaused;
        }
        
        public Enemy Enemy
        {
            get
            {
               var enemyCount = Object.FindObjectsOfType<Enemy>();

               if (_isPaused) return _enemy;
               
               if (enemyCount.Length < _maxEnemy)
               {
                   var enemy = Resources.Load<Enemy>("EnemySmall");
                   var spawnPoint = SpawnCoords();
                   _enemy = Object.Instantiate(enemy, spawnPoint, Quaternion.identity);
                   _enemy.transform.Rotate(0, 180, 0);
               }
               else
               {
                   gameObject.GetComponent<GameController>().GameOverScreen();
               }

               return _enemy;
               }

        }

        private float RandomX()
        {
            var randX = Random.Range(-6.44f, -3.33f);
            return randX;
        }

        private float RandomY()
        {
            var fixedY = 11f;
            return fixedY;
        }

        private float RandomZ()
        {
            var randZ = Random.Range(-4.54f, 6.5f);
            return randZ;
        }
    }
}