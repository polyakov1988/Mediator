using System;

public class Level
{
    private const int MinValue = 1;
    private int _value;

    public event Action<int> Changed;
    
    public Level()
    {
        Restart();
    }
    
    public void InvokeChanged() => Changed?.Invoke(_value);

    public void Up()
    {
        _value++;
        Changed?.Invoke(_value);
    }
    
    public void Down()
    {
        if (_value == MinValue)
            return;
        
        _value--;
        Changed?.Invoke(_value);
    }

    public void Restart()
    {
        _value = MinValue;
        Changed?.Invoke(_value);
    }
}
