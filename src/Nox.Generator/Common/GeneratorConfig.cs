namespace Nox.Generator.Common
{
    internal class GeneratorConfig
    {
        public bool Domain { get; set; } = true;
        public bool Application { get; set; } = true;
        public bool Infrastructure { get; set; } = true;
        public bool Presentation { get; set; } = true;
    }
}
