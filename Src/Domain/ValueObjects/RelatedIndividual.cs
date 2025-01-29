namespace Domain.ValueObjects;

public class RelatedIndividual
{
    public int RelatedIndividualId { get; private set; }
    public string ConnectionType { get; private set; }

    public RelatedIndividual(int relatedIndividualId, string connectionType)
    {
        ValidateConnectionType(connectionType);
        RelatedIndividualId = relatedIndividualId;
        ConnectionType = connectionType;
    }

    private void ValidateConnectionType(string connectionType)
    {
        if (connectionType != "colleague" && connectionType != "acquaintance" && connectionType != "relative" && connectionType != "other")
            throw new ArgumentException("Invalid connection type.");
    }
}