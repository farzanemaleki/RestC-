namespace SGSWS.Model;

public class Singleton
{
    private Singleton() { }

    private static _ContextR? _instanceR;
    private static _ContextRW? _instanceRW;

    public static _ContextR ContextR()
    {
        return _instanceR = _instanceR is null ? new _ContextR() : _instanceR;
    }

    public static _ContextRW ContextRW()
    {
        return _instanceRW = _instanceRW is null ? new _ContextRW() : _instanceRW;
    }

}

