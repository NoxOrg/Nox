﻿using Nox.Generator.Validation;
using FluentValidation;

namespace Nox.Generator.Common
{
    internal class GeneratorConfig
    {
        public bool Domain { get; set; } = true;

        public bool Application { get; set; } = true;

        public bool Infrastructure { get; set; } = true;

        public bool Presentation { get; set; } = true;

        public bool Ui { get; set; } = false;

        internal void Validate()
        {
            var validator = new GeneratorConfigValidator();
            validator.ValidateAndThrow(this);
        }
    }
}
