# Domain Events for the Customer entity

This document provides information about the Customer Domain Events in our application.

## Events

### `CustomerCreated`

**Description:**
This event is triggered when a new Customer is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Customer's unique identifier
FirstName|Text|Customer's first name
LastName|Text|Customer's last name
EmailAddress|Email|Customer's email address
Address|StreetAddress|Customer's street address
MobileNumber|PhoneNumber|Customer's mobile number
CountryId|CountryCode2|Country unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CustomerUpdated`

**Description:** 
This event is triggered when an existing Customer is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Customer's unique identifier
FirstName|Text|Customer's first name
LastName|Text|Customer's last name
EmailAddress|Email|Customer's email address
Address|StreetAddress|Customer's street address
MobileNumber|PhoneNumber|Customer's mobile number
CountryId|CountryCode2|Country unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CustomerDeleted`

**Description:**
This event is triggered when an existing Customer is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Customer's unique identifier
FirstName|Text|Customer's first name
LastName|Text|Customer's last name
EmailAddress|Email|Customer's email address
Address|StreetAddress|Customer's street address
MobileNumber|PhoneNumber|Customer's mobile number
CountryId|CountryCode2|Country unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

