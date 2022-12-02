# Writing Workers with the C# SDK

A worker is responsible for executing a task. 
Operator and System tasks are handled by the Conductor server, while user defined tasks needs to have a worker created that awaits the work to be scheduled by the server for it to be executed.

Worker framework provides features such as polling threads, metrics and server communication.

### Design Principles for Workers
Each worker embodies design pattern and follows certain basic principles:

1. Workers are stateless and do not implement a workflow specific logic. 
2. Each worker executes a very specific task and produces well-defined output given specific inputs. 
3. Workers are meant to be idempotent (or should handle cases where the task that partially executed gets rescheduled due to timeouts etc.)
4. Workers do not implement the logic to handle retries etc, that is taken care by the Conductor server.

### Creating Task Workers
Task worker is implemented using a function that confirms to the following function

<!-- TODO add snippet -->

Worker returns a struct as the output of the task execution.  The struct MUST be serializable to a JSON map.
If an `error` is returned, the task is marked as `FAILED`

#### Task worker that returns a struct

<!-- TODO add snippet -->

#### Controlling execution for long-running tasks
For the long-running tasks you might want to spawn another process/routine and update the status of the task at a later point and complete the
execution function without actually marking the task as `COMPLETED`.  Use `TaskResult` struct that allows you to specify more fined grained control.

Here is an example of a task execution function that returns with `IN_PROGERSS` status asking server to push the task again in 60 seconds.

<!-- TODO add snippet -->

## Starting Workers
`TaskRunner` interface is used to start the workers, which takes care of polling server for the work, executing worker code and updating the results back to the server.

<!-- TODO add snippet -->

## Task Management APIs

### Get Task Details

<!-- TODO add snippet -->

### Updating the Task result outside the worker implementation
#### Update task by id

<!-- TODO add snippet -->

#### Update task by Reference Name

<!-- TODO add snippet -->

### Worker Metrics
We use [Prometheus](https://prometheus.io/) to collect metrics.
When enabled the worker starts an HTTP server which is used to publish metrics, which can be hooked up to a prometheus server to scrap and collect metrics.

#### Starting metrics collection

<!-- TODO add snippet -->

Worker SDK collects the following metrics:


| Name        | Purpose           | Tags  |
| ------------- |:-------------| -----|
| task_poll_error | Client error when polling for a task queue | taskType, includeRetries, status |
| task_execute_error | Execution error | taskType|
| task_update_error | Task status cannot be updated back to server  | taskType |
| task_poll_counter | Incremented each time polling is done  | taskType |
| task_poll_time | Time to poll for a batch of tasks | taskType |
| task_execute_time | Time to execute a task  | taskType |
| task_result_size | Records output payload size of a task | taskType |

Metrics on client side supplements the one collected from server in identifying the network as well as client side issues.

### Next: [Create and Execute Workflows](/docs/readme/workflow.md)
