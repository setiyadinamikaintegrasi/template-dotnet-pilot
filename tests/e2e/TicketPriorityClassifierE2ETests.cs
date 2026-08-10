using TemplateDotnetPilot.Domain;

namespace TemplateDotnetPilot.Tests.E2E;

public sealed class TicketPriorityClassifierE2ETests
{
    [Theory]
    [InlineData("critical", "business-wide", false, Priority.P1)]
    [InlineData("high", "multiple-users", false, Priority.P2)]
    [InlineData("medium", "multiple-users", false, Priority.P3)]
    [InlineData("low", "single-user", false, Priority.P4)]
    [Trait("Category", "E2E")]
    public void Complete_ticket_journey_returns_expected_priority(
        string severity,
        string impact,
        bool securityIncident,
        Priority expected)
    {
        var classifier = new TicketPriorityClassifier();

        var result = classifier.Classify(severity, impact, securityIncident);

        Assert.Equal(expected, result);
    }
}
