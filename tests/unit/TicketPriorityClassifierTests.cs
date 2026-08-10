using TemplateDotnetPilot.Domain;

namespace TemplateDotnetPilot.Tests.Unit;

public sealed class TicketPriorityClassifierTests
{
    private readonly TicketPriorityClassifier classifier = new();

    [Fact]
    [Trait("Category", "Unit")]
    public void Critical_severity_is_p1()
    {
        Assert.Equal(Priority.P1, classifier.Classify("critical", "single-user", securityIncident: false));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void High_severity_is_p2()
    {
        Assert.Equal(Priority.P2, classifier.Classify("high", "single-user", securityIncident: false));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Medium_severity_is_p3()
    {
        Assert.Equal(Priority.P3, classifier.Classify("medium", "single-user", securityIncident: false));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Low_single_user_is_p4()
    {
        Assert.Equal(Priority.P4, classifier.Classify("low", "single-user", securityIncident: false));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Security_incident_overrides_other_inputs()
    {
        Assert.Equal(Priority.P1, classifier.Classify("low", "single-user", securityIncident: true));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [Trait("Category", "Unit")]
    public void Blank_severity_is_rejected(string? severity)
    {
        Assert.ThrowsAny<ArgumentException>(() => classifier.Classify(severity!, "single-user", securityIncident: false));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Unsupported_impact_is_rejected()
    {
        Assert.Throws<ArgumentException>(() => classifier.Classify("low", "everyone", securityIncident: false));
    }
}
