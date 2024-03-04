# Domain Events for the UserContactSelection entity

This document provides information about the UserContactSelection Domain Events in our application.

## Events

### `UserContactSelectionCreated`

**Description:**
This event is triggered when a new UserContactSelection is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
ContactId|Guid|Contact Id that user switched to
AccountId|Guid|Account Id that user switched to
SelectedDate|DateTime|selected date


### `UserContactSelectionUpdated`

**Description:** 
This event is triggered when an existing UserContactSelection is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
ContactId|Guid|Contact Id that user switched to
AccountId|Guid|Account Id that user switched to
SelectedDate|DateTime|selected date


### `UserContactSelectionDeleted`

**Description:**
This event is triggered when an existing UserContactSelection is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
ContactId|Guid|Contact Id that user switched to
AccountId|Guid|Account Id that user switched to
SelectedDate|DateTime|selected date

