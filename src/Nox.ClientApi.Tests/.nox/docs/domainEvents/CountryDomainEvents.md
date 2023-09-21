# Domain Events for the Country entity

This document provides information about the Country Domain Events in our application.

## Events

### `CountryCreated`

**Description:**
This event is triggered when a new Country is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|The unique identifier
Name|Text|The Country Name
Population|Number|Population
CountryDebt|Money|The Money
FirstLanguageCode|LanguageCode|First Official Language
ShortDescription|Formula|The Formula
CountryLocalNameId|AutoNumber|The unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CountryUpdated`

**Description:** 
This event is triggered when an existing Country is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|The unique identifier
Name|Text|The Country Name
Population|Number|Population
CountryDebt|Money|The Money
FirstLanguageCode|LanguageCode|First Official Language
ShortDescription|Formula|The Formula
CountryLocalNameId|AutoNumber|The unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*


### `CountryDeleted`

**Description:**
This event is triggered when an existing Country is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
Id|AutoNumber|The unique identifier
Name|Text|The Country Name
Population|Number|Population
CountryDebt|Money|The Money
FirstLanguageCode|LanguageCode|First Official Language
ShortDescription|Formula|The Formula
CountryLocalNameId|AutoNumber|The unique identifier
*(AuditInfo)*||*Contains date/time, user and system info on state changes.*|*Created, Updated, Deleted*
