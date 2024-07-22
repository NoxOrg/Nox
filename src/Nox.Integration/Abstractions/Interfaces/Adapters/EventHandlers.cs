using Nox.Integration.Abstractions.Models;

namespace Nox.Integration.Abstractions.Interfaces;

public delegate void InsertEventHandler(object sender, MetricsEventArgs args);
public delegate void UpdateEventHandler(object sender, MetricsEventArgs args);