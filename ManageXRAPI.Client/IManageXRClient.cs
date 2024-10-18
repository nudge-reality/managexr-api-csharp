using System.Collections.Generic;
using System.Threading.Tasks;
using ManageXRAPI.Client.Commands;
using ManageXRAPI.Client.Requests;
using ManageXRAPI.Client.Responses;

namespace ManageXRAPI.Client
{
    /// <summary>
    /// Client for interacting with the ManageXR API.
    /// </summary>
    public interface IManageXRClient
    {
        /// <summary>
        /// Lists all devices in the organisation.
        /// </summary>
        /// <returns>A list of <see cref="Device"/></returns>
        /// <remarks>https://docs.managexr.com/api-reference/endpoint/list-devices</remarks>
        Task<List<Device>> ListDevices();

        /// <summary>
        /// Gets a device by its ID.
        /// </summary>
        /// <param name="deviceId">The device ID.</param>
        /// <returns>The device with the matching device id</returns>
        /// <remarks>https://docs.managexr.com/api-reference/endpoint/get-device</remarks>
        Task<Device> GetDevice(string deviceId);

        /// <summary>
        /// Edits a device.
        /// </summary>
        /// <param name="deviceId">The device ID.</param>
        /// <param name="options">The editable options you'd like to set the device to</param>
        /// <remarks>https://docs.managexr.com/api-reference/endpoint/edit</remarks>
        Task EditDevice(string deviceId, EditDeviceOptions options);

        /// <summary>
        /// Sends a command to a device.
        /// </summary>
        /// <param name="deviceId">The device ID.</param>
        /// <param name="deviceCommand">The device command.</param>
        /// <remarks>https://docs.managexr.com/api-reference/endpoint/send-command</remarks>
        Task SendCommand(string deviceId, DeviceCommand deviceCommand);
        
        /// <summary>
        /// Sends a batch command to multiple devices.
        /// </summary>
        /// <param name="batchCommand">The batch command.</param>
        /// <remarks>https://docs.managexr.com/api-reference/endpoint/batch-commands</remarks>
        Task SendBatchCommand(BatchCommand batchCommand);

        /// <summary>
        /// Sets the pause updates status for multiple devices.
        /// </summary>
        /// <param name="pauseUpdates">If set to <c>true</c>, pauses updates.</param>
        /// <param name="deviceIds">The device IDs.</param>
        /// <remarks>https://docs.managexr.com/api-reference/endpoint/set-pause-updates</remarks>
        Task SetPauseUpdates(bool pauseUpdates, params string[] deviceIds);

        /// <summary>
        /// Lists all configurations in the organisation.
        /// </summary>
        /// <returns>A list of <see cref="ConfigurationSummary"/> objects.</returns>
        /// <remarks>https://docs.managexr.com/api-reference/endpoint/list-configurations</remarks>
        Task<List<ConfigurationSummary>> ListConfigurations();

        /// <summary>
        /// Gets a configuration by its ID.
        /// </summary>
        /// <param name="configurationId">The configuration ID.</param>
        /// <returns>The <see cref="Configuration"/> with the matching configuration id</returns>
        Task<Configuration> GetConfiguration(string configurationId);
    }
}