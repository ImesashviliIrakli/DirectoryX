﻿using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

public sealed class RelatedIndividual : Entity
{
    public int IndividualId { get; private set; } // Foreign Key to Individual
    public int RelatedIndividualId { get; private set; } // Related Individual
    public RelationshipType RelationshipType { get; private set; }

    private RelatedIndividual() { } // Required by EF Core

    public RelatedIndividual(int relatedIndividualId, RelationshipType relationshipType)
    {
        //ValidateConnectionType(relationshipType);
        RelatedIndividualId = relatedIndividualId;
        RelationshipType = relationshipType;
    }

    private void ValidateConnectionType(string connectionType)
    {
        if (connectionType != "colleague" && connectionType != "acquaintance" && connectionType != "relative" && connectionType != "other")
            throw new ArgumentException("Invalid connection type.");
    }
}

