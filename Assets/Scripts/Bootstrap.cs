using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private DefeatPanel _defeatPanel;
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private Player _player;
    
    private GameplayMediator _gameplayMediator;

    private void Awake()
    {
        _player.Initialize();
        
        _gameplayMediator = new (_defeatPanel, _playerUI, _player);
        _gameplayMediator.Initialize();
        
        _defeatPanel.Initialize(_gameplayMediator);
        _playerUI.Initialize(_gameplayMediator);
        
        _player.InvokeParams();
    }
}
