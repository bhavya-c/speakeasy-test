# WorkflowInstanceManagement
(*Maestro.WorkflowInstanceManagement*)

## Overview

### Available Operations

* [GetWorkflowInstancesList](#getworkflowinstanceslist) - Retrieve All Workflow Instances
* [GetWorkflowInstance](#getworkflowinstance) - Retrieve a Workflow Instance
* [CancelWorkflowInstance](#cancelworkflowinstance) - Cancel a Running Workflow Instance

## GetWorkflowInstancesList

This operation retrieves a list of all available Maestro workflow instances. It returns basic information
about each workflow instance, including its unique identifier (`id`), name, status, timestamps, and
additional metadata.

The response provides key details that help users understand what workflow instances are in progress
or completed, and the relevant data for each. Each workflow instance entry also includes metadata, such
as who started it, when it was last modified, and how many steps have been completed.

### Use Cases:
- Listing all available workflow instances for manual or automated review
- Monitoring which workflow instances are currently running or have finished
- Gathering basic metadata about workflow instances for auditing, logging, or reporting purposes

### Key Features:
- **Comprehensive Instance Overview**: Provides a full list of workflow instances, giving visibility








  into all ongoing and completed workflows within the Maestro platform
- **Metadata for Tracking**: Includes helpful metadata like creation time, last modification date,








  and user details to support audit trails
- **Scalable and Future-Proof**: Designed to handle growing numbers of workflow instances as the








  platform scales


### Example Usage

```csharp
using Docusign.IAM;
using Docusign.IAM.Models.Components;

var sdk = new DocusignIamSDK(accessToken: "<YOUR_ACCESS_TOKEN_HERE>");

var res = await sdk.Maestro.WorkflowInstanceManagement.GetWorkflowInstancesListAsync(
    accountId: "ae232f1f-8efc-4b8c-bb08-626847fad8bb",
    workflowId: "ae232f1f-8efc-4b8c-bb08-626847fad8bb"
);

// handle response
```

### Parameters

| Parameter                              | Type                                   | Required                               | Description                            | Example                                |
| -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- |
| `AccountId`                            | *string*                               | :heavy_check_mark:                     | The unique identifier of the account.  | ae232f1f-8efc-4b8c-bb08-626847fad8bb   |
| `WorkflowId`                           | *string*                               | :heavy_check_mark:                     | The unique identifier of the workflow. | ae232f1f-8efc-4b8c-bb08-626847fad8bb   |
| `serverURL`                            | *string*                               | :heavy_minus_sign:                     | An optional server URL to use.         | http://localhost:8080                  |

### Response

**[GetWorkflowInstancesListResponse](../../Models/Requests/GetWorkflowInstancesListResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Docusign.IAM.Models.Errors.APIException | 4XX, 5XX                                | \*/\*                                   |

## GetWorkflowInstance

This operation retrieves a single Maestro workflow instance by its unique identifier (`id`).
It returns the primary details of the workflow instance, including its name, status,
starting information, and other metadata.

The response provides key details that help users understand the current state of the workflow
instance, when it was started, and who initiated it. Additional metadata is included to support
auditing and reporting within the system.

### Use Cases:
- Getting the details of a specific workflow instance for further processing or review
- Monitoring the status of a running workflow instance to determine completion or cancellation
- Accessing metadata for auditing, logging, or reporting on a single workflow instance

### Key Features:
- **Single Workflow Instance**: Provides direct access to a specific workflow instance by `id`
- **Detailed Status Information**: Includes the workflow's start and end times, status, and other lifecycle timestamps
- **Metadata for Tracking**: Useful metadata like who initiated the workflow (`started_by`) and versioning details
- **Future-Proof**: Designed to be extensible if additional fields or nested information are required over time


### Example Usage

```csharp
using Docusign.IAM;
using Docusign.IAM.Models.Components;

var sdk = new DocusignIamSDK(accessToken: "<YOUR_ACCESS_TOKEN_HERE>");

var res = await sdk.Maestro.WorkflowInstanceManagement.GetWorkflowInstanceAsync(
    accountId: "ae232f1f-8efc-4b8c-bb08-626847fad8bb",
    workflowId: "ae232f1f-8efc-4b8c-bb08-626847fad8bb",
    instanceId: "343cdb70-676f-41e2-bc46-774c1c60e9ff"
);

// handle response
```

### Parameters

| Parameter                                   | Type                                        | Required                                    | Description                                 | Example                                     |
| ------------------------------------------- | ------------------------------------------- | ------------------------------------------- | ------------------------------------------- | ------------------------------------------- |
| `AccountId`                                 | *string*                                    | :heavy_check_mark:                          | The unique identifier of the account.       | ae232f1f-8efc-4b8c-bb08-626847fad8bb        |
| `WorkflowId`                                | *string*                                    | :heavy_check_mark:                          | The unique identifier of the workflow.      | ae232f1f-8efc-4b8c-bb08-626847fad8bb        |
| `InstanceId`                                | *string*                                    | :heavy_check_mark:                          | Unique identifier for the workflow instance |                                             |
| `serverURL`                                 | *string*                                    | :heavy_minus_sign:                          | An optional server URL to use.              | http://localhost:8080                       |

### Response

**[GetWorkflowInstanceResponse](../../Models/Requests/GetWorkflowInstanceResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Docusign.IAM.Models.Errors.Error        | 400, 401, 403, 404                      | application/json                        |
| Docusign.IAM.Models.Errors.Error        | 500                                     | application/json                        |
| Docusign.IAM.Models.Errors.APIException | 4XX, 5XX                                | \*/\*                                   |

## CancelWorkflowInstance

This operation cancels a running Maestro workflow instance by its unique identifier (`instanceId`).
Once canceled, the workflow instance will no longer continue executing any remaining steps.

### Use Cases:
- Stopping a workflow execution when it is no longer needed or relevant
- Manually intervening in a workflow to prevent it from reaching completion if conditions change

### Key Features:
- **Immediate Termination**: Ensures the workflow instance no longer processes subsequent steps
- **Clear Feedback**: Returns a confirmation message including both the instance and workflow identifiers


### Example Usage

```csharp
using Docusign.IAM;
using Docusign.IAM.Models.Components;

var sdk = new DocusignIamSDK(accessToken: "<YOUR_ACCESS_TOKEN_HERE>");

var res = await sdk.Maestro.WorkflowInstanceManagement.CancelWorkflowInstanceAsync(
    accountId: "ae232f1f-8efc-4b8c-bb08-626847fad8bb",
    workflowId: "ae232f1f-8efc-4b8c-bb08-626847fad8bb",
    instanceId: "b5b3b5aa-4161-4afc-a2d9-f69439d14691"
);

// handle response
```

### Parameters

| Parameter                                   | Type                                        | Required                                    | Description                                 | Example                                     |
| ------------------------------------------- | ------------------------------------------- | ------------------------------------------- | ------------------------------------------- | ------------------------------------------- |
| `AccountId`                                 | *string*                                    | :heavy_check_mark:                          | The unique identifier of the account.       | ae232f1f-8efc-4b8c-bb08-626847fad8bb        |
| `WorkflowId`                                | *string*                                    | :heavy_check_mark:                          | The unique identifier of the workflow.      | ae232f1f-8efc-4b8c-bb08-626847fad8bb        |
| `InstanceId`                                | *string*                                    | :heavy_check_mark:                          | Unique identifier for the workflow instance |                                             |
| `serverURL`                                 | *string*                                    | :heavy_minus_sign:                          | An optional server URL to use.              | http://localhost:8080                       |

### Response

**[Models.Requests.CancelWorkflowInstanceResponse](../../Models/Requests/CancelWorkflowInstanceResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Docusign.IAM.Models.Errors.APIException | 4XX, 5XX                                | \*/\*                                   |