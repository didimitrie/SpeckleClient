using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace SpeckleClient
{
    public class SpeckleClient
        : ISpeckleClient
    {
        private const string _clientName = "SpeckleClient";

        private readonly IOperationExecutor _executor;

        public SpeckleClient(IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public Task<IOperationResult<IGetServerInfo>> GetServerInfoAsync(
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetServerInfoOperation(),
                cancellationToken);
        }

        public Task<IOperationResult<IGetServerInfo>> GetServerInfoAsync(
            GetServerInfoOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<IGetMyProfile>> GetMyProfileAsync(
            CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetMyProfileOperation(),
                cancellationToken);
        }

        public Task<IOperationResult<IGetMyProfile>> GetMyProfileAsync(
            GetMyProfileOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public Task<IOperationResult<IGetStream>> GetStreamAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default)
        {
            if (id.HasValue && id.Value is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _executor.ExecuteAsync(
                new GetStreamOperation { Id = id },
                cancellationToken);
        }

        public Task<IOperationResult<IGetStream>> GetStreamAsync(
            GetStreamOperation operation,
            CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
