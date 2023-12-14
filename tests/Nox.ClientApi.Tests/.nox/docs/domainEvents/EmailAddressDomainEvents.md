# Domain Events for the EmailAddress entity

This document provides information about the EmailAddress Domain Events in our application.

## Events

### `EmailAddressCreated`

**Description:**
This event is triggered when a new EmailAddress is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Email|Email|Email
IsVerified|Boolean|Verified


### `EmailAddressUpdated`

**Description:** 
This event is triggered when an existing EmailAddress is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Email|Email|Email
IsVerified|Boolean|Verified


### `EmailAddressDeleted`

**Description:**
This event is triggered when an existing EmailAddress is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Email|Email|Email
IsVerified|Boolean|Verified

