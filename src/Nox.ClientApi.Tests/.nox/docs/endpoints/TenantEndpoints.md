# API Endpoints for the Tenant entity

This document provides information about the various endpoints available in our API for the Tenant entity.

## Tenant Endpoints

### Get Tenant by ID
- **GET** `/api/Tenants/{key}`
  - Description: Retrieve information about a Tenant by ID.
  
### Get Tenants
- **GET** `/api/Tenants`
  - Description: Retrieve information about Tenants.

### Create Tenant
- **POST** `/api/Tenants`
  - Description: Create a new Tenant.

### Update Tenant
- **PUT** `/api/Tenants/{key}`
  - Description: Update an existing Tenant.

### Partially Update Tenant
- **PATCH** `/api/Tenants/{key}`
  - Description: Partially update an existing Tenant.
 
### Delete Tenant
- **DELETE** `/api/Tenants/{key}`
  - Description: Delete an existing Tenant.

## Relationships Endpoints

### Workplace

#### Get Workplace relations
- **GET** `/api/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Retrieve all existing Workplaces relations for a specific Tenant.
  
#### Create Workplace relation
- **POST** `/api/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Create a new Workplace relation for a specific Tenant.
  
#### Update Workplace relation
- **PUT** `/api/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Updates an existing Workplace relation for a specific Tenant.

#### Delete Workplace relation
- **DELETE** `/api/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Delete an existing Workplace relation for a specific Tenant.

#### Delete Workplace relations
- **DELETE** `/api/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Delete all existing Workplaces relations for a specific Tenant.

## Related Entities

[Workplace](WorkplaceEndpoints.md)
