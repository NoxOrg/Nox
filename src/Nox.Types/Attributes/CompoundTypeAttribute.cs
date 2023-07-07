using System;

namespace Nox.Types;


/// <summary>
/// Defines that a NoxType is a composition of multiple primitive properties
/// Used to setup properly the database model
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
public class CompoundTypeAttribute : Attribute
{
}