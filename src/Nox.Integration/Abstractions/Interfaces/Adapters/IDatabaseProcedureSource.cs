using ETLBox;

namespace Nox.Integration.Abstractions.Interfaces;

public interface IDatabaseProcedureSource<TOutput>: IDataFlowExecutableSource<TOutput>
{
    void SetParameter(string name, object value);
}