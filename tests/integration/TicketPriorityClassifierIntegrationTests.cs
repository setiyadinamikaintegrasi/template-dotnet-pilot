using TemplateDotnetPilot.Domain;

namespace TemplateDotnetPilot.Tests.Integration;

public sealed class TicketPriorityClassifierIntegrationTests
{
    [Fact]
    [Trait("Category", "Integration")]
    public void Public_boundary_normalizes_case_whitespace_and_hyphenated_values()
    {
        var classifier = new TicketPriorityClassifier();

        var result = classifier.Classify(" HIGH ", "multiple-users", securityIncident: false);

        Assert.Equal(Priority.P2, result);
    }

    [Fact]
    [Trait("Category", "Integration")]
    public void Business_wide_impact_is_p2_even_when_severity_is_low()
    {
        var classifier = new TicketPriorityClassifier();

        var result = classifier.Classify("low", "business-wide", securityIncident: false);

        Assert.Equal(Priority.P2, result);
    }
}
