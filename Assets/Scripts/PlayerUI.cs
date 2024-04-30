using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Button _plusHealth;
    [SerializeField] private Button _minusHealth;
    [SerializeField] private Button _plusLevel;
    [SerializeField] private Button _minusLevel;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _level;
    
    private GameplayMediator _mediator;
    
    private void OnEnable()
    {
        _plusHealth.onClick.AddListener(OnPlusHealthClicked);
        _minusHealth.onClick.AddListener(OnMinusHealthClicked);
        _plusLevel.onClick.AddListener(OnPlusLevelClicked);
        _minusLevel.onClick.AddListener(OnMinusLevelClicked);
    }

    private void OnDisable()
    {
        _plusHealth.onClick.RemoveListener(OnPlusHealthClicked);
        _minusHealth.onClick.RemoveListener(OnMinusHealthClicked);
        _plusLevel.onClick.RemoveListener(OnPlusLevelClicked);
        _minusLevel.onClick.RemoveListener(OnMinusLevelClicked);
    }
    
    public void Initialize(GameplayMediator gameplayMediator) => _mediator = gameplayMediator;
    
    public void UpdateHealth(int health)
    {
        _health.text = health.ToString();
    }
    
    public void UpdateLevel(int level)
    {
        _level.text = level.ToString();
    }

    private void OnPlusHealthClicked()
    {
        _mediator.AddHealth();
    }
    
    private void OnMinusHealthClicked()
    {
        _mediator.TakeDamage();
    }
    
    private void OnPlusLevelClicked()
    {
        _mediator.UpLevel();
    }
    
    private void OnMinusLevelClicked()
    {
        _mediator.DownLevel();
    }
}
