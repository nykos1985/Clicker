using UnityEngine;
using Random = UnityEngine.Random;


namespace Main
{
    public class EnemyController : IExecute
    {
        
        private Enemy _enemy;
        private Rigidbody _rb;
        private float _min = 0f;
        private float _max = 0.3f;

        public EnemyController(Enemy enemy)
        {
            _enemy = enemy;
            //_rb = _enemy.GetComponent<Rigidbody>();
        }

        public void Execute()
        {
            //TODO:EnemyMovement();
        }

        private void EnemyMovement()
        {
            _rb.velocity = RandomWay();
        }

        private Vector3 RandomWay()
        {
            var x = Random.Range(_min, _max);
            var y = Random.Range(_min, _max);
            var z = Random.Range(_min, _max);
            
            return new Vector3(x,y,z);
        }
    }
}