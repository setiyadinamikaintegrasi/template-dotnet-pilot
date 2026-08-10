namespace TemplateDotnetPilot.Domain;

public sealed class TicketPriorityClassifier
{
    private static readonly HashSet<string> SupportedSeverities =
        new(StringComparer.OrdinalIgnoreCase) { "low", "medium", "high", "critical" };

    private static readonly HashSet<string> SupportedImpacts =
        new(StringComparer.OrdinalIgnoreCase) { "single-user", "multiple-users", "business-wide" };

    public Priority Classify(string severity, string impact, bool securityIncident)
    {
        var normalizedSeverity = Normalize(severity, SupportedSeverities, nameof(severity));
        var normalizedImpact = Normalize(impact, SupportedImpacts, nameof(impact));

        if (securityIncident || normalizedSeverity == "critical")
        {
            return Priority.P1;
        }

        if (normalizedSeverity == "high" || normalizedImpact == "business-wide")
        {
            return Priority.P2;
        }

        if (normalizedSeverity == "medium" || normalizedImpact == "multiple-users")
        {
            return Priority.P3;
        }

        return Priority.P4;
    }

    private static string Normalize(string value, HashSet<string> supported, string parameterName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, parameterName);
        var normalized = value.Trim().ToLowerInvariant();
        if (!supported.Contains(normalized))
        {
            throw new ArgumentException($"Unsupported {parameterName}: {value}", parameterName);
        }

        return normalized;
    }
}
