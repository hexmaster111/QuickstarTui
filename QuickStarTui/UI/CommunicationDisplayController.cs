using Terminal.Gui;

namespace QuickStarTui;

public static class CommunicationDisplay
{
    static readonly StatusItem _connectionStatus = new(Key.Null, "Not Started", null);
    static readonly StatusItem _txIndicator = new(Key.Null, "TX", null);
    static readonly StatusItem _rxIndicator = new(Key.Null, "RX", null);
    
    public static StatusItem ConnectionStatus() => _connectionStatus;
    public static StatusItem TxIndicator() => _txIndicator;
    public static StatusItem RxIndicator() => _rxIndicator;
    
    
    public static bool Connected { get; set; } = false;
    
    private static bool _txIndicatorToggle = true;
    private static bool _rxIndicatorToggle = false;
    
    
    private static Action<bool> DEBUG_ConnectionStatusChanged;
    private static Action DEBUG_DataMoving;

    
    public static void Setup()
    {
        DEBUG_ConnectionStatusChanged += OnConnectionStatusChanged;
        DEBUG_DataMoving += OnMessageRx;
        DEBUG_DataMoving += OnMessageTx;
    }

    public static void DebugChangeConnectionStatus()
    {
        Connected = !Connected;
        DEBUG_ConnectionStatusChanged?.Invoke(Connected);
        DEBUG_DataMoving?.Invoke();
    }

    public static void OnConnectionStatusChanged(bool connected)
    {
        _connectionStatus.Title = connected ? "Connected" : "Disconnected";
    }

    public static void OnMessageTx()
    {
        _txIndicatorToggle = !_txIndicatorToggle;
        _txIndicator.Title = _txIndicatorToggle ? "TX:↑" : "TX: ";
    }
    
    public static void OnMessageRx()
    {
        _rxIndicatorToggle = !_rxIndicatorToggle;
        _rxIndicator.Title = _rxIndicatorToggle ? "RX:↓" : "RX: ";
    }
    

}