# IO.Swagger.Model.WorkflowTask
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AsyncComplete** | **bool?** |  | [optional] 
**CaseExpression** | **string** |  | [optional] 
**CaseValueParam** | **string** |  | [optional] 
**DecisionCases** | **Dictionary&lt;string, List&lt;WorkflowTask&gt;&gt;** |  | [optional] 
**DefaultCase** | [**List&lt;WorkflowTask&gt;**](WorkflowTask.md) |  | [optional] 
**DefaultExclusiveJoinTask** | **List&lt;string&gt;** |  | [optional] 
**Description** | **string** |  | [optional] 
**DynamicForkJoinTasksParam** | **string** |  | [optional] 
**DynamicForkTasksInputParamName** | **string** |  | [optional] 
**DynamicForkTasksParam** | **string** |  | [optional] 
**DynamicTaskNameParam** | **string** |  | [optional] 
**EvaluatorType** | **string** |  | [optional] 
**Expression** | **string** |  | [optional] 
**ForkTasks** | **List&lt;List&lt;WorkflowTask&gt;&gt;** |  | [optional] 
**InputParameters** | **Dictionary&lt;string, Object&gt;** |  | [optional] 
**JoinOn** | **List&lt;string&gt;** |  | [optional] 
**LoopCondition** | **string** |  | [optional] 
**LoopOver** | [**List&lt;WorkflowTask&gt;**](WorkflowTask.md) |  | [optional] 
**Name** | **string** |  | 
**Optional** | **bool?** |  | [optional] 
**RateLimited** | **bool?** |  | [optional] 
**RetryCount** | **int?** |  | [optional] 
**ScriptExpression** | **string** |  | [optional] 
**Sink** | **string** |  | [optional] 
**StartDelay** | **int?** |  | [optional] 
**SubWorkflowParam** | [**SubWorkflowParams**](SubWorkflowParams.md) |  | [optional] 
**TaskDefinition** | [**TaskDef**](TaskDef.md) |  | [optional] 
**TaskReferenceName** | **string** |  | 
**Type** | **string** |  | [optional] 
**WorkflowTaskType** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

