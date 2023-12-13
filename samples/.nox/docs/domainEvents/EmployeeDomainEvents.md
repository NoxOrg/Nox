# Domain Events for the Employee entity

This document provides information about the Employee Domain Events in our application.

## Events

### `EmployeeCreated`

**Description:**
This event is triggered when a new Employee is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Employee's unique identifier
FirstName|Text|Employee's first name
LastName|Text|Employee's last name
EmailAddress|Email|Employee's email address
Address|StreetAddress|Employee's street address
FirstWorkingDay|Date|Employee's first working day
LastWorkingDay|Date|Employee's last working day
EmployeePhoneNumberId|AutoNumber|Employee's phone number identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `EmployeeUpdated`

**Description:** 
This event is triggered when an existing Employee is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Employee's unique identifier
FirstName|Text|Employee's first name
LastName|Text|Employee's last name
EmailAddress|Email|Employee's email address
Address|StreetAddress|Employee's street address
FirstWorkingDay|Date|Employee's first working day
LastWorkingDay|Date|Employee's last working day
EmployeePhoneNumberId|AutoNumber|Employee's phone number identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `EmployeeDeleted`

**Description:**
This event is triggered when an existing Employee is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|Employee's unique identifier
FirstName|Text|Employee's first name
LastName|Text|Employee's last name
EmailAddress|Email|Employee's email address
Address|StreetAddress|Employee's street address
FirstWorkingDay|Date|Employee's first working day
LastWorkingDay|Date|Employee's last working day
EmployeePhoneNumberId|AutoNumber|Employee's phone number identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*

