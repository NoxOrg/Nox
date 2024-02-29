# Domain Events for the Person entity

This document provides information about the Person Domain Events in our application.

## Events

### `PersonCreated`

**Description:**
This event is triggered when a new Person is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|The person unique identifier
FirstName|Text|The user's first name
LastName|Text|The customer's last name
TenantId|Guid|Tenant user bellongs to
PrimaryEmailAddress|Email|The user's primary email for MFA
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `PersonUpdated`

**Description:** 
This event is triggered when an existing Person is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|The person unique identifier
FirstName|Text|The user's first name
LastName|Text|The customer's last name
TenantId|Guid|Tenant user bellongs to
PrimaryEmailAddress|Email|The user's primary email for MFA
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `PersonDeleted`

**Description:**
This event is triggered when an existing Person is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|Guid|The person unique identifier
FirstName|Text|The user's first name
LastName|Text|The customer's last name
TenantId|Guid|Tenant user bellongs to
PrimaryEmailAddress|Email|The user's primary email for MFA
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

