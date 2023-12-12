# Domain Events for the EmployeePhoneNumber entity

This document provides information about the EmployeePhoneNumber Domain Events in our application.

## Events

### `EmployeePhoneNumberCreated`

**Description:**
This event is triggered when a new EmployeePhoneNumber is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Employee's phone number identifier
PhoneNumberType|Text|Employee's phone number type
PhoneNumber|PhoneNumber|Employee's phone number


### `EmployeePhoneNumberUpdated`

**Description:** 
This event is triggered when an existing EmployeePhoneNumber is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Employee's phone number identifier
PhoneNumberType|Text|Employee's phone number type
PhoneNumber|PhoneNumber|Employee's phone number


### `EmployeePhoneNumberDeleted`

**Description:**
This event is triggered when an existing EmployeePhoneNumber is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Employee's phone number identifier
PhoneNumberType|Text|Employee's phone number type
PhoneNumber|PhoneNumber|Employee's phone number

