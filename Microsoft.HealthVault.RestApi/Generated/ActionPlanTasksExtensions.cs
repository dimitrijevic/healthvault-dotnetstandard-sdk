// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.HealthVault.RestApi.Generated
{
    using Microsoft.HealthVault;
    using Microsoft.HealthVault.RestApi;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ActionPlanTasks.
    /// </summary>
    public static partial class ActionPlanTasksExtensions
    {
            /// <summary>
            /// Get a collection of task definitions
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTaskStatus'>
            /// Possible values include: 'Unknown', 'Archived', 'InProgress',
            /// 'Recommended', 'Completed', 'Template'
            /// </param>
            /// <param name='maxPageSize'>
            /// The maximum number of entries to return per page. Defaults to 1000.
            /// </param>
            public static ActionPlanTasksResponseActionPlanTaskInstanceV2 Get(this IActionPlanTasks operations, string actionPlanTaskStatus = default(string), int? maxPageSize = default(int?))
            {
                return operations.GetAsync(actionPlanTaskStatus, maxPageSize).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a collection of task definitions
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTaskStatus'>
            /// Possible values include: 'Unknown', 'Archived', 'InProgress',
            /// 'Recommended', 'Completed', 'Template'
            /// </param>
            /// <param name='maxPageSize'>
            /// The maximum number of entries to return per page. Defaults to 1000.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ActionPlanTasksResponseActionPlanTaskInstanceV2> GetAsync(this IActionPlanTasks operations, string actionPlanTaskStatus = default(string), int? maxPageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(actionPlanTaskStatus, maxPageSize, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put an update for an action plan task
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTask'>
            /// </param>
            public static ActionPlanTasksResponseActionPlanTaskInstanceV2 Replace(this IActionPlanTasks operations, ActionPlanTaskInstanceV2 actionPlanTask)
            {
                return operations.ReplaceAsync(actionPlanTask).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put an update for an action plan task
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTask'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ActionPlanTasksResponseActionPlanTaskInstanceV2> ReplaceAsync(this IActionPlanTasks operations, ActionPlanTaskInstanceV2 actionPlanTask, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.ReplaceWithHttpMessagesAsync(actionPlanTask, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Post a new action plan task
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTask'>
            /// </param>
            public static object Create(this IActionPlanTasks operations, ActionPlanTaskV2 actionPlanTask)
            {
                return operations.CreateAsync(actionPlanTask).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Post a new action plan task
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTask'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> CreateAsync(this IActionPlanTasks operations, ActionPlanTaskV2 actionPlanTask, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(actionPlanTask, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Patch an update for an action plan task
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTask'>
            /// </param>
            public static ActionPlanTasksResponseActionPlanTaskInstanceV2 Update(this IActionPlanTasks operations, ActionPlanTaskInstanceV2 actionPlanTask)
            {
                return operations.UpdateAsync(actionPlanTask).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Patch an update for an action plan task
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTask'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ActionPlanTasksResponseActionPlanTaskInstanceV2> UpdateAsync(this IActionPlanTasks operations, ActionPlanTaskInstanceV2 actionPlanTask, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(actionPlanTask, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get a task by id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTaskId'>
            /// </param>
            public static ActionPlanTaskInstanceV2 GetById(this IActionPlanTasks operations, string actionPlanTaskId)
            {
                return operations.GetByIdAsync(actionPlanTaskId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a task by id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTaskId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ActionPlanTaskInstanceV2> GetByIdAsync(this IActionPlanTasks operations, string actionPlanTaskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetByIdWithHttpMessagesAsync(actionPlanTaskId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a task by id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTaskId'>
            /// </param>
            public static object Delete(this IActionPlanTasks operations, string actionPlanTaskId)
            {
                return operations.DeleteAsync(actionPlanTaskId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a task by id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='actionPlanTaskId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> DeleteAsync(this IActionPlanTasks operations, string actionPlanTaskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.DeleteWithHttpMessagesAsync(actionPlanTaskId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='trackingValidation'>
            /// </param>
            public static ActionPlanTaskTrackingResponseActionPlanTaskTracking ValidateTracking(this IActionPlanTasks operations, TrackingValidation trackingValidation)
            {
                return operations.ValidateTrackingAsync(trackingValidation).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='trackingValidation'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ActionPlanTaskTrackingResponseActionPlanTaskTracking> ValidateTrackingAsync(this IActionPlanTasks operations, TrackingValidation trackingValidation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.ValidateTrackingWithHttpMessagesAsync(trackingValidation, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}