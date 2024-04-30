using System;

public class Health
{
    private readonly int _maxValue;
    private int _value;

    public event Action<int> Changed;
    public event Action Dead;

    public Health(int value)
    {
        _value = value;
        _maxValue = value;
    }

    public void InvokeChanged() => Changed?.Invoke(_value);

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException(nameof(damage));
        
        if (_value == 0)
            return;
        
        _value -= damage;

        if (_value <= 0)
        {
            _value = 0;
            Dead?.Invoke();
        }
           
        
        Changed?.Invoke(_value);
    }
    
    public void Heal(int value)
    {
        if (value < 0)
            throw new ArgumentException(nameof(value));
        
        _value += value;

        if (_value > _maxValue)
            _value = _maxValue;
        
        Changed?.Invoke(_value);
    }

    public void Restart()
    {
        _value = _maxValue;
        Changed?.Invoke(_value);
    }
}
