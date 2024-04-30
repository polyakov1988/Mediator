public class GameplayMediator
{
    private readonly DefeatPanel _defeatPanel;
    private readonly PlayerUI _playerUI;
    private readonly Player _player;

    public GameplayMediator(DefeatPanel defeatPanel, PlayerUI playerUI, Player player)
    {
        _defeatPanel = defeatPanel;
        _playerUI = playerUI;
        _player = player;
    }

    public void Initialize()
    {
        _player.Health.Changed += OnHealthChanged;
        _player.Health.Dead += OnDead;
        _player.Level.Changed += OnLevelChanged;
    }

    private void OnDestroy()
    {
        _player.Health.Changed -= OnHealthChanged;
        _player.Health.Dead -= OnDead;
        _player.Level.Changed -= OnLevelChanged;
    }
    
    private void OnHealthChanged(int health)
    {
        _playerUI.UpdateHealth(health);
    }

    private void OnLevelChanged(int level)
    {
        _playerUI.UpdateLevel(level);
    }
    
    private void OnDead() => _defeatPanel.Show();

    public void RestartPlayer()
    {
        _defeatPanel.Hide();
        _player.Restart();
    }

    public void AddHealth()
    {
        _player.Health.Heal(10);
    }
    
    public void TakeDamage()
    {
        _player.Health.TakeDamage(20);
    }
    
    public void UpLevel()
    {
        _player.Level.Up();
    }
    
    public void DownLevel()
    {
        _player.Level.Down();
    }
}