namespace Nox;

public enum EntityMemberType
{
    Attribute,
    Key,
    Relationship,
    OwnedRelationship,
    ImpliedRelationship,
    Query,
    Command,
    DomainEvent,
    IntegrationEvent,
    UniqueConstraint,
    Entity
}