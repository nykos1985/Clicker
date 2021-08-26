using Menu;
using UnityEngine;
using UnityEngine.UI;


namespace Main
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject _gamePause;
        [SerializeField] private GameObject _gameOverScreen;

        private float _menuCallDelay;
        private float _spawnTimer;
        private ExecutableObjects _interactiveObjects;
        private EnemyController _enemyController;
        private InputController _inputController;
        private Reference _reference;
        private EnemySpawner _spawner;
        private MenuController _menu;
        

        public void GetSpawnData()
        {
            _spawnTimer = gameObject.GetComponent<EnemySpawner>()._spawnTimer;
        }
        
        private void Awake()
        {
            _gamePause.gameObject.SetActive(false);
            _gameOverScreen.gameObject.SetActive(false);
            
            _reference=new Reference();
            _spawner=gameObject.AddComponent<EnemySpawner>();

            _interactiveObjects=new ExecutableObjects();

            _inputController = gameObject.AddComponent<InputController>();
            _inputController.InpController(_reference.Player);

            _interactiveObjects.AddExecutableObject(_inputController);
            GetSpawnData();
            InvokeRepeating("Spawn", 0, _spawnTimer);
            
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];
            
                if (interactiveObject == null)
                {
                    continue;
                }
            
                interactiveObject.Execute();
            }
            
            PauseMenu();
        }
        
        private void PauseMenu()
        {
            
            _menuCallDelay -= Time.deltaTime;
            
            if (Input.GetKey(KeyCode.Escape)&&_menuCallDelay<=0)
            {
                if (_gamePause.gameObject.activeSelf)
                {
                    _gamePause.gameObject.SetActive(false);
                    _spawner.SetPause(false);
                }
                else
                {
                    _gamePause.gameObject.SetActive(true);
                    _spawner.SetPause(true);
                }
                
                _menuCallDelay = 1;
                
            }  
        }

        public void GameOverScreen()
        {
            _gameOverScreen.SetActive(true);
        }

        private void Spawn()
        {
            _enemyController=new EnemyController(_spawner.Enemy);
            _interactiveObjects.AddExecutableObject(_enemyController);
            GetSpawnData();
        }
    }

        

}