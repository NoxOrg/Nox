# Domain Events for the CountryBarCode entity

This document provides information about the CountryBarCode Domain Events in our application.

## Events

### `CountryBarCodeCreated`

**Description:**
This event is triggered when a new CountryBarCode is created.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
BarCodeName|Text|Bar code name
BarCodeNumber|Number|Bar code number


### `CountryBarCodeUpdated`

**Description:** 
This event is triggered when an existing CountryBarCode is updated.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
BarCodeName|Text|Bar code name
BarCodeNumber|Number|Bar code number


### `CountryBarCodeDeleted`

**Description:**
This event is triggered when an existing CountryBarCode is deleted.

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
BarCodeName|Text|Bar code name
BarCodeNumber|Number|Bar code number

# Custom Domain Events for the CountryBarCode entity
### `BarcodeGeneratedEvent`

**Description:**Barcode generated event

**Members (Keys, Attributes & Relationships):**
Member|Type|Description
------|----|-----------
BarCodeName|Text|Bar code name
BarCodeNumber|Number|Bar code number
