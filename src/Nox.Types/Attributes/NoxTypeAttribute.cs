namespace Nox.Types
{
    

    /// <summary>
    /// Relate concrete <see cref="INoxType"/> implementation to <see cref="NoxType"/> enum
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class NoxTypeAttribute : System.Attribute
    {
        public NoxType NoxType { get; }

        public NoxTypeAttribute(NoxType noxType)
        {
            NoxType = noxType;
        }
    }
}
